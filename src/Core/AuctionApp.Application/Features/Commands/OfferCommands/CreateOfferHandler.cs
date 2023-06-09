﻿using AuctionApp.Application.DTOs.Requests.OfferRequests;
using AuctionApp.Application.DTOs.Responses.OfferResponses;
using AuctionApp.Application.Repositories;
using AuctionApp.Domain.Entities;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace AuctionApp.Application.Features.Commands.OfferCommands
{
    public class CreateOfferHandler : IRequestHandler<CreateOfferRequest, CreateOfferResponse>
    {
        private readonly IMapper _mapper;
        private readonly IOfferRepository _offerRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<AppUser> _userManager;
        private readonly IAuctionRepository _auctionRepository;
        public CreateOfferHandler(IMapper mapper, IOfferRepository offerRepository, IHttpContextAccessor httpContextAccessor, UserManager<AppUser> userManager, IAuctionRepository auctionRepository)
        {
            _mapper = mapper;
            _offerRepository = offerRepository;
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
            _auctionRepository = auctionRepository;
        }
        public async Task<CreateOfferResponse> Handle(CreateOfferRequest request, CancellationToken cancellationToken)
        {
            Auction auction = await _auctionRepository.GetByIdAysnc(request.AuctionId.ToString());
            int nedir = DateTime.Compare(auction.ExpirationTime, DateTime.Now);
            if (nedir == 1)
            {
                if (request.OfferPrice < request.beginPrice || request.OfferPrice < request.lastOfferPrice)
                {
                    return new()
                    {
                        Status = false,
                        Message = "Teklifiniz son tekliften ve açılış fiyatından büyük olmalıdır."
                    };
                }
            }
            else
            {
                return new()
                {
                    Status = false,
                    Message = "Müzayede bitti."
                };
            }
            Offer offer = _mapper.Map<Offer>(request);
            var name = _httpContextAccessor.HttpContext.User?.Identity?.Name;
            AppUser user = new();
            if (name != null)
            {
                user = await _userManager.FindByNameAsync(name);
            }
            var userOffer = await _offerRepository.GetSingleAysnc(o => o.UserId == user.Id && o.AuctionId == request.AuctionId);

            if (userOffer == null && offer.AuctionId == request.AuctionId)
            {
                offer.UserId = user.Id;
                await _offerRepository.AddAysnc(offer);
            }
            else
            {
                userOffer.OfferPrice = (request.OfferPrice);
                _offerRepository.Update(userOffer);
            }

            await _offerRepository.SaveAysnc();
            return new()
            {
                Status = true,
                Message = "Başarılı teklif."
            };
        }
    }
}
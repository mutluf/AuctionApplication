﻿using AuctionApp.Application.DTOs.Requests.AppUserAuctionRequest;
using AuctionApp.Application.DTOs.Requests.AuctionRequests;
using AuctionApp.Application.Repositories;
using AuctionApp.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace AuctionApp.Application.Features.Commands
{
    public class RegisterUserAuctionHandler : IRequestHandler<RegisterUserAuctionRequest>
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IAppUserAuctionRepository _userAuctionRepository;
        private IHttpContextAccessor _httpContextAccessor;

        public RegisterUserAuctionHandler(IAppUserAuctionRepository userAuctionRepository, UserManager<AppUser> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _userAuctionRepository = userAuctionRepository;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<Unit> Handle(RegisterUserAuctionRequest request, CancellationToken cancellationToken)
        {
            var name = _httpContextAccessor.HttpContext.User.Identity.Name;
            var user = await _userManager.FindByNameAsync(name);

           

            AppUserAuction userAuction = new() 
            {
                AuctionId = request.AuctionId,
                AppUserId = user.Id
            };

            await _userAuctionRepository.AddAysnc(userAuction);
            await _userAuctionRepository.SaveAysnc();

            return Unit.Value;
        }
    }
}

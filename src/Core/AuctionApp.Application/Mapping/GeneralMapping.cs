using AuctionApp.Application.DTOs.Requests.AppUserAuctionRequest;
using AuctionApp.Application.DTOs.Requests.AuctionRequests;
using AuctionApp.Application.DTOs.Requests.OfferRequests;
using AuctionApp.Application.DTOs.Requests.ProductRequests;
using AuctionApp.Application.DTOs.Requests.UserRequests;
using AuctionApp.Application.DTOs.Responses.ProductResponses;
using AuctionApp.Application.DTOs;
using AuctionApp.Domain.Entities;
using AutoMapper;
using AuctionApp.Application.DTOs.Responses.AuctionResponses;

namespace StockTracking.Application.Mapping
{
    public class GeneralMapping:Profile
    {
        public GeneralMapping()
        {
            CreateMap<CreateUserRequest, AppUser>().ReverseMap();

            CreateMap<CreateProductRequest, Product>().ReverseMap();
            CreateMap<UpdateProductRequest, Product>().ReverseMap();
            CreateMap<ProductDTO, Product>().ReverseMap();
            CreateMap<GetProductByIdResponse, Product>().ReverseMap();
            CreateMap<AuctionDTO, Auction>().ReverseMap().ForMember(d => d.Product, o => o.MapFrom(s => s.Product));
            CreateMap<CreateOfferRequest, Offer>().ReverseMap();
            CreateMap<Auction, GetAuctionByIdResponse>().ReverseMap();

            CreateMap<CreateAuctionRequest, Auction>().ReverseMap();

            CreateMap<CreateAppUserAuctionRequest, AppUserAuction>().ReverseMap();
        }
    }
}

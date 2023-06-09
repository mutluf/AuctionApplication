﻿using AuctionApp.Domain.Entities;
using MediatR;

namespace AuctionApp.Application.DTOs.Requests.AuctionRequests
{
    public class CreateAuctionRequest:IRequest
    {
        public string Title { get; set; }       
        public int ProductId { get; set; }
        public DateTime ExpirationTime { get; set; }
       
    }
}

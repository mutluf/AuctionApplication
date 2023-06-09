﻿using AuctionApp.Application.DTOs.Responses.ProductResponses;
using MediatR;

namespace AuctionApp.Application.DTOs.Requests.ProductRequests
{
    public class CreateProductRequest:IRequest<CreateProductResponse>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public int BeginPrice { get; set; }
        public DateTime BeginDate { get; set; }
		public bool? IsSold { get; set; }
	}
}

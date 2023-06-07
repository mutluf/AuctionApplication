﻿using AuctionApp.Application.DTOs.Responses.ProductResponses;
using MediatR;

namespace AuctionApp.Application.DTOs.Requests.ProductRequests
{
    public class GetAllProductRequest:IRequest<GetAllProductsResponse>
    {
    }
}

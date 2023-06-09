using AuctionApp.Application.DTOs.Responses.ProductResponses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionApp.Application.DTOs.Requests.ProductRequests
{
    public class GetIsNotInAuctionProductRequest:IRequest<GetIsNotInAuctionProductResponse>
    {

    }
}

using AuctionApp.Application.DTOs.Responses.AuctionResponses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionApp.Application.DTOs.Requests.AuctionRequests
{
    public class UpdateAuctionRequest:IRequest<UpdateAuctionResponse>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int ProductId { get; set; }
        public DateTime ExpirationTime { get; set; }
    }
}

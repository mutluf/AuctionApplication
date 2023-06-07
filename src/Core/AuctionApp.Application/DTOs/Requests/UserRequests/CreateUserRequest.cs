using AuctionApp.Application.DTOs.Responses.UserResponses;
using MediatR;

namespace AuctionApp.Application.DTOs.Requests.UserRequests
{
    public class CreateUserRequest:IRequest<CreateUserResponse>
    {
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }

        public string Password { get; set; }
    }
}

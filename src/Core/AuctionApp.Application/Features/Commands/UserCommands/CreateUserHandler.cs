using AuctionApp.Application.DTOs.Requests.UserRequests;
using AuctionApp.Application.DTOs.Responses.UserResponses;
using AuctionApp.Domain.Entities;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace AuctionApp.Application.Features.Commands.UserCommands
{
    public class CreateUserHandler:IRequestHandler<CreateUserRequest,CreateUserResponse>
    {
        readonly UserManager<AppUser> _userManager;
        readonly IMapper _mapper;

        public CreateUserHandler(UserManager<AppUser> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<CreateUserResponse> Handle(CreateUserRequest request, CancellationToken cancellationToken)
        {
            AppUser user = _mapper.Map<AppUser>(request);
            IdentityResult result = await _userManager.CreateAsync(user, request.Password);

            List<string> errors = new List<string>();

            foreach (var error in result.Errors)
            {
                errors.Add(error.Description);
            }

            if (result.Succeeded)
            {
                return new()
                {
                    Message = "kayıt başarılı!"
                };
            }
            else
            {

                return new()
                {
                    Errors = errors
                };
            }
        }
    }
}

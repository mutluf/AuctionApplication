namespace AuctionApp.Application.DTOs.Responses.UserResponses
{
    public class CreateUserResponse
    {
        public string Message { get; set; }
        public List<string> Errors { get; set; }
    }
}

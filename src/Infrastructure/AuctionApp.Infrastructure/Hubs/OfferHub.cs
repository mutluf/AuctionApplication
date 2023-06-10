using Microsoft.AspNetCore.SignalR;


namespace AuctionApp.Infrastructure.Hubs
{
    public class OfferHub: Hub
    {
        public async Task SendMessageAsync()
        {
          
            //await Clients.All.SendAsync("receiveMessage", "hello");
        }
    }
}

using Microsoft.AspNetCore.SignalR;


namespace AuctionApp.Infrastructure.Hubs
{
    public class ProductHub: Hub
    {
        public async Task SendMessageAsync()
        {
          
            //await Clients.All.SendAsync("receiveMessage", "hello");
        }
    }
}

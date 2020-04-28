using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Primitives;
using MyOrange.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyOrange.PrimaryHub.Hubs
{

    // dotnet add package Microsoft.AspNetCore.SignalR
    // [Authorize]
    public class CustomersHub : Hub
    {
        public override async Task OnConnectedAsync()
        {
            if (this.Context.GetHttpContext().Request.Headers.TryGetValue("Grupa", out StringValues groups))
            {
                foreach (var group in groups)
                {
                    await this.Groups.AddToGroupAsync(Context.ConnectionId, group);
                }
                
            }            
        }

        public async Task JoinRoom(string room)
        {
            await this.Groups.AddToGroupAsync(Context.ConnectionId, room);
        }


        public async Task CreatedCustomer(Customer customer)
        {
            // Wysłanie wiadomości "Created" do wszystkich 
            // await this.Clients.All.SendAsync("Created", customer);

            // Wysłanie wiadomości "Created" do pozostałych (oprócz nadawcy)
            // await this.Clients.Others.SendAsync("Created", customer);

            // Wysłanie wiadomości "Created" do grupy GrupaA
            await this.Clients.Group("GrupaA").SendAsync("Created", customer);

            
        }

        public async Task Ping(string message = "Pong")
        {
            await this.Clients.Caller.SendAsync(message);
        }
    }
}

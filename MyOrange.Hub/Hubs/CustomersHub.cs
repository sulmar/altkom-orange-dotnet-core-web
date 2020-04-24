﻿using Microsoft.AspNetCore.SignalR;
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

          //  Context.User.
            await this.Groups.AddToGroupAsync(Context.ConnectionId, "GrupaA");
        }

        public async Task JoinRoom(string room)
        {
            await this.Groups.AddToGroupAsync(Context.ConnectionId, room);
        }


        public async Task CreatedCustomer(Customer customer)
        {
            // await this.Clients.All.SendAsync("Created", customer);

            await this.Clients.Others.SendAsync("Created", customer);

            await this.Clients.Group("GrupaA").SendAsync("Created", customer);

            
        }

        public async Task Ping(string message = "Pong")
        {
            await this.Clients.Caller.SendAsync(message);
        }
    }
}
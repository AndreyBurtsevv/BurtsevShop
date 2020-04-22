using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lesson19_1.Hubs
{
    public class ChatHub : Hub 
    {
        public async Task Send(string user, string messege)
        {
            await this.Clients.All.SendAsync("ReciveMeddege", user, messege); 
        }
    }
}

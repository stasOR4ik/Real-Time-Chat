using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chat.Models;

namespace Chat
{
    public class ChatHub : Hub
    {
        public async Task Send(string message, string userName)
        {
            await Clients.All.InvokeAsync("Send", message, userName);
        }

        public async Task Save(string message, string userName)
        {
            using (var context = new UserContext())
            {
                context.Messages.Add(new Message(message, userName));
                await context.SaveChangesAsync();
            }
        }
    }
}

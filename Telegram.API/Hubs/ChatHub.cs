using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace Telegram.API.Hubs
{
    //[Authorize]
    public class ChatHub :Hub
    {
        public override Task OnDisconnectedAsync(Exception exception)
        {
            return base.OnDisconnectedAsync(exception);
        }
        public async Task SendMessage(string message)
        {
           await Clients.Caller.SendAsync("SendMessageRespons", message);
        }

    }
}

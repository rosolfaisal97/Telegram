using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Telegram.Core.Data;

namespace Telegram.Infra.Hubs
{
    public class MyHub:Hub
    {
        public void askServer(string text )
        {
            
             Clients.Clients(this.Context.ConnectionId).SendAsync("Send", text);
        }
    }
}

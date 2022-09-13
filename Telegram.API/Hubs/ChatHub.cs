using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using Telegram.Core.Data;
using Telegram.Core.Service;
using Telegram.Infra.Service;

namespace Telegram.API.Hubs
{
    [Authorize]  
    public class ChatHub : Hub
    {

        private readonly IConnectionService _connectionService;
        private readonly IChatMassageService _chatMassageService;
        public ChatHub(IConnectionService connectionService, IChatMassageService chatMassageService)
        {
            _connectionService = connectionService;
            _chatMassageService = chatMassageService;

        }
        public override Task OnConnectedAsync()
        {
            //TODO get all mine message

            var userId = int.Parse(Context.User
                .Claims.FirstOrDefault(u => u.Type == "userid").Value);

            AuthMe(userId);

            var user = _connectionService.GetItem(new Connection { UserId = userId });

            Debug.WriteLine("*************************");
            Debug.WriteLine($"ConnectionId: {Context.ConnectionId}");
            Debug.WriteLine($"Token: " + Context.User.Claims.FirstOrDefault(u => u.Type == "userName"));
            Debug.WriteLine("*************************");

            Clients.Others.SendAsync("UserOn", user);


            return base.OnConnectedAsync();
        }
        public override Task OnDisconnectedAsync(Exception exception)
        {
            var currentConn = _connectionService.GetItem(new Connection
            {
                ConnectionId = Context.ConnectionId
            });
            if (currentConn != null)
            {
                _connectionService.delete(new Connection
                {
                    UserId = currentConn.UserId
                });
                Clients.Others.SendAsync("UserOff", currentConn.UserId);
            }

            return base.OnDisconnectedAsync(exception);
        }

        public async Task SendMessage(string msg)
        {
            await Clients.Caller.SendAsync("SendMessageRespons", msg);
        }
        public async Task SendMessageToFriend(string connId, int userToId, string msg)
        {
            var userToConn = _connectionService.GetItem(new Connection
            {
                ConnectionId = connId
            });

            var userFrom = _connectionService.GetItem(new Connection
            {
                ConnectionId = Context.ConnectionId
            });

            await Clients
                .Client(connId)
                .SendAsync("sendMsgFriendResponse", Context.ConnectionId, msg);


            var chatMessage = new ChatMessage
            {
                user_from = userFrom.UserId,
                user_to = userToId,
                content = msg,
                is_read = 0,
                created_at = DateTime.Now
            };
            //online
            if (userToConn != null)
            {
                chatMessage.is_read = 1;
            }
            else
            {
                //off line

            }
            _chatMassageService.InsertChatMessage(chatMessage);
        }

        private /*async Task*/void AuthMe(int userId)
        {
            string currSignalrID = Context.ConnectionId;
            var connection = new Connection { UserId = userId, ConnectionId = currSignalrID };
            _connectionService.Insert(connection);
            //var temp = _connectionService.GetItem(new Connection { UserId = userId });
            //  await Clients.Caller.SendAsync("AuthMeResponseSuccess", temp);
            // await Clients.Others.SendAsync("UserOn", temp);
        }
        public async Task LogOut(int userId)
        {
            string currSignalrID = Context.ConnectionId;
            var temp = _connectionService.GetItem(new Connection { UserId = userId });
            if (temp != null)
            {
                DeleteConnection(new Connection
                {
                    UserId = temp.UserId,
                    ConnectionId = temp.ConnectionId
                });
                await Clients.Caller.SendAsync("LogOutResponse");
                await Clients.Others.SendAsync("UserOff", temp.UserId);
            }

        }

        //groups
        public async Task JoinGroup(string groupName)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, groupName);
        }
        public async Task SendMessageToGroup(string groupName, string message)
        {
            await Clients.Group(groupName).SendAsync("ReceiveMessageGroup", message);
        }

        private bool DeleteConnection(Connection connection)
        {
            connection.ConnectionId = Context.ConnectionId;
            return _connectionService.delete(connection);
        }

    }
}

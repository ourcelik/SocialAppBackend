using Business.Abstract;
using Business.Hubs.Abstract;
using Business.Hubs.Sources;
using Core.Extensions;
using Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Business.Hubs
{
    public class UserNotificationHub : Hub<IUserNotificationHub>
    {
        private IHttpContextAccessor _httpContextAccessor { get; set; }
        public UserNotificationHub()
        {
            _httpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();
        }

        public async Task SendAsync(string message)
        {
            await Clients.All.receiveMessage(message);
        }

        public async override Task OnConnectedAsync()
        {
            if (UserLoggedIn())
            {
                OnlineUserSource.Users.AddOrUpdate(GetUserId(), Context.ConnectionId);
                await Clients.Client(Context.ConnectionId).receiveMessage(OnlineUserSource.Users[GetUserId()].ToString());
            }
            
        }

        public async override Task OnDisconnectedAsync(Exception exception)
        {
            await Clients.Others.receiveMessage(OnlineUserSource.Users[GetUserId()].ToString());
            OnlineUserSource.Users.Remove(GetUserId());

        }

        private int? GetUserId()
        {
            int? id = _httpContextAccessor.HttpContext.User.Identity.IsAuthenticated ? Convert.ToInt32(_httpContextAccessor.HttpContext.User.Claims(ClaimTypes.NameIdentifier).FirstOrDefault()):null;

            return id;
        }

        private bool UserLoggedIn() => GetUserId() != null ? true : false;
    }
}

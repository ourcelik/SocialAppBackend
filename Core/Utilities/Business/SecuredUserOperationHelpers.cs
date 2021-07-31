using Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Business
{
    public class SecuredUserOperationHelpers
    {
        static readonly private IHttpContextAccessor _httpContextAccessor;

        static SecuredUserOperationHelpers()
        {
            _httpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();
        }
        public static int GetCurrentUserId()
        {
            var UserId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            return int.Parse(UserId);
        }
        public static string GetCurrentUsername()
        {
            var username = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Name).Value;
            return username;
        }
    }
}

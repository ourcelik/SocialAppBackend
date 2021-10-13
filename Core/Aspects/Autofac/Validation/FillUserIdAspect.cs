using Castle.DynamicProxy;
using Core.Extensions;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Core.Aspects.Autofac.Validation
{
    public class FillUserIdAspect : MethodInterception
    {
        public int _index { get; set; }

        public string _propName { get; set; }

        public IHttpContextAccessor _httpContextAccessor { get; set; }

        public FillUserIdAspect(int parameterIndex,string propName)
        {
            _index = parameterIndex;

            _propName = propName;

            _httpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();
        }

        private int GetUserIdFromClaims() =>  
                        _httpContextAccessor.HttpContext.User.Identity.IsAuthenticated 
                        ? Convert.ToInt32(_httpContextAccessor.HttpContext.User.Claims(ClaimTypes.NameIdentifier).FirstOrDefault())
                        : throw new System.Exception("Permision Denied");

        protected override void OnBefore(IInvocation invocation) =>
                         invocation.Arguments[_index]
                        .GetType()
                        .GetProperty(_propName, BindingFlags.Public | BindingFlags.Instance)
                        .SetValue(invocation.Arguments[_index], GetUserIdFromClaims());

            


    }
}

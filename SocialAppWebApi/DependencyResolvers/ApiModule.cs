using Business.Tools.AutoMapper;
using Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace SocialAppWebApi.DependencyResolvers
{
    public class ApiModule : ICoreModule
    {
        public void Load(IServiceCollection serviceCollection)
        {
            
            serviceCollection.AddAutoMapper(Assembly.GetExecutingAssembly(), Assembly.GetAssembly(typeof(AutoMapperProfile)));
        }
    }
}

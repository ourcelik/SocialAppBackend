using Core.Subcriptions.Abstract;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Extensions
{
    public class DatabaseSubscriptionOptions
    {
        public Type SubscriptionType { get; set; }
        
        public Type[] TableTypes { get; set; }

    }

    public static class DatabaseSubscriptionMiddlewareExtensions
    {
        public static void ConfigureDatabaseSubscription(this IApplicationBuilder builder,DatabaseSubscriptionOptions options)
        {
            SubcribeTablesToWatch(builder,options);
        }

        private static void SubcribeTablesToWatch(IApplicationBuilder builder,DatabaseSubscriptionOptions options)
        {
            foreach (var table in options.TableTypes)
            {
                Type genericType = options.SubscriptionType.MakeGenericType(table);

                dynamic subscription = builder.ApplicationServices.GetService(genericType);

                subscription.Configure(table.Name + "s");

            }
        }
    }
}

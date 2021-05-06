using DataAccess.Concrete.EntityFramework;
using Entities.Concrete.GraphQL;
using HotChocolate;
using HotChocolate.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLWebAPI.GraphQL.Notifications
{
    public class NotificationType : ObjectType<Notification>
    {
        protected override void Configure(IObjectTypeDescriptor<Notification> descriptor)
        {
            descriptor
                .Field(n => n.Profile)
                .ResolveWith<Resolvers>(r => r.GetProfile(default!, default!))
                .UseDbContext<SocialAppGraphQLContext>();
           
        }
       
        private class Resolvers
        {
            public Profile GetProfile(Notification notification, [ScopedService] SocialAppGraphQLContext context)
            {
                return context.Profiles.FirstOrDefault(p => p.NotificationId == notification.NotificationId);
            }
           
        }
    }
}

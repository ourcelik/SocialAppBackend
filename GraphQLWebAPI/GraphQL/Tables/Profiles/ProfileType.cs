using DataAccess.Concrete.EntityFramework;
using Entities.Concrete.GraphQL;
using HotChocolate;
using HotChocolate.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLWebAPI.GraphQL.Tables.Prefers
{
    public class ProfileType :ObjectType<Profile>
    {
        protected override void Configure(IObjectTypeDescriptor<Profile> descriptor)
        {

            descriptor
                .Field(p => p.Photos)
                .ResolveWith<Resolvers>(r => r.GetPhotos(default!, default!))
                .UseDbContext<SocialAppGraphQLContext>()
                .Description("");
            descriptor
                .Field(p => p.ProfilePhoto)
                .ResolveWith<Resolvers>(r => r.GetProfilePhoto(default!, default!))
                .UseDbContext<SocialAppGraphQLContext>()
                .Description("");
            descriptor
                .Field(p => p.notification)
                .ResolveWith<Resolvers>(r => r.GetNotification(default!, default!))
                .UseDbContext<SocialAppGraphQLContext>()
                .Description("");
            descriptor
                .Field(p => p.Gender)
                .ResolveWith<Resolvers>(r => r.GetGender(default!, default!))
                .UseDbContext<SocialAppGraphQLContext>()
                .Description("");
            descriptor
                .Field(p => p.Prefer)
                .ResolveWith<Resolvers>(r => r.GetPrefer(default!, default!))
                .UseDbContext<SocialAppGraphQLContext>()
                .Description("");
        }
        private class Resolvers
        {
            public IQueryable<Photo> GetPhotos(Profile profile,[ScopedService] SocialAppGraphQLContext context)
            {
                return context.Photos.Where(p => p.PhotoId == profile.ProfilePhotoId);
            }
            public Photo GetProfilePhoto(Profile profile, [ScopedService] SocialAppGraphQLContext context)
            {
                return context.Photos.FirstOrDefault(p => p.PhotoId == profile.ProfilePhotoId);
            }
            public Notification GetNotification(Profile profile, [ScopedService] SocialAppGraphQLContext context)
            {
                return context.Notifications.FirstOrDefault(p => p.NotificationId == profile.NotificationId);
            }
            public Prefer GetPrefer(Profile profile, [ScopedService] SocialAppGraphQLContext context)
            {
                return context.Prefers.FirstOrDefault(p => p.PreferId == profile.PreferId);
            }
            public Gender GetGender(Profile profile, [ScopedService] SocialAppGraphQLContext context)
            {
                return context.Genders.FirstOrDefault(g => g.GenderId == profile.GenderId);
            }
        }
    }
}

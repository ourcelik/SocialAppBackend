using DataAccess.Concrete.EntityFramework;
using Entities.Concrete.GraphQL;
using HotChocolate;
using HotChocolate.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLWebAPI.GraphQL.ProfileQuestions
{
    public class ProfileQuestionType: ObjectType<ProfileQuestion>
    {
        protected override void Configure(IObjectTypeDescriptor<ProfileQuestion> descriptor)
        {
            descriptor
               .Field(p => p.Profile)
               .ResolveWith<Resolvers>(r => r.GetProfile(default!, default!))
               .UseDbContext<SocialAppGraphQLContext>()
               .Description("");
            descriptor
               .Field(p => p.Question)
               .ResolveWith<Resolvers>(r => r.GetQuestion(default!, default!))
               .UseDbContext<SocialAppGraphQLContext>()
               .Description("");
            descriptor
               .Field(p => p.Choice)
               .ResolveWith<Resolvers>(r => r.GetChoice(default!, default!))
               .UseDbContext<SocialAppGraphQLContext>()
               .Description("");
            base.Configure(descriptor);
        }
        private class Resolvers
        {
            public Profile GetProfile(ProfileQuestion question,[ScopedService] SocialAppGraphQLContext context)
            {
                return context.Profiles.FirstOrDefault(p => p.ProfileId == question.ProfileId); 
            }
            public Question GetQuestion(ProfileQuestion question, [ScopedService] SocialAppGraphQLContext context)
            {
                return context.Questions.FirstOrDefault(q=> q.QuestionId == question.QuestionId);
            }
            public Choice GetChoice(ProfileQuestion question, [ScopedService] SocialAppGraphQLContext context)
            {
                return context.Choices.FirstOrDefault(c => c.ChoiceId == question.ChoiceId);
            }
        }
  
    }
}

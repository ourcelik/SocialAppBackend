using DataAccess.Concrete.EntityFramework;
using Entities.Concrete.GraphQL;
using HotChocolate;
using HotChocolate.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLWebAPI.GraphQL.Choices
{
    public class ChoiceType : ObjectType<Choice>
    {
        protected override void Configure(IObjectTypeDescriptor<Choice> descriptor)
        {
            descriptor.Description("Kullanıcıya sorulan sorulara verilebilecek cevaplar");
            descriptor.Field(c => c.ChoiceId)
                .Description("Cevap Id");
            descriptor.Field(c => c.QuestionId)
                .Description("Soru Id");
            descriptor.Field(c => c.ChoiceType)
                .Description("Cevap");
            descriptor
                .Field(c => c.Question)
                .ResolveWith<Resolvers>(r => r.GetQuestion(default!, default!))
                .UseDbContext<SocialAppGraphQLContext>()
                .Description("Soru");

        }
        private class Resolvers
        {
            public Question GetQuestion(Choice choice, [ScopedService] SocialAppGraphQLContext context)
            {
                return context.Questions.FirstOrDefault(q => q.QuestionId == choice.QuestionId);
            }
        }
    }
}

using DataAccess.Concrete.EntityFramework;
using Entities.Concrete.GraphQL;
using HotChocolate;
using HotChocolate.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLWebAPI.GraphQL.Questions
{
    public class QuestionType : ObjectType<Question>
    {
        protected override void Configure(IObjectTypeDescriptor<Question> descriptor)
        {
            descriptor.Description("Kullanıcılara yönlendirilen sorular");
            descriptor
                .Field(q => q.Choices)
                .ResolveWith<Resolvers>(r => r.GetChoices(default!, default!))
                .UseDbContext<SocialAppGraphQLContext>()
                .Description("Kullanıcıya sorulan sorulara verilebilecek cevaplar");

        }
        private class Resolvers
        {
            public IQueryable<Choice> GetChoices(Question question, [ScopedService] SocialAppGraphQLContext context)
            {
                return context.Choices.Where(c => c.QuestionId == question.QuestionId);
            }
        }
    }
}

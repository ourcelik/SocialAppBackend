using DataAccess.Concrete.EntityFramework;
using Entities.Concrete.GraphQL;
using GraphQLWebAPI.GraphQL.Choices;
using GraphQLWebAPI.GraphQL.Questions;
using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Subscriptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GraphQLWebAPI.GraphQL
{
    public class Mutation
    {
        [UseDbContext(typeof(SocialAppGraphQLContext))]
        public async Task<AddQuestionPayload> AddQuestionAsync(AddQuestionInput input,
            [ScopedService] SocialAppGraphQLContext context,
            [Service] ITopicEventSender eventSender,
            CancellationToken cancellationToken
            )
        {
            var question = new Question
            {
                QuestionType = input.question,
            };
            context.Questions.Add(question);
            await context.SaveChangesAsync(cancellationToken);
            await eventSender.SendAsync(nameof(Subscription.OnQuestionAdded), question, cancellationToken);
            return new AddQuestionPayload(question);
        }

        [UseDbContext(typeof(SocialAppGraphQLContext))]
        public async Task<AddChoicePayload> AddChoiceAsync(AddChoiceInput input,
            [ScopedService] SocialAppGraphQLContext context)
        {
            var choice = new Choice
            {
                ChoiceType = input.choiceType,
                QuestionId = input.questionId,
            };
            context.Choices.Add(choice);
            await context.SaveChangesAsync();
            return new AddChoicePayload(choice);
        }

    }
}

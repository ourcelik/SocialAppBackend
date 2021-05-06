using Entities.Concrete.GraphQL;
using HotChocolate;
using HotChocolate.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLWebAPI.GraphQL
{
    public class Subscription
    {
        [Subscribe]
        [Topic]
        public Question OnQuestionAdded([EventMessage] Question question)
        {
            return question;
        }
    }
}

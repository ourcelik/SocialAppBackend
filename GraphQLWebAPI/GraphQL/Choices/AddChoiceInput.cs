using Entities.Concrete.GraphQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLWebAPI.GraphQL.Choices
{
    public record AddChoiceInput(string choiceType,int questionId);
}

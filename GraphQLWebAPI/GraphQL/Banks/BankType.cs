using Entities.Concrete.GraphQL;
using HotChocolate.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLWebAPI.GraphQL.Banks
{
    public class BankType : ObjectType<Bank>
    {
        protected override void Configure(IObjectTypeDescriptor<Bank> descriptor)
        {
            
        }
    }
}

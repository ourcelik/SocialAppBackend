using Entities.Concrete.GraphQL;
using HotChocolate.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLWebAPI.GraphQL.Tables.Genders
{
    public class GenderType:ObjectType<Gender>
    {
        protected override void Configure(IObjectTypeDescriptor<Gender> descriptor)
        {
            base.Configure(descriptor);
        }
    }
}

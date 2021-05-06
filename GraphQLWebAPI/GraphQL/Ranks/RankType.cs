using Entities.Concrete.GraphQL;
using HotChocolate.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLWebAPI.GraphQL.Ranks
{
    public class RankType : ObjectType<Rank>
    {
        protected override void Configure(IObjectTypeDescriptor<Rank> descriptor)
        {
            base.Configure(descriptor);
        }
    }
}

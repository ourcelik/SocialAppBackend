using Entities.Concrete.GraphQL;
using HotChocolate.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLWebAPI.GraphQL.Tables.LikeKinds
{
    public class LikeKindType : ObjectType<LikeKind>
    {
        protected override void Configure(IObjectTypeDescriptor<LikeKind> descriptor)
        {
            base.Configure(descriptor);
        }
    }
}

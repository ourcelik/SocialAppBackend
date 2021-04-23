using System;

namespace Core.Entities.Concrete
{
    public class UserOperationClaim:IEntity
    {
        public int UserOperationClaimId { get; set; }
        public int UserId { get; set; }
        public Int16 OperationClaimId { get; set; }
    }
}

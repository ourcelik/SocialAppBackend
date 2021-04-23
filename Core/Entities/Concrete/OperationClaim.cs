using System;

namespace Core.Entities.Concrete
{
    public class OperationClaim:IEntity
    {
        public Int16 OperationClaimId { get; set; }
        public string ClaimName { get; set; }
    }
}

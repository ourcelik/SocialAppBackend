using Core.DataAccess.EntityFramework;
using Entities.Concrete;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<Entities.Concrete.User, SocialNetworkContext>, IUserDal
    {
        public  List<OperationClaim> GetClaims(Entities.Concrete.User user)
        {
            using (var context = new SocialNetworkContext())
            {
                var result = from operationClaim in context.OperationClaims
                             join userOperationClaim in context.UserOperationClaims
                             on operationClaim.OperationClaimId equals userOperationClaim.OperationClaimId
                             where userOperationClaim.UserId == user.UserId
                             select new OperationClaim
                             {
                                 OperationClaimId = operationClaim.OperationClaimId,
                                 ClaimName = operationClaim.ClaimName,
                             };
                return result.ToList();

            }





        }
    }
}

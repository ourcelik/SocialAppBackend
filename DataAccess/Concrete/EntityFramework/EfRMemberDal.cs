using Core.DataAccess.EntityFramework;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRMemberDal : EfEntityRepositoryBase<R_Member, SocialNetworkContext>,IRMemberDal
    {

    }
}

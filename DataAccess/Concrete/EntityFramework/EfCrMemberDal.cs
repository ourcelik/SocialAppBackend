using Core.DataAccess.EntityFramework;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCrMemberDal : EfEntityRepositoryBase<CR_Member, SocialNetworkContext>,ICrMemberDal
    {

    }
}

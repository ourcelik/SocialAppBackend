using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCrMemberDal : EfEntityRepositoryBase<CR_Member, SocialNetworkContext>,ICrMemberDal
    {

    }
}

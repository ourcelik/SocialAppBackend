using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCRMemberDal : EfEntityRepositoryBase<CR_Member, SocialNetworkContext>,ICrMemberDal
    {

    }
}

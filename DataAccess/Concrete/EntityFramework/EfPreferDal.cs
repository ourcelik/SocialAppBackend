using Core.DataAccess.EntityFramework;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfPreferDal : EfEntityRepositoryBase<Prefer, SocialNetworkContext>,IPreferDal
    {

    }
}

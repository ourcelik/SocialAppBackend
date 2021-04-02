using Core.DataAccess.EntityFramework;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfMatchDal : EfEntityRepositoryBase<Match, SocialNetworkContext>,IMatchDal
    {

    }
}

using Core.DataAccess.EntityFramework;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfLikedDal : EfEntityRepositoryBase<Liked, SocialNetworkContext>,ILikedDal
    {

    }
}

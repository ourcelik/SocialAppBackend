using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfPostLikeDal : EfEntityRepositoryBase<PostLike, SocialNetworkContext>, IPostLikeDal
    {

    }
}

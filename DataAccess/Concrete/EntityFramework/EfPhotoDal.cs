using Core.DataAccess.EntityFramework;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfPhotoDal : EfEntityRepositoryBase<Photo, SocialNetworkContext>,IPhotoDal
    {

    }
}

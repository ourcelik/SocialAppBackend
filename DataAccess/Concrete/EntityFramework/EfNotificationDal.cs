using Core.DataAccess.EntityFramework;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfNotificationDal : EfEntityRepositoryBase<Notification, SocialNetworkContext>,INotificationDal
    {

    }
}

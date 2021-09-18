using Core.DataAccess;
using Entities.Concrete;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface INotificationDal : IEntityRepository<Notification>
    {
       public Notification GetNotificationsByUserId(int id);
    }
    
}

using Core.Utilities.Results;
using Entities.Concrete;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface INotificationService
    {
        public Task<IDataResult<Notification>> GetNotificationSettingById(int id);
    }
}

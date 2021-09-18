using Core.Utilities.Results;
using Entities.Concrete;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface INotificationService
    {
        public Task<IDataResult<Notification>> GetNotificationSettingById(int id);
        public IDataResult<Notification> GetNotificationsByUserId(int id);
        public Task<IDataResult<int>> AddNotificationSettingsAsync(Notification notification);
        public Task<IDataResult<int>> UpdateNotificationSettingsAsync(Notification notification);


    }
}

using Business.Abstract;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class NotificationManager : INotificationService
    {
        readonly INotificationDal _notificationDal;
        public NotificationManager(INotificationDal  notificationDal)
        {
            _notificationDal = notificationDal;
        }

        public async Task<IDataResult<int>> AddNotificationSettingsAsync(Notification notification)
        {
            var notificationModel = await _notificationDal.AddAsync(notification);
            return new SuccessDataResult<int>(notificationModel.NotificationId);
        }

        async public Task<IDataResult<Notification>> GetNotificationSettingById(int id)
        {
            var data = await _notificationDal.GetAsync(n => n.NotificationId == id);

            return new SuccessDataResult<Notification>(data);
        }
        public async Task<IDataResult<int>> UpdateNotificationSettingsAsync(Notification notification)
        {
            var data = await _notificationDal.UpdateAsync(notification);

            return new SuccessDataResult<int>(data.NotificationId);
        }
        public  IDataResult<Notification> GetNotificationsByUserId(int id)
        {
            var data =  _notificationDal.GetNotificationsByUserId(id);

            return new SuccessDataResult<Notification>(data);
        }
    }
}

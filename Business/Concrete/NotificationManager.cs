using Business.Abstract;
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
        async public Task<IDataResult<Notification>> GetNotificationSettingById(int id)
        {
            var data = await _notificationDal.GetAsync(n => n.NotificationId == id);
            return new SuccessDataResult<Notification>(data);
        }
    }
}

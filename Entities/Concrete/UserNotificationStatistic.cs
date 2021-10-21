using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class UserNotificationStatistic:IEntity
    {
        public int NotificationStatisticId { get; set; }

        public int UserId { get; set; }

        public int NotificationCount { get; set; }

        public int NoViewedNotificationCount { get; set; }

    }
}

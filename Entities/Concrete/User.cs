using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class User : Core.Entities.Concrete.User,IEntity
    {
        public int ProfileId { get; set; }
        public int CoinBankId { get; set; }

    }
}

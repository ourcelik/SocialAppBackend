using Core.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class User : IEntity
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string UserPassword { get; set; }
        public string Mail { get; set; }
        public string TelNo { get; set; }
        public int ProfileId { get; set; }
        public int CoinBankId { get; set; }
    }

}
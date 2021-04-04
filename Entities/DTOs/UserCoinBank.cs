using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class UserCoinBank
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public int CooperCoin { get; set; }
        public int SilverCoin { get; set; }
        public int GoldCoin { get; set; }
    }
}

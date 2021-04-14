using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class UserSpecificCoin :IDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public int Coin { get; set; }
    }
}

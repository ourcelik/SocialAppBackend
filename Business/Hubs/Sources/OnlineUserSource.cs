using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Hubs.Sources
{
    public static class OnlineUserSource
    {
        static OnlineUserSource()
        {
            Users = new();
        }

        
       
        public static Dictionary<int?,string> Users { get; set; }
    }
}

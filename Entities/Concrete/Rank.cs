using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Rank:IEntity
    {
        public int RankId { get; set; }
        public string RankType { get; set; }
    }
}

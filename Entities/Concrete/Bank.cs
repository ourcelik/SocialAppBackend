using Core.Entities;

namespace Entities.Concrete
{
    public class Bank : IEntity
    {
        
        public int BankId { get; set; }
        public int Gold_coin { get; set; }
        public int Silver_coin { get; set; }
        public int Copper_coin {get; set;}


    }

}
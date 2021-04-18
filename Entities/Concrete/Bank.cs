using Core.Entities;

namespace Entities.Concrete
{
    public class Bank : IEntity
    {
        
        public int BankId { get; set; }
        public int GoldCoin { get; set; }
        public int SilverCoin { get; set; }
        public int CopperCoin {get; set;}


    }

}
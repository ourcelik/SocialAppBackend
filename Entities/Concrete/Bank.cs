using Core.Entities;
using System;
using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete
{
    public class Bank : IEntity
    {
        public int BankId { get; set; }
        public Int16 GoldCoin { get; set; }
        public Int16 SilverCoin { get; set; }
        public Int16 CopperCoin {get; set;}


    }

}
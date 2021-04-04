using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IBankDal:IEntityRepository<Bank>
    {
        public List<UserSpecificCoin> GetCopperCoinWallets();
        public List<UserSpecificCoin> GetGoldCoinWallets();
        public List<UserSpecificCoin> GetSilverCoinWallets();
        public UserCoinBank GetCoinsByUserId(int id);
        public UserSpecificCoin GetCooperCoinByUserId(int id);
        public UserSpecificCoin GetSilverCoinByUserId(int id);
        public UserSpecificCoin GetGoldCoinByUserId(int id);



    }
}

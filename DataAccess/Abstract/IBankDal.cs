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
        public List<UserSpecificCoinDto> GetCopperCoinWallets();
        public List<UserSpecificCoinDto> GetGoldCoinWallets();
        public List<UserSpecificCoinDto> GetSilverCoinWallets();
        public UserCoinBankDto GetCoinsByUserId(int id);
        public UserSpecificCoinDto GetCooperCoinByUserId(int id);
        public UserSpecificCoinDto GetSilverCoinByUserId(int id);
        public UserSpecificCoinDto GetGoldCoinByUserId(int id);



    }
}

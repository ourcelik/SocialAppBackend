using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    class EfBankDal : EfEntityRepositoryBase<Bank, SocialNetworkContext>, IBankDal
    {
        public UserCoinBank GetCoinsByUserId(int id)
        {
            using SocialNetworkContext context = new();
            var data = from u in context.Users
                       join b in context.Banks
                       on u.CoinBankId equals b.BankId
                       where u.UserId == id
                       select new UserCoinBank
                       {
                           Id = u.UserId,
                           Username = u.Username,
                           CooperCoin = b.Copper_coin,
                           GoldCoin = b.Gold_coin,
                           SilverCoin = b.Silver_coin,
                       };
            return data.SingleOrDefault();
        }

        public UserSpecificCoin GetCooperCoinByUserId(int id)
        {
            using SocialNetworkContext context = new();
            var data = from u in context.Users
                       join b in context.Banks
                       on u.CoinBankId equals b.BankId
                       where u.UserId == id
                       select new UserSpecificCoin
                       {
                           Id = u.UserId,
                           Username = u.Username,
                           Coin = b.Copper_coin,
                       };
            return data.SingleOrDefault();
        }

        public List<UserSpecificCoin> GetCopperCoinWallets()
        {
            using SocialNetworkContext context = new();
            var data = from u in context.Users
                       join b in context.Banks
                       on u.CoinBankId equals b.BankId
                       select new UserSpecificCoin
                       {
                           Id = u.UserId,
                           Username = u.Username,
                           Coin = b.Copper_coin,
                       };
            return data.ToList();
        }

        public UserSpecificCoin GetGoldCoinByUserId(int id)
        {
            using SocialNetworkContext context = new();
            var data = from u in context.Users
                       join b in context.Banks
                       on u.CoinBankId equals b.BankId
                       where u.UserId == id
                       select new UserSpecificCoin
                       {
                           Id = u.UserId,
                           Username = u.Username,
                           Coin = b.Gold_coin,
                       };
            return data.SingleOrDefault();
        }

        public List<UserSpecificCoin> GetGoldCoinWallets()
        {
            using SocialNetworkContext context = new();
            var data = from u in context.Users
                       join b in context.Banks
                       on u.CoinBankId equals b.BankId
                       select new UserSpecificCoin
                       {
                           Id = u.UserId,
                           Username = u.Username,
                           Coin = b.Gold_coin,
                       };
            return data.ToList();
        }

        public UserSpecificCoin GetSilverCoinByUserId(int id)
        {
            using SocialNetworkContext context = new();
            var data = from u in context.Users
                       join b in context.Banks
                       on u.CoinBankId equals b.BankId
                       where u.UserId == id
                       select new UserSpecificCoin
                       {
                           Id = u.UserId,
                           Username = u.Username,
                           Coin = b.Silver_coin,
                       };
            return data.SingleOrDefault();
        }

        public List<UserSpecificCoin> GetSilverCoinWallets()
        {
            using SocialNetworkContext context = new();
            var data = from u in context.Users
                       join b in context.Banks
                       on u.CoinBankId equals b.BankId
                       select new UserSpecificCoin
                       {
                           Id = u.UserId,
                           Username = u.Username,
                           Coin = b.Silver_coin,
                       };
            return data.ToList();
        }
    }
}

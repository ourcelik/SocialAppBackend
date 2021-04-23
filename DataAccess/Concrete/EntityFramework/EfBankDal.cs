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
    public class EfBankDal : EfEntityRepositoryBase<Bank, SocialNetworkContext>, IBankDal
    {
        public UserCoinBankDto GetCoinsByUserId(int id)
        {
            using SocialNetworkContext context = new();
            var data = from u in context.Users
                       join b in context.Banks
                       on u.CoinBankId equals b.BankId
                       where u.UserId == id
                       select new UserCoinBankDto
                       {
                           Id = u.UserId,
                           Username = u.Username,
                           CooperCoin = b.CopperCoin,
                           GoldCoin = b.GoldCoin,
                           SilverCoin = b.SilverCoin,
                       };
            return data.SingleOrDefault();
        }

        public UserSpecificCoinDto GetCooperCoinByUserId(int id)
        {
            using SocialNetworkContext context = new();
            var data = from u in context.Users
                       join b in context.Banks
                       on u.CoinBankId equals b.BankId
                       where u.UserId == id
                       select new UserSpecificCoinDto
                       {
                           Id = u.UserId,
                           Username = u.Username,
                           Coin = b.CopperCoin,
                       };
            return data.SingleOrDefault();
        }

        public List<UserSpecificCoinDto> GetCopperCoinWallets()
        {
            using SocialNetworkContext context = new();
            var data = from u in context.Users
                       join b in context.Banks
                       on u.CoinBankId equals b.BankId
                       select new UserSpecificCoinDto
                       {
                           Id = u.ProfileId,
                           Username = u.Username,
                           Coin = b.CopperCoin,
                       };
            return data.ToList();
        }

        public UserSpecificCoinDto GetGoldCoinByUserId(int id)
        {
            using SocialNetworkContext context = new();
            var data = from u in context.Users
                       join b in context.Banks
                       on u.CoinBankId equals b.BankId
                       where u.UserId == id
                       select new UserSpecificCoinDto
                       {
                           Id = u.UserId,
                           Username = u.Username,
                           Coin = b.GoldCoin,
                       };
            return data.SingleOrDefault();
        }

        public List<UserSpecificCoinDto> GetGoldCoinWallets()
        {
            using SocialNetworkContext context = new();
            var data = from u in context.Users
                       join b in context.Banks
                       on u.CoinBankId equals b.BankId
                       select new UserSpecificCoinDto
                       {
                           Id = u.UserId,
                           Username = u.Username,
                           Coin = b.GoldCoin,
                       };
            return data.ToList();
        }

        public UserSpecificCoinDto GetSilverCoinByUserId(int id)
        {
            using SocialNetworkContext context = new();
            var data = from u in context.Users
                       join b in context.Banks
                       on u.CoinBankId equals b.BankId
                       where u.UserId == id
                       select new UserSpecificCoinDto
                       {
                           Id = u.UserId,
                           Username = u.Username,
                           Coin = b.SilverCoin,
                       };
            return data.SingleOrDefault();
        }

        public List<UserSpecificCoinDto> GetSilverCoinWallets()
        {
            using SocialNetworkContext context = new();
            var data = from u in context.Users
                       join b in context.Banks
                       on u.CoinBankId equals b.BankId
                       select new UserSpecificCoinDto
                       {
                           Id = u.UserId,
                           Username = u.Username,
                           Coin = b.SilverCoin,
                       };
            return data.ToList();
        }
    }
}

using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IBankService
    {
        public IDataResult<Bank> GetAll();
        public IDataResult<int> GetGoldCoin();
        public IDataResult<int> GetSilverCoin();
        public IDataResult<int> GetCooperCoin();
    }
}

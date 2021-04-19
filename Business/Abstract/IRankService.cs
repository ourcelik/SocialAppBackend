using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IRankService
    {
        public Task<IDataResult<Rank>> GetByRankId(int id);
        public Task<IDataResult<List<Rank>>> GetAll();
    }
}

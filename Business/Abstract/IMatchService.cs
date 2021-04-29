using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IMatchService
    {
        public Task<IDataResult<List<Match>>> GetAllMatchesAsync();
        public Task<IDataResult<List<Match>>> GetMatchesByUserIdAsync(int id);
        public Task<IDataResult<List<Match>>> GetMatchesByLevelIdAsync(int id);
        public Task<IDataResult<Match>> GetMatchByIdAsync(int id);
    }
}

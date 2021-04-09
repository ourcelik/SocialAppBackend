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
        public Task<IDataResult<List<Match>>> GetAllMatches();
        public Task<IDataResult<List<Match>>>  GetMatchesByUserId(int id);
        public Task<IDataResult<List<Match>>> GetMatchesByLevelId(int id);
        public Task<IDataResult<Match>> GetMatchById(int id);
    }
}

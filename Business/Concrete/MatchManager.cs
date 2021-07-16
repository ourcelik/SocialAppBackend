using Business.Abstract;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class MatchManager : IMatchService
    {
        readonly IMatchDal _matchDal;
        public MatchManager(IMatchDal matchDal)
        {
            _matchDal = matchDal;
        }

        async public Task<IDataResult<List<Match>>> GetAllMatchesAsync()
        {
            var data = await _matchDal.GetAllAsync();

            return new SuccessDataResult<List<Match>>(data);
        }

        async public Task<IDataResult<Match>> GetMatchByIdAsync(int id)
        {
            var data = await _matchDal.GetAsync(m=> m.ChatLevelId == id);

            return new SuccessDataResult<Match>(data);
        }

        async public Task<IDataResult<List<Match>>> GetMatchesByLevelIdAsync(int levelId)
        {
            var data = await _matchDal.GetAllAsync(m=> m.ChatLevelId == levelId);

            return new SuccessDataResult<List<Match>>(data);
        }

        async public Task<IDataResult<List<Match>>> GetMatchesByUserIdAsync(int UserId)
        {
            var data = await _matchDal.GetAllAsync(m=> m.MatchProfileId == UserId);

            return new SuccessDataResult<List<Match>>(data);
        }
    }
}

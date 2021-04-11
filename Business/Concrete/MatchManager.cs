﻿using Business.Abstract;
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
        async public Task<IDataResult<List<Match>>> GetAllMatches()
        {
            var data = await _matchDal.GetAllAsync();
            return new SuccessDataResult<List<Match>>(data);
        }

        async public Task<IDataResult<Match>> GetMatchById(int id)
        {
            var data = await _matchDal.GetAsync(m=> m.MatchId == id);
            return new SuccessDataResult<Match>(data);
        }

        async public Task<IDataResult<List<Match>>> GetMatchesByLevelId(int LevelId)
        {
            var data = await _matchDal.GetAllAsync(m=> m.Chat_LevelId == LevelId);
            return new SuccessDataResult<List<Match>>(data);
        }

        async public Task<IDataResult<List<Match>>> GetMatchesByUserId(int UserId)
        {
            var data = await _matchDal.GetAllAsync(m=> m.MatchUserId == UserId);
            return new SuccessDataResult<List<Match>>(data);
        }
    }
}
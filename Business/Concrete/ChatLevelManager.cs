using Business.Abstract;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ChatLevelManager : IChatLevelService
    {
        readonly IChatLevelDal _chatLevelDal;
        public ChatLevelManager(IChatLevelDal chatLevelDal)
        {
            _chatLevelDal = chatLevelDal;
        }

        public async Task<IDataResult<List<ChatLevel>>> GetAllAsync()
        {
            var data = await _chatLevelDal.GetAllAsync();

            return new SuccessDataResult<List<ChatLevel>>(data);
        }

        public async Task<IDataResult<List<ChatLevel>>> GetByChatLevelAsync(string level)
        {
            var data = await _chatLevelDal.GetAllAsync(c => c.Level == level);

            return new SuccessDataResult<List<ChatLevel>>(data);
        }

        public async Task<IDataResult<ChatLevel>> GetByChatLevelId(int id)
        {
            var data = await _chatLevelDal.GetAsync(c => c.ChatLevelId == id);

            return new SuccessDataResult<ChatLevel>(data);
        }

        public IDataResult<SpecificChatLevelDto> GetChatLevelByMatch(int id)
        {
            var data = _chatLevelDal.GetChatLevelByMatchId(id);

            return new SuccessDataResult<SpecificChatLevelDto>(data);
        }
    }
}

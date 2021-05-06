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

        async public Task<IDataResult<List<ChatLevel>>> GetAll()
        {
            List<ChatLevel> data;
            try
            {
                data = await _chatLevelDal.GetAllAsync();
            }
            catch (Exception)
            {

                return new ErrorDataResult<List<ChatLevel>>();
            }
            return new SuccessDataResult<List<ChatLevel>>(data);
        }

        async public Task<IDataResult<List<ChatLevel>>> GetByChatLevel(string level)
        {
            List<ChatLevel> data;
            try
            {
                data = await _chatLevelDal.GetAllAsync(c => c.Level ==level);
            }
            catch (Exception)
            {

                return new ErrorDataResult<List<ChatLevel>>();
            }
            return new SuccessDataResult<List<ChatLevel>>(data);
        }

        async public Task<IDataResult<ChatLevel>> GetByChatLevelId(int id)
        {
            ChatLevel data;
            try
            {
                data = await _chatLevelDal.GetAsync(c => c.ChatLevelId == id);
            }
            catch (Exception)
            {

                return new ErrorDataResult<ChatLevel>();
            }
            return new SuccessDataResult<ChatLevel>(data);
        }

        public IDataResult<SpecificChatLevelDto> GetChatLevelByMatch(int id)
        {
            SpecificChatLevelDto data;
            try
            {
                data = _chatLevelDal.GetChatLevelByMatchId(id);
            }
            catch (Exception)
            {

                return new ErrorDataResult<SpecificChatLevelDto>();
            }
            return new SuccessDataResult<SpecificChatLevelDto>(data);
        }
    }
}

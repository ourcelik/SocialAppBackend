using Business.Abstract;
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
    class ChatLevelManager : IChatLevelService
    {
        IChatLevelDal _chatLevelDal;
        public ChatLevelManager(IChatLevelDal chatLevelDal)
        {
            _chatLevelDal = chatLevelDal;
        }

        async public Task<IDataResult<List<Chat_level>>> GetAll()
        {
            List<Chat_level> data;
            try
            {
                data = await _chatLevelDal.GetAllAsync();
            }
            catch (Exception)
            {

                return new ErrorDataResult<List<Chat_level>>();
            }
            return new SuccessDataResult<List<Chat_level>>(data);
        }

        async public Task<IDataResult<List<Chat_level>>> GetByChatLevel(string level)
        {
            List<Chat_level> data;
            try
            {
                data = await _chatLevelDal.GetAllAsync(c => c.Level ==level);
            }
            catch (Exception)
            {

                return new ErrorDataResult<List<Chat_level>>();
            }
            return new SuccessDataResult<List<Chat_level>>(data);
        }

        async public Task<IDataResult<Chat_level>> GetByChatLevelId(int id)
        {
            Chat_level data;
            try
            {
                data = await _chatLevelDal.GetAsync(c => c.ChatId == id);
            }
            catch (Exception)
            {

                return new ErrorDataResult<Chat_level>();
            }
            return new SuccessDataResult<Chat_level>(data);
        }

        public IDataResult<SpecificChatLevel> GetChatLevelByMatch(int id)
        {
            SpecificChatLevel data;
            try
            {
                data = _chatLevelDal.GetChatLevelByMatchId(id);
            }
            catch (Exception)
            {

                return new ErrorDataResult<SpecificChatLevel>();
            }
            return new SuccessDataResult<SpecificChatLevel>(data);
        }
    }
}

using Core.Utilities.Results;
using Entities.Concrete;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ILikedService
    {
        public Task<IDataResult<List<Likes>>> GetAll();
        public Task<IDataResult<List<Likes>>> GetAllByReceiverId(int receiverId);
        public Task<IDataResult<List<Likes>>> GetAllBySenderId(int senderId);
        public Task<IDataResult<List<Likes>>> GetAllByKind(int kindId);
        public Task<IDataResult<Likes>> GetById(int id);

    }
}

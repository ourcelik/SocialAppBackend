using Core.Utilities.Results;
using Entities.Concrete;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ILikedService
    {
        public Task<IDataResult<List<Liked>>> GetAll();
        public Task<IDataResult<List<Liked>>> GetAllByReceiverId(int receiverId);
        public Task<IDataResult<List<Liked>>> GetAllBySenderId(int senderId);
        public Task<IDataResult<List<Liked>>> GetAllByKind(int kindId);
        public Task<IDataResult<Liked>> GetById(int id);

    }
}

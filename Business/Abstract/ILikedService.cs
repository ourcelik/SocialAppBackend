using Core.Utilities.Results;
using Entities.Concrete;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ILikedService
    {
        public Task<IDataResult<List<Likes>>> GetAllAsync();
        public Task<IDataResult<List<Likes>>> GetAllByReceiverIdAsync(int receiverId);
        public Task<IDataResult<List<Likes>>> GetAllBySenderIdAsync(int senderId);
        public Task<IDataResult<List<Likes>>> GetAllByKindIdAsync(int kindId);
        public Task<IDataResult<Likes>> GetByIdAsync(int id);

    }
}

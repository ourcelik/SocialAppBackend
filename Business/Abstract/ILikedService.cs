using Core.Utilities.Results;
using Entities.Concrete;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ILikedService
    {
        public Task<IDataResult<List<Like>>> GetAllAsync();
        public Task<IDataResult<List<Like>>> GetAllByReceiverIdAsync(int receiverId);
        public Task<IDataResult<List<Like>>> GetAllBySenderIdAsync(int senderId);
        public Task<IDataResult<List<Like>>> GetAllByKindIdAsync(int kindId);
        public Task<IDataResult<Like>> GetByIdAsync(int id);

    }
}

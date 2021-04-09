using Core.Utilities.Results;
using Entities.Concrete;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IPhotoService
    {
        public Task<IDataResult<List<Photo>>> GetPhotosByUserId(int userId);
        public Task<IDataResult<Photo>> GetPhotoByPhotoId(int id);
    }
}

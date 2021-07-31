using Core.Utilities.Results;
using Entities.Concrete;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IPhotoService
    {
        public Task<IDataResult<List<Photo>>> GetPhotosByProfileId(int profileId);
        public Task<IDataResult<Photo>> GetPhotoByPhotoId(int id);
        public Task<IDataResult<List<Photo>>> GetAllPhotos();
        public Task<IDataResult<int>> UpdatePhotoAsync(Photo photo);
    }
}

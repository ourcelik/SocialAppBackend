using Core.Utilities.Results;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IPhotoService
    {
        public IDataResult<List<Photo>> GetPhotosByUserId(int id);
    }
}

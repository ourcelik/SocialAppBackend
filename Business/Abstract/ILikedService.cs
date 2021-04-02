using Core.Utilities.Results;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface ILikedService
    {
        public IDataResult<List<Liked>> GetAll();
        public IDataResult<List<Liked>> GetAllByReceiverId();
        public IDataResult<List<Liked>> GetAllBySenderId();
        public IDataResult<List<Liked>> GetAllByKind();
    }
}

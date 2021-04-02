using Core.Utilities.Results;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface ILikeKindService
    {
        public IDataResult<List<Like_Kind>> GetLikeKinds();

    }
}

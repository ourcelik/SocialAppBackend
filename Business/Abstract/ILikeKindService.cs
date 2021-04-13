using Core.Utilities.Results;
using Entities.Concrete;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ILikeKindService
    {
        public Task<IDataResult<List<LikeKind>>> GetLikeKinds();

    }
}

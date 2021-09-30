using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IPostLikeService
    {
        public Task<IDataResult<List<PostLike>>> GetAllLikesByPostId(int id);
        public Task<IDataResult<int>> GetLikeBack(PostLike postLike);
        public Task<IDataResult<int>> SendLikeToPost(PostLike postLike);
        public Task<IDataResult<bool>> IsAlreadyLikedPost(IsAlreadyLikedPostDto isAlreadyLikedPost);

    }
   
}

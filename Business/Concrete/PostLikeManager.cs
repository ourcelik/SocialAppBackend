using Business.Abstract;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class PostLikeManager : IPostLikeService
    {
        readonly IPostLikeDal _postLikeDal;

        public PostLikeManager(IPostLikeDal postLikeDal)
        {
            _postLikeDal = postLikeDal;
        }


        public async Task<IDataResult<List<PostLike>>> GetAllLikesByPostId(int id)
        {
            var data = await _postLikeDal.GetAllAsync(pl => pl.PostLikeId == id);

            return new SuccessDataResult<List<PostLike>>(data);
        }

        [FillUserIdAspect(parameterIndex: 0, propName: "LikeUserId")]
        public async Task<IDataResult<int>> GetLikeBack(PostLike postLike)
        {
            var userLiked = await GetUserLike(postLike.RelatedPostId, postLike.LikeUserId);
            if (userLiked?.Data == null)
            {
                return new ErrorDataResult<int>(default(int));
            }

            await _postLikeDal.DeleteAsync(userLiked.Data);

            return new SuccessDataResult<int>(1);
        }

        [FillUserIdAspect(parameterIndex: 0, propName: "LikeUserId")]
        public async Task<IDataResult<int>> SendLikeToPost(PostLike postLike)
        {
            var isAlreadyLiked = await IsAlreadyLikedPost(new IsAlreadyLikedPostDto() { PostId = postLike.RelatedPostId, UserId = postLike.LikeUserId });
            if (!isAlreadyLiked.Data)
            {
                return new ErrorDataResult<int>(default(int));
            }

            var data = await _postLikeDal.AddAsync(postLike);

            return new SuccessDataResult<int>(data.PostLikeId);
        }

        [FillUserIdAspect(parameterIndex: 0, propName: "UserId")]
        public async Task<IDataResult<bool>> IsAlreadyLikedPost(IsAlreadyLikedPostDto isAlreadyLikedPostDto)
        {
            var data = await GetUserLike(isAlreadyLikedPostDto.PostId, isAlreadyLikedPostDto.UserId);


            if (data?.Data is not null)
            {
                return new SuccessDataResult<bool>(false);
            }
            return new SuccessDataResult<bool>(true);
        }

        private async Task<IDataResult<PostLike>> GetUserLike(int postId,int userId)
        {
            var data = await _postLikeDal.GetAsync(p => p.RelatedPostId == postId && p.LikeUserId == userId);

            return new SuccessDataResult<PostLike>(data);
        }
    }
}

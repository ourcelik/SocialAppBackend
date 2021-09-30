using Business.Abstract;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Entities.DTOs.OutputDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class PostManager : IPostService
    {
        readonly IPostDal _postDal;

        readonly IRoomMemberService _roomMemberService;

        readonly IPostInfoService _postInfoService;

        public PostManager(IPostDal postDal,IPostInfoService postInfoService,IRoomMemberService roomMemberService)
        {
            _postDal = postDal;
            _postInfoService = postInfoService;
            _roomMemberService = roomMemberService;
        }

        [FillUserIdAspect(parameterIndex: 0, propName: "CreatorId")]
        [TransactionScopeAspect]
        public async Task<IDataResult<int>> CreatePost(Post post)
        {
            if (await IsSubscribed(post.RelatedRoomId))
            {
                var InfoId = await _postInfoService.CreatePostInfoForPost(_postInfoService.GetDefaultPostInfoStructure());
                post.RelatedInfoId = InfoId;
                var data = await _postDal.AddAsync(post);
                return new SuccessDataResult<int>(data.PostId);

            }
            return new ErrorDataResult<int>(0);

        }

        private async Task<bool> IsSubscribed(int roomId)
        {
            var IsSubscribed = await _roomMemberService.IsAlreadySubscribed(new IsSubscribedRoomMemberDto() { RoomId = roomId });

            return IsSubscribed.Data.IsSubscribed;
        }


        public async Task<IDataResult<int>> DeletePost(int id)
        {
            var post = await GetPostById(id);
            post.IsDeleted = true;
            await _postDal.UpdateAsync(post);

            return new SuccessDataResult<int>(1);
        }

        public async Task<IDataResult<List<Post>>> GetAllPost()
        {
            var data = await _postDal.GetAllAsync(p => p.IsDeleted !=true);

            return new SuccessDataResult<List<Post>>(data);
        }

        public async Task<IDataResult<List<Post>>> GetPostByRoomId(int id)
        {
            var data = await _postDal.GetAllAsync(p => p.RelatedRoomId == id && p.IsDeleted != true && p.ShowPost != false);

            return new SuccessDataResult<List<Post>>(data);
        }

        //[FillUserIdAspect(parameterIndex: 0, propName: "CreatorId")]
        public async Task<IDataResult<int>> UpdatePost(UpdatePostDto updatePost)
        {
            var post = await GetPostById(updatePost.PostId);

            post.ContentMessage = updatePost.ContentMessage;
            post.ShowPost = updatePost.ShowPost;

            var data = await _postDal.UpdateAsync(post);

            return new SuccessDataResult<int>(data.PostId);
        }

        private async Task<Post> GetPostById(int id)
        {
            var post = await _postDal.GetAsync(p => p.PostId == id);

            return post;
        }

        public IDataResult<List<PostDetailsWithPostInfoDto>> GetPostWithPostInfoByRoomId(int id)
        {
            var data = _postDal.GetPostsWithInfoByRelatedRoomId(id);

            return new SuccessDataResult<List<PostDetailsWithPostInfoDto>>(data);
        }
    }
}

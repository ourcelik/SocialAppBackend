using AutoMapper;
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

        readonly IMapper _mapper;
        public PostManager(IPostDal postDal,
            IPostInfoService postInfoService,
            IRoomMemberService roomMemberService,
            IMapper mapper
            
            )
        {
            _postDal = postDal;
            _postInfoService = postInfoService;
            _roomMemberService = roomMemberService;
            _mapper = mapper;
        }

        [FillUserIdAspect(parameterIndex: 0, propName: "CreatorId")]
        [TransactionScopeAspect]
        public async Task<IDataResult<int>> CreatePost(Post post)
        {
            if (await IsSubscribed(post.RelatedRoomId))
            {
                var InfoId = await _postInfoService.CreatePostInfoForPost(_postInfoService.GetDefaultPostInfoStructure());
                post.RelatedInfoId = InfoId;
                post.CreatedTime = DateTime.Now;
                post.ShowPost = true;
                post.IsDeleted = false;
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

        [FillUserIdAspect(parameterIndex:0,propName:"UserId")]
        public async Task<IDataResult<int>> DeletePost(DeletePostDto deletePostDto)
        {
            var Permission = await PostBelongsToThisUser(_mapper.Map<PostBelongsToDto>(deletePostDto));

            
            if (Permission.isBelongsToThisUser)
            {
                var post = Permission.post;
                post.IsDeleted = true;
                await _postDal.UpdateAsync(post);

                return new SuccessDataResult<int>(1);

            }
            return new ErrorDataResult<int>(default(int));
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

        [FillUserIdAspect(parameterIndex: 0, propName: "CreatorId")]
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

        [FillUserIdAspect(parameterIndex:0,propName:"UserId")]
        public async Task<IDataResult<bool>> PostCanBeDeletedByThisUser(PostBelongsToDto postBelongsToDto)
        {
            var canBeDeleted = (await PostBelongsToThisUser(postBelongsToDto)).isBelongsToThisUser;

            if (canBeDeleted)
            {
                return new SuccessDataResult<bool>(true);
            }
            return new SuccessDataResult<bool>(false);

        }

        private async Task<(bool isBelongsToThisUser, Post post)> PostBelongsToThisUser(PostBelongsToDto belongsToDto)
        {
            var post = await GetPostById(belongsToDto.PostId);

            if (post.CreatorId == belongsToDto.UserId)
            {
                return (true,post);
            }
            return (false, post);

        }

        public async Task<IDataResult<Post>> GetPostByPostId(int id)
        {
            var post = await _postDal.GetAsync(p => p.PostId == id);

            return new SuccessDataResult<Post>(post);
        }

        public IDataResult<int> GetPostOwnerByPostId(int id)
        {
           return new SuccessDataResult<int>(_postDal.GetPostOwnerByPostId(id));
        }
    }
}

using Business.Abstract;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class PostCommentManager : IPostCommentService
    {
        readonly IPostCommentDal _postCommentDal;
        readonly IUserNotificationService _userNotificationService;
        readonly IPostService _postService;

        public PostCommentManager(IPostCommentDal postCommentDal
            ,IUserNotificationService userNotificationService
            ,IPostService postService
            )
        {
            _postCommentDal = postCommentDal;
            _userNotificationService = userNotificationService;
            _postService = postService;
        }

        [FillUserIdAspect(parameterIndex:0,propName:"CreatorId")]
        [TransactionScopeAspect]
        public async Task<IDataResult<int>> CreateComment(PostComment postComment)
        {
           
            var data = await _postCommentDal.AddAsync(AddDefaultProps(postComment));
            CommentNotificationDto commentNotificationDto = new()
            {
                ComeFromUserId = postComment.CreatorId,
                CommentId = data.PostCommentId,
                PostId = postComment.RelatedPostId,
                NotifyUserId = _postService.GetPostOwnerByPostId(postComment.RelatedPostId).Data
            };
            await _userNotificationService.AddCommentNotification(commentNotificationDto);

            return new SuccessDataResult<int>(data.CreatorId);
        }

        [FillUserIdAspect(parameterIndex: 0, propName: "CreatorId")]
        public async Task<IDataResult<int>> DeleteComment(PostComment postComment)
        {
            await _postCommentDal.DeleteAsync(postComment);

            return new SuccessDataResult<int>(1);
        }
        

        public async Task<IDataResult<List<PostComment>>> GetAllComments()
        {
            var data = await _postCommentDal.GetAllAsync();

            return new SuccessDataResult<List<PostComment>>(data);
        }

        public async Task<IDataResult<List<PostComment>>> GetCommentsByPostId(int id)
        {
            var data = await _postCommentDal.GetAllAsync(pc => pc.RelatedPostId == id);

            return new SuccessDataResult<List<PostComment>>(data);
        }

        [FillUserIdAspect(parameterIndex: 0, propName: "CreatorId")]
        public async Task<IDataResult<int>> UpdateComment(PostComment postComment)
        {
            var data = await _postCommentDal.UpdateAsync(postComment);

            return new SuccessDataResult<int>(data.PostCommentId);
        }

        public async Task<IDataResult<PostComment>> GetCommentById(int id)
        {
            var data = await _postCommentDal.GetAsync(c => c.PostCommentId == id);

            return new SuccessDataResult<PostComment>(data);
        }

        private PostComment AddDefaultProps(PostComment postComment)
        {
            postComment.ShowComment = true;

            return postComment;
        }

        
    }
}

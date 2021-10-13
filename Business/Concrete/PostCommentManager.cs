using Business.Abstract;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class PostCommentManager : IPostCommentService
    {
        readonly IPostCommentDal _postCommentDal;

        public PostCommentManager(IPostCommentDal postCommentDal)
        {
            _postCommentDal = postCommentDal;
        }

        [FillUserIdAspect(parameterIndex:0,propName:"CreatorId")]
        public async Task<IDataResult<int>> CreateComment(PostComment postComment)
        {
           
            var data = await _postCommentDal.AddAsync(AddDefaultProps(postComment));

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

        private PostComment AddDefaultProps(PostComment postComment)
        {
            postComment.ShowComment = true;

            return postComment;
        }
    }
}

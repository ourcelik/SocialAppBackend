using Core.Utilities.Results;
using Entities.Concrete;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IPostCommentService
    {
        public Task<IDataResult<List<PostComment>>> GetAllComments();
        public Task<IDataResult<List<PostComment>>> GetCommentsByPostId(int id);
        public Task<IDataResult<int>> UpdateComment(PostComment postComment);
        public Task<IDataResult<int>> DeleteComment(PostComment postComment);
        public Task<IDataResult<int>> CreateComment(PostComment postComment);
        public Task<IDataResult<PostComment>> GetCommentById(int id);

    }
   
}

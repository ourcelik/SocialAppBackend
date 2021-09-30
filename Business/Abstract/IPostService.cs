using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using Entities.DTOs.OutputDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IPostService
    {
        public Task<IDataResult<List<Post>>> GetAllPost();
        public Task<IDataResult<List<Post>>> GetPostByRoomId(int id);
        public IDataResult<List<PostDetailsWithPostInfoDto>> GetPostWithPostInfoByRoomId(int id);
        public Task<IDataResult<int>> UpdatePost(UpdatePostDto updatePost);
        public Task<IDataResult<int>> DeletePost(int id);
        public Task<IDataResult<int>> CreatePost(Post post);

    }
   
}

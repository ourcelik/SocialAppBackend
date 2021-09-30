using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs.OutputDtos;
using System.Collections.Generic;

namespace DataAccess.Abstract
{
    public interface IPostDal : IEntityRepository<Post>
    {
        public List<PostDetailsWithPostInfoDto> GetPostsWithInfoByRelatedRoomId(int id);
       
    }

}

using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs.OutputDtos;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfPostDal : EfEntityRepositoryBase<Post, SocialNetworkContext>, IPostDal
    {
        public List<PostDetailsWithPostInfoDto> GetPostsWithInfoByRelatedRoomId(int id)
        {
            List<PostDetailsWithPostInfoDto> postDetailsList;
            using (SocialNetworkContext context = new())
            {
                var data = from p in context.Posts
                           join pl in context.PostInfos
                           on p.RelatedInfoId equals pl.PostInfoId
                           where p.RelatedRoomId == id && p.IsDeleted == false && p.ShowPost == true
                           select new PostDetailsWithPostInfoDto()
                           {
                               RelatedInfoId = p.RelatedInfoId,
                               RelatedRoomId = p.RelatedRoomId,
                               PostId = p.PostId,
                               CommentCount = pl.CommentCount,
                               ContentMessage = p.ContentMessage,
                               CreatedTime = p.CreatedTime,
                               CreatorId = p.CreatorId,
                               LikeCount = pl.LikeCount,
                               StartedContactCount = pl.StartedContactCount
                           };

                 postDetailsList = data.ToList();
            }

            return postDetailsList;
        }
    }
}

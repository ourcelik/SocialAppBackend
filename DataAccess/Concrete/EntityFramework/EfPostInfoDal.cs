using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfPostInfoDal : EfEntityRepositoryBase<PostInfo, SocialNetworkContext>, IPostInfoDal
    {
        public PostInfo GetPostInfoByPostId(int id)
        {
            using (SocialNetworkContext context = new())
            {
                var data = from pi in context.PostInfos
                           join p in context.Posts
                           on pi.PostInfoId equals p.RelatedInfoId
                           where p.PostId == id
                           select new PostInfo
                           {
                               CommentCount = pi.CommentCount,
                               LikeCount = pi.LikeCount,
                               PostInfoId = pi.PostInfoId,
                               StartedContactCount = pi.StartedContactCount
                           };

                return data.FirstOrDefault();
            }

        }
    }
}

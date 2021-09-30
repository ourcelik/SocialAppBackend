using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class PostInfoManager : IPostInfoService
    {
        readonly IPostInfoDal _postInfoDal;

        public PostInfoManager(IPostInfoDal postInfoDal)
        {
            _postInfoDal = postInfoDal;
        }

        public IDataResult<PostInfo> GetPostInfoByPostId(int id)
        {
            var data = _postInfoDal.GetPostInfoByPostId(id);

            return new SuccessDataResult<PostInfo>(data);
        }

        public async Task<int> CreatePostInfoForPost(PostInfo postInfo)
        {
            var data = await _postInfoDal.AddAsync(postInfo);

            return data.PostInfoId;
        }

        public PostInfo GetDefaultPostInfoStructure()
        {
            return new PostInfo()
            {
                CommentCount = 0,
                LikeCount = 0,
                StartedContactCount = 0,
            };
        }
    }
}

using Core.Utilities.Results;
using Entities.Concrete;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IPostInfoService
    {
        public IDataResult<PostInfo> GetPostInfoByPostId(int id);
        public Task<int> CreatePostInfoForPost(PostInfo postInfo);
        public PostInfo GetDefaultPostInfoStructure();
    }
   
}

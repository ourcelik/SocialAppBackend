using Core.DataAccess;
using Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface IPostInfoDal : IEntityRepository<PostInfo>
    {
        public PostInfo GetPostInfoByPostId(int id); 
    }

}

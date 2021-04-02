using Core.DataAccess.EntityFramework;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfChat_LevelDal : EfEntityRepositoryBase<Chat_level, SocialNetworkContext>,IChatLevelDal
    {

    }
}

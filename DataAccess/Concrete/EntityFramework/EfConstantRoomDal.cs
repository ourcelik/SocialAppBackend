using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfConstantRoomDal : EfEntityRepositoryBase<Constant_room, SocialNetworkContext>,IConstantRoomDal
    {

    }
}

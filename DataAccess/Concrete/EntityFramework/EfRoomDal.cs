﻿using Core.DataAccess.EntityFramework;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRoomDal : EfEntityRepositoryBase<Room, SocialNetworkContext>,IRoomDal
    {

    }
}

﻿using Core.DataAccess.EntityFramework;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfLikeKindDal : EfEntityRepositoryBase<Like_Kind, SocialNetworkContext>,ILike_KindDal
    {

    }
}

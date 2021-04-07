using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfPreferDal : EfEntityRepositoryBase<Prefer, SocialNetworkContext>,IPreferDal
    {

    }
}

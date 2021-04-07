using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfProfileAnswerDal : EfEntityRepositoryBase<Profile_Answer, SocialNetworkContext>,IProfileAnswerDal
    {

    }
}

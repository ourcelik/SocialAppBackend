using Core.DataAccess.EntityFramework;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfProfileAnswerDal : EfEntityRepositoryBase<Profile_Answer, SocialNetworkContext>,IProfileAnswerDal
    {

    }
}

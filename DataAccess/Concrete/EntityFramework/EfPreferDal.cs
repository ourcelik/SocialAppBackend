using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfPreferDal : EfEntityRepositoryBase<Prefer, SocialNetworkContext>, IPreferDal
    {
        public Prefer getPreferSetingsByUserId(int id)
        {
            using SocialNetworkContext context = new();
            var prefer = from p in context.Prefers
                       join profile in context.Profiles
                       on p.PreferId equals profile.PreferId
                       join user in context.Users
                       on profile.ProfileId equals user.ProfileId
                       where user.UserId == id
                       select new Prefer
                       {
                           PreferId = p.PreferId,
                           AppVoice = p.AppVoice,
                           Autoplay = p.Autoplay,
                           LastSeen = p.LastSeen,
                           GenderPreferId = p.GenderPreferId,
                           MaxAge = p.MaxAge,
                           MaxDistance = p.MaxDistance,
                           MinAge = p.MinAge,
                           ShowMe = p.ShowMe,
                           Universal = p.Universal
                       };
            var result = prefer.SingleOrDefault();
            context?.Dispose();
            return result;
        }
    }
}

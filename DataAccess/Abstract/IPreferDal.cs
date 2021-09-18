using Core.DataAccess;
using Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface IPreferDal : IEntityRepository<Prefer>
    {
        public Prefer getPreferSetingsByUserId(int id);
    }

}

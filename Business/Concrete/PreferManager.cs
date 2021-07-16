using Business.Abstract;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class PreferManager : IPreferService
    {
        readonly IPreferDal _preferDal;
        public PreferManager(IPreferDal preferDal)
        {
            _preferDal = preferDal;
        }

        [CacheAspect]
        async public Task<IDataResult<Prefer>> GetPreferSettingById(int id)
        {
            var data = await _preferDal.GetAsync(p => p.PreferId == id);

            return new SuccessDataResult<Prefer>(data);
        }
    }
}

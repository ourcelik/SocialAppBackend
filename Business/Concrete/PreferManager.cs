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
        [PerformanceAspect(5)]
        async public Task<IDataResult<List<Prefer>>> GetPreferSettingById(int id)
        {
            var data = await _preferDal.GetAllAsync(p => p.PreferId == id);
            return new SuccessDataResult<List<Prefer>>(data);
        }
    }
}

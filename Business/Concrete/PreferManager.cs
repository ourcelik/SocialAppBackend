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

        public async Task<IDataResult<int>> AddPreferSetting(Prefer prefer)
        {
           var data =  await _preferDal.AddAsync(prefer);
            return new SuccessDataResult<int>(data.PreferId);
        }

        [CacheAspect]
        async public Task<IDataResult<Prefer>> GetPreferSettingById(int id)
        {
            var data = await _preferDal.GetAsync(p => p.PreferId == id);

            return new SuccessDataResult<Prefer>(data);
        }
    }
}

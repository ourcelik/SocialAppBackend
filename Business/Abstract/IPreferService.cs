using Core.Utilities.Results;
using Entities.Concrete;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IPreferService
    {
        public Task<IDataResult<Prefer>> GetPreferSettingById(int id);
        public Task<IDataResult<int>> AddPreferSetting(Prefer prefer);
    }
}

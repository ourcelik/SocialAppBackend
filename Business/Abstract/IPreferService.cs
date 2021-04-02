using Core.Utilities.Results;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IPreferService
    {
        public IDataResult<List<Prefer>> GetPreferSettingById(int id);
    }
}

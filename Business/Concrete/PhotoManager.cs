using Business.Abstract;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class PhotoManager : IPhotoService
    {
        readonly IPhotoDal _photoDal;
        public PhotoManager(IPhotoDal photoDal)
        {
            _photoDal = photoDal;
        }

        async public Task<IDataResult<Photo>> GetPhotoByPhotoId(int id)
        {
            var data = await _photoDal.GetAsync(p => p.PhotoId == id);

            return new SuccessDataResult<Photo>(data);
        }
        async public Task<IDataResult<List<Photo>>> GetAllPhotos()
        {
            var data = await _photoDal.GetAllAsync();

            return new SuccessDataResult<List<Photo>>(data);
        }

        [CacheAspect]
        async public Task<IDataResult<List<Photo>>> GetPhotosByProfileId(int profileId)
        {
            var data = await _photoDal.GetAllAsync(p => p.ProfileId == profileId);

            return new SuccessDataResult<List<Photo>>(data);
        }

        public async Task<IDataResult<int>> UpdatePhotoAsync(Photo photo)
        {
            var data = await _photoDal.UpdateAsync(photo);
            return new SuccessDataResult<int>(data.PhotoId);
        }
    }
}

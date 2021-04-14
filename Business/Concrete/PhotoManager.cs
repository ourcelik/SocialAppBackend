﻿using Business.Abstract;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
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

        [CacheAspect]
        [PerformanceAspect(5)]
        async public Task<IDataResult<Photo>> GetPhotoByPhotoId(int id)
        {
            var data = await _photoDal.GetAsync(p => p.PhotoId == id);
            return new SuccessDataResult<Photo>(data);
        }

        [CacheAspect]
        [PerformanceAspect(5)]
        async public Task<IDataResult<List<Photo>>> GetPhotosByUserId(int userId)
        {
            var data = await _photoDal.GetAllAsync(p => p.ProfileId == userId);
            return new SuccessDataResult<List<Photo>>(data);
        }
    }
}

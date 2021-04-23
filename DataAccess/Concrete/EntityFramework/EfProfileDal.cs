﻿using Core.DataAccess.EntityFramework;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfProfileDal : EfEntityRepositoryBase<Profile, SocialNetworkContext>, IProfileDal
    {
        public UserProfileDto GetUserProfileByMail(string mail)
        {
            using SocialNetworkContext context = new();
            var profile = from u in context.Users
                          join p in context.Profiles
                          on u.ProfileId equals p.ProfileId
                          where u.Mail == mail
                          select new UserProfileDto
                          {
                              UserId = u.UserId,
                              ProfileId = p.ProfileId,
                              Name = p.Name,
                              Birthdate = p.Birthdate,
                              Height = p.Height,
                              Mail = u.Mail,
                              Surname = p.Surname,
                              ProfilePhotoId = p.ProfilePhotoId,
                              RelationStatus = p.RelationshipStatus,
                              TelNo = u.TelNo,
                              Username = u.Username,
                              Weight = p.Weight
                          };
            context?.DisposeAsync();
            return profile.SingleOrDefault();
        }

        public UserProfileDto GetUserProfileByTelNo(string telNo)
        {
            using SocialNetworkContext context = new();
            var profile = from u in context.Users
                          join p in context.Profiles
                          on u.ProfileId equals p.ProfileId
                          where u.TelNo == telNo
                          select new UserProfileDto
                          {
                              UserId = u.UserId,
                              ProfileId = p.ProfileId,
                              Name = p.Name,
                              Birthdate = p.Birthdate,
                              Height = p.Height,
                              Mail = u.Mail,
                              Surname = p.Surname,
                              ProfilePhotoId = p.ProfilePhotoId,
                              RelationStatus = p.RelationshipStatus,
                              TelNo = u.TelNo,
                              Username = u.Username,
                              Weight = p.Weight
                          };
            context?.DisposeAsync();
            return profile.SingleOrDefault();
        }

        public UserProfileDto GetUserProfileByUsername(string userName)
        {
            throw new NotImplementedException();
        }
    }
    
}

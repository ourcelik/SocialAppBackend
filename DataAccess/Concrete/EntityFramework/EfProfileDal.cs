using Core.DataAccess.EntityFramework;
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
                          join ph in context.Photos
                          on p.ProfilePhotoId equals ph.PhotoId
                          join g in context.Genders
                          on p.GenderId equals g.GenderId
                          where u.Mail == mail
                          select new UserProfileDto
                          {
                              Name = p.Name,
                              Birthdate = p.Birthdate,
                              Height = p.Height,
                              Mail = u.Mail,
                              Surname = p.Surname,
                              RelationStatus = p.RelationshipStatus,
                              TelNo = u.TelNo,
                              Username = u.Username,
                              Weight = p.Weight,
                              ProfilePhotoUrl = ph.Url,
                              GenderId = p.GenderId,
                              Gender = g._Gender,
                              ProfileId = p.ProfileId,
                              UserId = u.UserId,
                              ProfilePhotoId = ph.PhotoId
                              
                          };
            var Result = profile.SingleOrDefault();
            
            context?.DisposeAsync();
            return Result;
        }

        public UserProfileDto GetUserProfileByTelNo(string telNo)
        {
            using SocialNetworkContext context = new();
            var profile = from u in context.Users
                          join p in context.Profiles
                          on u.ProfileId equals p.ProfileId
                          join ph in context.Photos
                          on p.ProfilePhotoId equals ph.PhotoId
                          join g in context.Genders
                          on p.GenderId equals g.GenderId
                          where u.TelNo == telNo
                          select new UserProfileDto
                          {
                              Name = p.Name,
                              Birthdate = p.Birthdate,
                              Height = p.Height,
                              Mail = u.Mail,
                              Surname = p.Surname,
                              RelationStatus = p.RelationshipStatus,
                              TelNo = u.TelNo,
                              Username = u.Username,
                              Weight = p.Weight,
                              ProfilePhotoUrl = ph.Url,
                              GenderId = p.GenderId,
                              Gender = g._Gender,
                              ProfileId = p.ProfileId,
                              UserId = u.UserId,
                              ProfilePhotoId = ph.PhotoId
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

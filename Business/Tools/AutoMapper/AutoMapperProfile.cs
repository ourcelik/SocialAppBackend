using AutoMapper;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Tools.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Entities.Concrete.Profile, UserUpdateProfileDto>();
            CreateMap<UserUpdateProfileDto, Entities.Concrete.Profile>()
                .ForMember(p => p.ProfileId, dto => dto.Ignore())
                .ForMember(p => p.NotificationId, dto => dto.Ignore())
                .ForMember(p => p.PreferId, dto => dto.Ignore())
                .ForMember(p => p.ProfilePhotoId, dto => dto.Ignore());
            CreateMap<DeletePostDto, PostBelongsToDto>();
            CreateMap<PostBelongsToDto,DeletePostDto>();
        }
    }
}

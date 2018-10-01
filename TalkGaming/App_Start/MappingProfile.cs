using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TalkGaming.Dtos;
using TalkGaming.Models;

namespace TalkGaming.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Forum, ForumDto>();
            CreateMap<ForumDto, Forum>();
        }
    }
}
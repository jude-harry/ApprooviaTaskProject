using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features
{
    public  class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<TaskProject,TaskDto>().ReverseMap();
            CreateMap<TaskProject,TaskBaseDto>().ForMember(des => des.TaskID, opt => opt.MapFrom(src => src.Id)).ReverseMap();
        }
    }
}

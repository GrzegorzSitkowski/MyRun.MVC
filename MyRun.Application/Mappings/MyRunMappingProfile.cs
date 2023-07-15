using AutoMapper;
using MyRun.Application.Race;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRun.Application.Mappings
{
    public class MyRunMappingProfile : Profile
    {
        public MyRunMappingProfile()
        {
            CreateMap<RaceDto, Domain.Entities.Race>().ReverseMap();
        }
    }
}

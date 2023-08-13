using AutoMapper;
using MyRun.Application.ApplicationUser;
using MyRun.Application.Race;
using MyRun.Application.Race.Commands.EditRace;
using MyRun.Application.RunnerProfile;
using MyRun.Application.RunnerProfile.Commands.EditRunnerProfile;
using MyRun.Application.Workout;
using MyRun.Application.Workout.Commands.EditWorkout;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRun.Application.Mappings
{
    public class MyRunMappingProfile : Profile
    {
        public MyRunMappingProfile(IUserContext userContext)
        {
            var user = userContext.GetCurrentUser();

            CreateMap<RaceDto, Domain.Entities.Race>().ReverseMap();
            CreateMap<Domain.Entities.Race, RaceDto>().
                ForMember(dto => dto.IsEditable, opt => opt.MapFrom(src => user != null && src.CreatedById == user.Id));

            CreateMap<WorkoutDto, Domain.Entities.Workout>().ReverseMap();
            CreateMap<Domain.Entities.Workout, WorkoutDto>().
                ForMember(dto => dto.IsEditable, opt => opt.MapFrom(src => user != null && src.CreatedById == user.Id));

            CreateMap<RunnerProfileDto, Domain.Entities.RunnerProfile>().ReverseMap();
            CreateMap<Domain.Entities.RunnerProfile, RunnerProfileDto>().
                ForMember(dto => dto.IsEditable, opt => opt.MapFrom(src => user != null && src.CreatedById == user.Id));

            CreateMap<RaceDto, EditRaceCommand>();
            CreateMap<WorkoutDto, EditWorkoutCommand>();
            CreateMap<RunnerProfileDto, EditRunnerProfileCommand>();
        }
    }
}

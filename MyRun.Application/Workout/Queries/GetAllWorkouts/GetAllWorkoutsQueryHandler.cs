using AutoMapper;
using MediatR;
using MyRun.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRun.Application.Workout.Queries.GetAllWorkouts
{
    public class GetAllWorkoutsQueryHandler : IRequestHandler<GetAllWorkoutsQuery, IEnumerable<WorkoutDto>>
    {
        private readonly IWorkoutRepository _workoutRepository;
        private readonly IMapper _mapper;

        public GetAllWorkoutsQueryHandler(IWorkoutRepository workoutRepository, IMapper mapper)
        {
            _workoutRepository = workoutRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<WorkoutDto>> Handle(GetAllWorkoutsQuery request, CancellationToken cancellationToken)
        {
            var workouts = await _workoutRepository.GetAll();
            var dtos = _mapper.Map<IEnumerable<WorkoutDto>>(workouts);

            return dtos;
        }
    }
}

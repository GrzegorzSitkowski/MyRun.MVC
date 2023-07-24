using AutoMapper;
using MediatR;
using MyRun.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRun.Application.Workout.Queries.GetWorkoutDetails
{
    public class GetWorokutDetailsQueryHandler : IRequestHandler<GetWorkoutDetailsQuery, WorkoutDto>
    {
        private readonly IWorkoutRepository _workoutRepository;
        private readonly IMapper _mapper;

        public GetWorokutDetailsQueryHandler(IWorkoutRepository workoutRepository, IMapper mapper)
        {
            _workoutRepository = workoutRepository;
            _mapper = mapper;
        }

        public async Task<WorkoutDto> Handle(GetWorkoutDetailsQuery request, CancellationToken cancellationToken)
        {
            var workout = await _workoutRepository.GetById(request._idWorkout);

            var dto = _mapper.Map<WorkoutDto>(workout);

            return dto;
        }
    }
}

using AutoMapper;
using MediatR;
using MyRun.Application.ApplicationUser;
using MyRun.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRun.Application.Workout.Commands.CreateWorkout
{
    public class CreateWorkoutCommandHandler : IRequestHandler<CreateWorkoutCommand>
    {
        private readonly IWorkoutRepository _workoutRepository;
        private readonly IMapper _mapper;
        private readonly IUserContext _userContext;

        public CreateWorkoutCommandHandler(IWorkoutRepository workoutRepository, IMapper mapper, IUserContext userContext)
        {
            _workoutRepository = workoutRepository;
            _mapper = mapper;
            _userContext = userContext;
        }
        public async Task<Unit> Handle(CreateWorkoutCommand request, CancellationToken cancellationToken)
        {
            var workout = _mapper.Map<Domain.Entities.Workout>(request);

            workout.CreatedById = _userContext.GetCurrentUser().Id;

            await _workoutRepository.Create(workout);

            return Unit.Value;
        }
    }
}

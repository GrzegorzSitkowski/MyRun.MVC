using AutoMapper;
using MediatR;
using MyRun.Application.ApplicationUser;
using MyRun.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRun.Application.Workout.Commands.EditWorkout
{
    public class EditWorkoutCommandHandler : IRequestHandler<EditWorkoutCommand>
    {
        private readonly IWorkoutRepository _workoutRepository;
        private readonly IMapper _mapper;
        private readonly IUserContext _userContext;

        public EditWorkoutCommandHandler(IWorkoutRepository workoutRepository, IMapper mapper, IUserContext userContext)
        {
            _workoutRepository = workoutRepository;
            _mapper = mapper;
            _userContext = userContext;
        }

        public async Task<Unit> Handle(EditWorkoutCommand request, CancellationToken cancellationToken)
        {
            var workout = await _workoutRepository.GetById(request.Id!);

            var user = _userContext.GetCurrentUser();
            var isEditable = user != null && workout.CreatedById == user.Id;

            if (!isEditable)
            {
                return Unit.Value;
            }

            workout.Distance = request.Distance;
            workout.Result = request.Result;
            workout.AveragePace = request.AveragePace;
            workout.MaxPace = request.MaxPace;
            workout.Date = request.Date;
            workout.Calories = request.Calories;
            workout.Note = request.Note;

            await _workoutRepository.Commit();

            return Unit.Value;
        }
    }
}

using AutoMapper;
using MediatR;
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

        public EditWorkoutCommandHandler(IWorkoutRepository workoutRepository, IMapper mapper)
        {
            _workoutRepository = workoutRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(EditWorkoutCommand request, CancellationToken cancellationToken)
        {
            var workout = await _workoutRepository.GetById(request.Id!);

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

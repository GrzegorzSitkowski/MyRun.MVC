using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRun.Application.Workout.Commands.CreateWorkout
{
    public class CreateWorkoutCommand : WorkoutDto, IRequest
    {
    }
}

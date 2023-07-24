using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRun.Application.Workout.Queries.GetWorkoutDetails
{
    public class GetWorkoutDetailsQuery : IRequest<WorkoutDto>
    {
        public int _idWorkout { get; set; }

        public GetWorkoutDetailsQuery(int idWorkout)
        {
            _idWorkout = idWorkout;
        }
    }
}

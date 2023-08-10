using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRun.Application.Workout.Commands.EditWorkout
{
    public class EditWorkoutCommandValidator : AbstractValidator<EditWorkoutCommand>
    {
        public EditWorkoutCommandValidator()
        {
            RuleFor(c => c.Distance).NotEmpty();
            RuleFor(c => c.Result).MaximumLength(10);
            RuleFor(c => c.AveragePace).MaximumLength(10);
            RuleFor(c => c.MaxPace).MaximumLength(10);
            RuleFor(c => c.Calories).MaximumLength(15);
            RuleFor(c => c.Note).MaximumLength(50);
        }
    }
}

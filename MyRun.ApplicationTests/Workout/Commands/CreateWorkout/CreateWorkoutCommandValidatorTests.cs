using Xunit;
using MyRun.Application.Workout.Commands.CreateWorkout;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation.TestHelper;

namespace MyRun.Application.Workout.Commands.CreateWorkout.Tests
{
    public class CreateWorkoutCommandValidatorTests
    {
        [Fact()]
        public void Validate_WithValidCommand_ShouldNotHaveValidationError()
        {
            //average
            var validator = new CreateWorkoutCommandValidator();
            var command = new CreateWorkoutCommand()
            {
                Distance = "10",
                Result = "00:47:42",
                AveragePace = "04:51",
                MaxPace = "04:10",
                Calories = "410",
                Note = "Good."
            };
            //average

            //act
            var result = validator.TestValidate(command);
            //act

            //assert
            result.ShouldNotHaveAnyValidationErrors();
            //assert
        }

        [Fact()]
        public void Validate_WithInvalidCommand_ShoulHaveValidationErrors()
        {
            //average
            var validator = new CreateWorkoutCommandValidator();
            var command = new CreateWorkoutCommand()
            {
                Distance = "",
                Result = "00:47:42000000000000000000",
                AveragePace = "04:510000000000000000000",
                MaxPace = "04:1000000000000000000000000",
                Calories = "410",
                Note = "Good."
            };
            //average

            //act
            var result = validator.TestValidate(command);
            //act

            //assert
            result.ShouldHaveValidationErrorFor(c => c.Distance);
            result.ShouldHaveValidationErrorFor(c => c.Result);
            result.ShouldHaveValidationErrorFor(c => c.AveragePace);
            result.ShouldHaveValidationErrorFor(c => c.MaxPace);
            //assert
        }
    }
}
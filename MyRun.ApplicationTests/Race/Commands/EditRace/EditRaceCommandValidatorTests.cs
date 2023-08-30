using Xunit;
using MyRun.Application.Race.Commands.EditRace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyRun.Application.Race.Commands.CreateRace;
using FluentValidation.TestHelper;

namespace MyRun.Application.Race.Commands.EditRace.Tests
{
    public class EditRaceCommandValidatorTests
    {
        [Fact()]
        public void Validate_WithValidCommand_ShouldNotHaveValidationError()
        {
            //arange

            var validator = new EditRaceCommandValidator();
            var command = new EditRaceCommand()
            {
                Name = "Poznan Halfmarathon",
                Country = "Poland",
                City = "Poznan",
                Number = "5100",
                Place = "8474",
                Distance = "21.047",
                AveragePace = "05:30",
                Result = "01:54:23",
                Note = "Good weather"
            };
            //arange

            //act
            var result = validator.TestValidate(command);
            //act

            //assert
            result.ShouldNotHaveAnyValidationErrors();
            //assert
        }

        [Fact()]
        public void Validate_WithInvalidCommand_ShouldHaveValidationErrors()
        {
            //arange

            var validator = new EditRaceCommandValidator();
            var command = new EditRaceCommand()
            {
                Name = "",
                Country = "Poland",
                City = "Poznan",
                Number = "5100",
                Place = "8474",
                Distance = "",
                AveragePace = "05:30",
                Result = "01:54:23",
                Note = "Good weather"
            };
            //arange

            //act
            var result = validator.TestValidate(command);
            //act

            //assert
            result.ShouldHaveValidationErrorFor(c => c.Name);
            result.ShouldHaveValidationErrorFor(c => c.Distance);
            //assert
        }
    }
}
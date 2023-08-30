using Xunit;
using MyRun.Application.RunnerProfile.Commands.CreateRunnerProfile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation.TestHelper;

namespace MyRun.Application.RunnerProfile.Commands.CreateRunnerProfile.Tests
{
    public class CreateRunnerProfileCommandValidatorTests
    {
        [Fact()]
        public void Validate_WithValidCommand_ShouldNotHaveValidationError()
        {
            //average
            var validator = new CreateRunnerProfileCommandValidator();
            var command = new CreateRunnerProfileCommand()
            {
                FullName = "Grzegorz Sitkowski",
                Weight = "80",
                Pb5k = "00:20:42",
                Pb10k = "00:44:18",
                PbHalfMarathon = "01:42:47",
                PbFullMarathon = "03:51:01",
                About = "About",
                Accomplishments = "Run!"
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
            var validator = new CreateRunnerProfileCommandValidator();
            var command = new CreateRunnerProfileCommand()
            {
                FullName = "",
                Weight = "8000000",
                Pb5k = "00:20:42",
                Pb10k = "00:44:18",
                PbHalfMarathon = "01:42:47",
                PbFullMarathon = "03:51:01",
                About = "About",
                Accomplishments = "Run!"
            };
            //average

            //act
            var result = validator.TestValidate(command);
            //act

            //assert
            result.ShouldHaveValidationErrorFor(c  => c.FullName);
            result.ShouldHaveValidationErrorFor(c => c.Weight);
            //assert
        }
    }
}
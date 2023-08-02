using FluentValidation;
using FluentValidation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRun.Application.RunnerProfile.Commands.CreateRunnerProfile
{
    public  class CreateRunnerProfileCommandValidator : AbstractValidator<CreateRunnerProfileCommand>
    {
        public CreateRunnerProfileCommandValidator()
        {
            RuleFor(c => c.FullName).NotEmpty().MaximumLength(30);
            RuleFor(c => c.Weight).MaximumLength(4);
            RuleFor(c => c.Pb5k).MaximumLength(15);
            RuleFor(c => c.Pb10k).MaximumLength(15);
            RuleFor(c => c.PbHalfMarathon).MaximumLength(15);
            RuleFor(c => c.PbFullMarathon).MaximumLength(15);
            RuleFor(c => c.About).MaximumLength(25);
            RuleFor(c => c.Accomplishments).MaximumLength(25);
        }
    }
}

using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRun.Application.Race
{
    public class RaceDtoValidator : AbstractValidator<RaceDto>
    {
        public RaceDtoValidator()
        {
            RuleFor(c => c.Name).NotEmpty().MinimumLength(2).MaximumLength(30); 
            RuleFor(c => c.Country).MaximumLength(20); 
            RuleFor(c => c.City).MaximumLength(20); 
            RuleFor(c => c.Number).MaximumLength(10); 
            RuleFor(c => c.Place).MaximumLength(10); 
            RuleFor(c => c.Distance).NotEmpty().MaximumLength(20); 
            RuleFor(c => c.AveragePace).MaximumLength(5); 
            RuleFor(c => c.Result).MaximumLength(15);
            RuleFor(c => c.Note).MaximumLength(30);
        }
    }
}

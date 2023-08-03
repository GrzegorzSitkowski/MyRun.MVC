using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRun.Application.RunnerProfile.Commands.EditRunnerProfile
{
    public class EditRunnerProfileCommand : RunnerProfileDto, IRequest
    {
    }
}

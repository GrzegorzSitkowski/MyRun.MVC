using AutoMapper;
using MediatR;
using MyRun.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRun.Application.RunnerProfile.Commands.EditRunnerProfile
{
    public class EditRunnerProfileCommandHandler : IRequestHandler<EditRunnerProfileCommand>
    {
        private readonly IRunnerProfileRepository _repository;
        private readonly IMapper _mapper;

        public EditRunnerProfileCommandHandler(IRunnerProfileRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper; 
        }

        public async Task<Unit> Handle(EditRunnerProfileCommand request, CancellationToken cancellationToken)
        {
            var runnerProfile = await _repository.GetProfile(request.Id!);

            runnerProfile.FullName = request.FullName;
            runnerProfile.Age = request.Age;
            runnerProfile.Weight = request.Weight;
            runnerProfile.Pb5k = request.Pb5k;
            runnerProfile.Pb10k = request.Pb10k;
            runnerProfile.PbHalfMarathon = request.PbHalfMarathon;
            runnerProfile.PbFullMarathon = request.PbFullMarathon;
            runnerProfile.About = request.About;
            runnerProfile.PhotoUrl = request.PhotoUrl;
            runnerProfile.Accomplishments = request.Accomplishments;

            await _repository.Commit();

            return Unit.Value;
        }
    }
}

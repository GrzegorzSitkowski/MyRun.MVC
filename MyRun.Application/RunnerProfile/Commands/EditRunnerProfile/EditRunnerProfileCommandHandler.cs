using AutoMapper;
using MediatR;
using MyRun.Application.ApplicationUser;
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
        private readonly IUserContext _userContext;

        public EditRunnerProfileCommandHandler(IRunnerProfileRepository repository, IMapper mapper, IUserContext userContext)
        {
            _repository = repository;
            _mapper = mapper;
            _userContext = userContext;
        }

        public async Task<Unit> Handle(EditRunnerProfileCommand request, CancellationToken cancellationToken)
        {
            var runnerProfile = await _repository.GetProfile(request.Id!);

            var user = _userContext.GetCurrentUser();
            var isEditable = user != null && runnerProfile.CreatedById == user.Id;

            if (!isEditable)
            {
                return Unit.Value;
            }

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

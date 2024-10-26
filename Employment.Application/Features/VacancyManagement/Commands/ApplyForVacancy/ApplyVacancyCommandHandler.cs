using Employment.Application.Abstractions.Messaging;
using Employment.Application.Authentication;
using Employment.Domain.Repositories;
using Employment.Domain.Shared;

namespace Employment.Application.Features.VacancyManagement.Commands.ApplyForVacancy
{
    internal class ApplyVacancyCommandHandler : ICommandHandler<ApplyVacancyCommand>
    {
        private readonly IGenericRepository<Domain.Entities.Application> _applicationRepo;
        private readonly ITokenExtractor _tokenExtractor;

        public ApplyVacancyCommandHandler(
            IGenericRepository<Domain.Entities.Application> applicationRepo,
            ITokenExtractor tokenExtractor)
        {
            _applicationRepo = applicationRepo;
            _tokenExtractor = tokenExtractor;
        }

        public async Task<ResponseModel> Handle(ApplyVacancyCommand request, CancellationToken cancellationToken)
        {
            var applicantId = _tokenExtractor.GetOtherId();

            var application = new Domain.Entities.Application(request.VacancyId, applicantId);

            await _applicationRepo.AddAsync(application);

            await _applicationRepo.SaveChangesAsync(cancellationToken);

            return ResponseModel.Success();
        }
    }
}

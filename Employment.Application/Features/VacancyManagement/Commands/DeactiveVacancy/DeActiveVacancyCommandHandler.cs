using Employment.Application.Abstractions.Messaging;
using Employment.Domain.Entities;
using Employment.Domain.Repositories;
using Employment.Domain.Shared;

namespace Employment.Application.Features.VacancyManagement.Commands.DeActiveVacancy
{
    internal class DeActiveVacancyCommandCommandHandler : ICommandHandler<DeActiveVacancyCommand>
    {
        private readonly IGenericRepository<Vacancy> _vacancyRepo;

        public DeActiveVacancyCommandCommandHandler(IGenericRepository<Vacancy> vacancyRepo)
        {
            _vacancyRepo = vacancyRepo;
        }

        public async Task<ResponseModel> Handle(DeActiveVacancyCommand request, CancellationToken cancellationToken)
        {
            var vacancy = await _vacancyRepo.GetByIdAsync(request.Id, cancellationToken);

            vacancy!.SetStatus(Domain.Enums.VacancyStatus.Inactive);

            _vacancyRepo.Update(vacancy!);
            await _vacancyRepo.SaveChangesAsync(cancellationToken);

            return ResponseModel.Success();
        }
    }
}

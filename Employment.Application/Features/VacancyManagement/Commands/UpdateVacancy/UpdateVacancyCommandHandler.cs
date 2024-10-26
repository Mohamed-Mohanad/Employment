using Employment.Application.Abstractions.Messaging;
using Employment.Domain.Entities;
using Employment.Domain.Repositories;
using Employment.Domain.Shared;

namespace Employment.Application.Features.VacancyManagement.Commands.UpdateVacancy
{
    internal class UpdateVacancyCommandHandler : ICommandHandler<UpdateVacancyCommand>
    {
        private readonly IGenericRepository<Vacancy> _vacancyRepo;

        public UpdateVacancyCommandHandler(IGenericRepository<Vacancy> vacancyRepo)
        {
            _vacancyRepo = vacancyRepo;
        }

        public async Task<ResponseModel> Handle(UpdateVacancyCommand request, CancellationToken cancellationToken)
        {
            var vacancy = await _vacancyRepo.GetByIdAsync(request.Id, cancellationToken);

            UpdateVacancy(vacancy!, request);

            _vacancyRepo.Update(vacancy!);
            await _vacancyRepo.SaveChangesAsync(cancellationToken);

            return ResponseModel.Success();
        }

        private void UpdateVacancy(Vacancy vacancy, UpdateVacancyCommand request)
        {
            if (!string.IsNullOrWhiteSpace(request.Title))
            {
                vacancy.SetTitle(request.Title);
            }

            if (!string.IsNullOrWhiteSpace(request.Description))
            {
                vacancy.SetDescription(request.Description);
            }

            if (!string.IsNullOrWhiteSpace(request.Location))
            {
                vacancy.SetLocation(request.Location);
            }

            if (request.MaxApplications.HasValue)
            {
                vacancy.SetMaxApplications(request.MaxApplications.Value);
            }

            if (request.ExpiryDate.HasValue)
            {
                vacancy.SetExpiryDate(request.ExpiryDate.Value);
            }
        }
    }
}

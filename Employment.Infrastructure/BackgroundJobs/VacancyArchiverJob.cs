using Employment.Application.Shared.Specifications;
using Employment.Domain.Entities;
using Employment.Domain.Enums;
using Employment.Domain.Repositories;
using Microsoft.Extensions.Logging;

namespace Employment.Infrastructure.BackgroundJobs
{
    public class VacancyArchiverJob
    {
        private readonly ILogger<VacancyArchiverJob> _logger;
        private readonly IGenericRepository<Vacancy> _vacancyRepository;

        public VacancyArchiverJob(
            ILogger<VacancyArchiverJob> logger,
            IGenericRepository<Vacancy> vacancyRepository)
        {
            _logger = logger;
            _vacancyRepository = vacancyRepository;
        }

        public async Task ArchiveExpiredOrMaxApplicationsVacancies()
        {
            (var vacancies, var count) = _vacancyRepository.GetWithSpec(new GetExpiredOrMaxApplicationsVacanciesSpecification());

            if (count == 0)
                return;

            foreach (var vacancy in vacancies)
            {
                vacancy.SetStatus(VacancyStatus.Archived);
                _vacancyRepository.Update(vacancy);

                _logger.LogInformation("Archived Vacancy ID: {VacancyId} - Title: {VacancyTitle}", vacancy.Id, vacancy.Title);
            }

            await _vacancyRepository.SaveChangesAsync();
        }
    }
}

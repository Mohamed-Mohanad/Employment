using Employment.Domain.Entities;
using Employment.Domain.Enums;
using Employment.Domain.Specification;

namespace Employment.Application.Shared.Specifications
{
    public class GetExpiredOrMaxApplicationsVacanciesSpecification : Specification<Vacancy>
    {
        public GetExpiredOrMaxApplicationsVacanciesSpecification()
        {
            var currentDateTime = DateTime.UtcNow;

            AddCriteria(x => x.Status != VacancyStatus.Archived);
            AddCriteria(x => x.ExpiryDate <= currentDateTime || x.Applications!.Count >= x.MaxApplications);
        }
    }
}

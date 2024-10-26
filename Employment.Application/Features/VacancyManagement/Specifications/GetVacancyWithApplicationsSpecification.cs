using Employment.Domain.Entities;
using Employment.Domain.Specification;

namespace Employment.Application.Features.VacancyManagement.Specifications
{
    internal class GetVacancyWithApplicationsSpecification : Specification<Vacancy>
    {
        public GetVacancyWithApplicationsSpecification(Guid id)
        {
            AddCriteria(x => x.Id == id);

            AddInclude($"{nameof(Vacancy.Applications)}");
        }
    }
}

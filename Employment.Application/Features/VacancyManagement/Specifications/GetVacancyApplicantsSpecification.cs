using Employment.Application.Features.VacancyManagement.Queries.GetVacancyApplicants;
using Employment.Domain.Entities;
using Employment.Domain.Specification;

namespace Employment.Application.Features.VacancyManagement.Specifications
{
    internal class GetVacancyApplicantsSpecification : Specification<Domain.Entities.Application>
    {
        public GetVacancyApplicantsSpecification(GetVacancyApplicantsQuery query)
        {
            AddCriteria(x => x.VacancyId == query.VacancyId);

            AddInclude($"{nameof(Domain.Entities.Application.Applicant)}.{nameof(Applicant.User)}");

            ApplyPaging(query.PageSize, query.PageIndex);
        }
    }
}

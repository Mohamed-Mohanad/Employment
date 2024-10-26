using Employment.Application.Features.VacancyManagement.Queries.ApplicantSearchVacancies;
using Employment.Application.Features.VacancyManagement.Queries.GetVacancies;
using Employment.Domain.Entities;
using Employment.Domain.Enums;
using Employment.Domain.Specification;

namespace Employment.Application.Features.VacancyManagement.Specifications
{
    internal class GetVacanciesSearchSpecification : Specification<Vacancy>
    {
        public GetVacanciesSearchSpecification(GetVacanciesQuery query)
        {
            if (!string.IsNullOrWhiteSpace(query.Search))
                AddCriteria(
                    x => x.Title.Trim().ToLower().Contains(query.Search.Trim().ToLower())
                        || x.Description.Trim().ToLower().Contains(query.Search.Trim().ToLower()));

            ApplyPaging(query.PageSize, query.PageIndex);
        }

        public GetVacanciesSearchSpecification(ApplicantSearchVacanciesQuery query)
        {
            if (!string.IsNullOrWhiteSpace(query.Search))
                AddCriteria(
                    x => x.Title.Trim().ToLower().Contains(query.Search.Trim().ToLower())
                        || x.Description.Trim().ToLower().Contains(query.Search.Trim().ToLower()));

            AddCriteria(x => x.Status == VacancyStatus.Active);

            ApplyPaging(query.PageSize, query.PageIndex);
        }
    }
}

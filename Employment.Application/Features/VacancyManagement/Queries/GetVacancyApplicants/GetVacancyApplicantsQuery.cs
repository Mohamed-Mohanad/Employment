using Employment.Application.Abstractions.Messaging;
using Employment.Application.Features.VacancyManagement.DTOs;

namespace Employment.Application.Features.VacancyManagement.Queries.GetVacancyApplicants
{
    public class GetVacancyApplicantsQuery : IQuery<IReadOnlyList<ApplicantDto>>
    {
        public Guid VacancyId { get; set; }
        public int PageIndex { get; set; } = 1;
        public int PageSize { get; set; } = 20;
    }
}

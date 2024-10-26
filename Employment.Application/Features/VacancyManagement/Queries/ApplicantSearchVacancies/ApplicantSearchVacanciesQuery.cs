using Employment.Application.Abstractions.Messaging;
using Employment.Application.Features.VacancyManagement.DTOs;

namespace Employment.Application.Features.VacancyManagement.Queries.ApplicantSearchVacancies
{
    public class ApplicantSearchVacanciesQuery : IQuery<IReadOnlyList<VacancyDto>>
    {
        public string? Search { get; set; }
        public int PageIndex { get; set; } = 1;
        public int PageSize { get; set; } = 20;
    }
}

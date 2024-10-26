using Employment.Application.Abstractions.Messaging;

namespace Employment.Application.Features.VacancyManagement.Commands.ApplyForVacancy
{
    public class ApplyVacancyCommand : ICommand
    {
        public Guid VacancyId { get; set; }
    }
}

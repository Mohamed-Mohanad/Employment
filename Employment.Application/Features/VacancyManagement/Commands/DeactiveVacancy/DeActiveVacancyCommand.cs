using Employment.Application.Abstractions.Messaging;

namespace Employment.Application.Features.VacancyManagement.Commands.DeActiveVacancy
{
    public class DeActiveVacancyCommand : ICommand
    {
        public Guid Id { get; set; }
    }
}

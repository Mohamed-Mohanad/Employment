using Employment.Application.Abstractions.Messaging;

namespace Employment.Application.Features.VacancyManagement.Commands.DeleteVacancy
{
    public class DeleteVacancyCommand : ICommand
    {
        public Guid Id { get; set; }
    }
}

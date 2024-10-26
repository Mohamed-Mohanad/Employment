using Employment.Application.Abstractions.Messaging;

namespace Employment.Application.Features.VacancyManagement.Commands.UpdateVacancy
{
    public class UpdateVacancyCommand : ICommand
    {
        public Guid Id { get; set; }
        public string? Title { get; set; } = null!;
        public string? Description { get; set; } = null!;
        public string? Location { get; set; } = null!;
        public int? MaxApplications { get; set; }
        public DateTime? ExpiryDate { get; set; }
    }
}

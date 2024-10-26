using Employment.Domain.Enums;

namespace Employment.Application.Features.VacancyManagement.DTOs
{
    public class VacancyDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Location { get; set; } = null!;
        public int MaxApplications { get; set; }
        public DateTime ExpiryDate { get; set; }
        public VacancyStatus Status { get; set; }
        public DateTime CreatedOnUtc { get; set; }
        public DateTime? ModifiedOnUtc { get; set; }
    }
}

namespace Employment.Application.Features.VacancyManagement.DTOs
{
    public class ApplicantDto
    {
        public Guid Id { get; set; }
        public string FullName { get; set; } = null!;
        public string UserName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string ResumeUrl { get; set; } = null!;
        public DateTime CreatedOnUtc { get; set; }
        public DateTime? ModifiedOnUtc { get; set; }
    }
}

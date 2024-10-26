namespace Employment.Application.Shared.DTOs
{
    internal class ApplicantApplyVacancyCachingDto
    {
        public Guid Id { get; set; }
        public DateTime CreatedOnUTC { get; set; } = DateTime.UtcNow;
    }
}

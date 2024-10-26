namespace Employment.Application.Features.ApplicantProfileManagement.Queries.Login.DTOs
{
    public class BaseLoginResponseDto
    {
        public string FullName { get; set; } = null!;
        public string UserName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
    }
}

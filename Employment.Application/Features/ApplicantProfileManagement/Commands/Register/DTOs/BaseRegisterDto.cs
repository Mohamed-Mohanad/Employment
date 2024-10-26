namespace Employment.Application.Features.ApplicantProfileManagement.Commands.Register.DTOs
{
    public class BaseRegisterDto
    {
        public string FullName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string UserName { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}

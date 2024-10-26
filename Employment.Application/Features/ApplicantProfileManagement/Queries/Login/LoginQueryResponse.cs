using Employment.Application.Features.ApplicantProfileManagement.Queries.Login.DTOs;

namespace Employment.Application.Features.ApplicantProfileManagement.Queries.Login
{
    public class LoginQueryResponse
    {
        public string Token { get; set; } = null!;
        public string Role { get; set; } = null!;
        public ApplicantLoginTypeResponseDto? Applicant { get; set; }
        public EmployerLoginTypeResponseDto? Employer { get; set; }
    }
}

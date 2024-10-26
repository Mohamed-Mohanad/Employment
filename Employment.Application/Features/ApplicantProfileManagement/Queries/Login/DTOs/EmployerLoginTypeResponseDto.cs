using Employment.Application.Shared.DTOs;

namespace Employment.Application.Features.ApplicantProfileManagement.Queries.Login.DTOs
{
    public class EmployerLoginTypeResponseDto : BaseLoginResponseDto
    {
        public CompanyDto Company { get; set; } = null!;
    }
}

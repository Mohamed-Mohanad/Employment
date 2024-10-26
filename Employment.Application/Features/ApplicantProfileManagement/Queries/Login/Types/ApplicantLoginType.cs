using Employment.Application.Authentication;
using Employment.Application.Features.ApplicantProfileManagement.Queries.Login.Abstract;
using Employment.Application.Features.ApplicantProfileManagement.Queries.Login.DTOs;
using Employment.Application.Features.ApplicantProfileManagement.Specifications;
using Employment.Domain.Entities;
using Employment.Domain.Enums;
using Employment.Domain.Repositories;
using Employment.Domain.Shared;
using Microsoft.AspNetCore.Identity;

namespace Employment.Application.Features.ApplicantProfileManagement.Queries.Login.Types
{
    internal class ApplicantLoginType : BaseLogin
    {
        private readonly IGenericRepository<Applicant> _applicantRepo;

        public ApplicantLoginType(
            IMapper mapper,
            UserManager<User> userManager,
            IJwtProvider jwtProvider,
            IGenericRepository<Applicant> applicantRepo)
            : base(mapper, userManager, jwtProvider)
        {
            _applicantRepo = applicantRepo;
        }

        public override LoginType Type { get; set; } = LoginType.Applicant;

        public override async Task<ResponseModel<LoginQueryResponse>> Login(LoginQuery query)
        {
            var user = await _userManager.FindByEmailAsync(query.Email);
            var applicant = _applicantRepo.GetEntityWithSpec(new GetApplicantByUserIdSpecification(user!.Id));

            var jwtToken = await _jwtProvider.Generate(user!, applicant!.Id);

            var response = new LoginQueryResponse()
            {
                Token = jwtToken,
                Role = Role.Applicant.ToString(),
                Applicant = new ApplicantLoginTypeResponseDto()
                {
                    FullName = user!.FullName,
                    Email = user.Email!,
                    PhoneNumber = user.Email!,
                    UserName = user.UserName!,
                    ResumeUrl = applicant!.ResumeUrl!,
                }
            };

            return ResponseModel.Success(response);
        }
    }
}

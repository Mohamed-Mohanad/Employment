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
    internal class EmployerLoginType : BaseLogin
    {
        private readonly IGenericRepository<Employer> _employerRepo;

        public EmployerLoginType(
            IMapper mapper,
            UserManager<User> userManager,
            IJwtProvider jwtProvider,
            IGenericRepository<Employer> employerRepo)
            : base(mapper, userManager, jwtProvider)
        {
            _employerRepo = employerRepo;
        }

        public override LoginType Type { get; set; } = LoginType.Employer;

        public override async Task<ResponseModel<LoginQueryResponse>> Login(LoginQuery query)
        {
            var user = await _userManager.FindByEmailAsync(query.Email);
            var employer = _employerRepo.GetEntityWithSpec(new GetEmployerByUserIdSpecification(user!.Id));

            var jwtToken = await _jwtProvider.Generate(user!, employer!.Id);

            var response = new LoginQueryResponse()
            {
                Token = jwtToken,
                Role = Role.Employer.ToString(),
                Employer = new EmployerLoginTypeResponseDto()
                {
                    FullName = user!.FullName,
                    Email = user.Email!,
                    PhoneNumber = user.Email!,
                    UserName = user.UserName!,
                    Company = new Shared.DTOs.CompanyDto()
                    {
                        Id = employer.Company!.Id,
                        Name = employer.Company!.Name,
                    },
                }
            };

            return ResponseModel.Success(response);
        }
    }
}

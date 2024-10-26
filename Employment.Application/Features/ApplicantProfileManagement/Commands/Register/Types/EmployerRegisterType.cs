using Employment.Application.Features.ApplicantProfileManagement.Specifications;
using Employment.Application.Features.Auth.Commands.Register;
using Employment.Application.Features.Auth.Commands.Register.Abstract;
using Employment.Domain.Entities;
using Employment.Domain.Enums;
using Employment.Domain.Repositories;
using Employment.Domain.Shared;
using Microsoft.AspNetCore.Identity;

namespace Employment.Application.Features.ApplicantProfileManagement.Commands.Register.Types
{
    internal class EmployerRegisterType : BaseRegister
    {
        public override RegisterType Type { get; set; } = RegisterType.Employer;

        public EmployerRegisterType(
            IMapper mapper,
            IUnitOfWork unitOfWork,
            UserManager<User> userManager)
            : base(
                  mapper,
                  unitOfWork,
                  userManager)
        {
        }

        public override async Task<ResponseModel> Register(RegisterCommand command)
        {
            var user = _mapper.Map<User>(command.Employer!);

            var hashedPassword = _userManager.PasswordHasher.HashPassword(user, command.Employer!.Password);
            user.PasswordHash = hashedPassword;
            user.NormalizedEmail = user.Email!.ToUpper();
            user.NormalizedUserName = user.UserName!.ToUpper();

            await _unitOfWork.Repository<User>().AddAsync(user);

            var role = _unitOfWork.Repository<IdentityRole<Guid>>().GetEntityWithSpec(new GetRoleByNameSpecification(Role.Employer.ToString()));
            var userRole = new IdentityUserRole<Guid>()
            {
                RoleId = role!.Id,
                UserId = user.Id,
            };
            await _unitOfWork.Repository<IdentityUserRole<Guid>>().AddAsync(userRole);

            var employer = new Employer(user.Id, command.Employer!.CompanyId);
            await _unitOfWork.Repository<Employer>().AddAsync(employer);

            await _unitOfWork.CompleteAsync();

            return ResponseModel.Success();
        }
    }
}

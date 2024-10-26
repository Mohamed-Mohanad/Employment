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
    internal class ApplicantRegisterType : BaseRegister
    {
        public override RegisterType Type { get; set; } = RegisterType.Applicant;

        public ApplicantRegisterType(
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
            var user = _mapper.Map<User>(command.Applicant!);
            var hashedPassword = _userManager.PasswordHasher.HashPassword(user, command.Applicant!.Password);
            user.PasswordHash = hashedPassword;
            user.NormalizedEmail = user.Email!.ToUpper();
            user.NormalizedUserName = user.UserName!.ToUpper();

            await _unitOfWork.Repository<User>().AddAsync(user);

            var role = _unitOfWork.Repository<IdentityRole<Guid>>().GetEntityWithSpec(new GetRoleByNameSpecification(Role.Applicant.ToString()));
            var userRole = new IdentityUserRole<Guid>()
            {
                RoleId = role!.Id,
                UserId = user.Id,
            };
            await _unitOfWork.Repository<IdentityUserRole<Guid>>().AddAsync(userRole);

            var applicant = new Applicant(user.Id, command.Applicant!.ResumeUrl);
            await _unitOfWork.Repository<Applicant>().AddAsync(applicant);

            await _unitOfWork.CompleteAsync();

            return ResponseModel.Success();
        }
    }
}

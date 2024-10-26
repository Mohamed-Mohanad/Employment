using Employment.Application.Abstractions.Messaging;
using Employment.Application.Features.ApplicantProfileManagement.Commands.Register.DTOs;
using Employment.Application.Features.Auth.Commands.Register.Abstract;

namespace Employment.Application.Features.Auth.Commands.Register
{
    public sealed class RegisterCommand : ICommand
    {
        public ApplicantRegisterDto? Applicant { get; private set; }
        public EmployerRegisterDto? Employer { get; private set; }
        public RegisterType Type { get; private set; }

        public RegisterCommand(ApplicantRegisterDto applicant)
        {
            this.Applicant = applicant;
            this.Type = RegisterType.Applicant;
        }

        public RegisterCommand(EmployerRegisterDto employer)
        {
            this.Employer = employer;
            this.Type = RegisterType.Employer;
        }

        public RegisterCommand()
        {

        }
    }

}

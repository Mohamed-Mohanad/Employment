using Employment.Application.Features.ApplicantProfileManagement.Commands.Register.DTOs;
using Employment.Application.Features.ApplicantProfileManagement.Queries.Login;
using Employment.Application.Features.ApplicantProfileManagement.Queries.Login.Abstract;
using Employment.Application.Features.Auth.Commands.Register;
using Employment.Presentation.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Employment.Presentation.Controllers
{
    [Route("api/[controller]")]
    public sealed class AuthController : ApiController
    {
        public AuthController(ISender sender) : base(sender)
        {
        }

        [HttpGet("login-employer")]
        public async Task<IActionResult> RegisterEmployer([FromQuery] LoginQuery query)
        {
            query.SetType(LoginType.Employer);
            var result = await Sender.Send(query);
            return HandleResult(result);
        }

        [HttpGet("login-applicant")]
        public async Task<IActionResult> RegisterApplicant([FromQuery] LoginQuery query)
        {
            query.SetType(LoginType.Applicant);
            var result = await Sender.Send(query);
            return HandleResult(result);
        }

        [HttpPost("register-applicant")]
        public async Task<IActionResult> RegisterCustomer(ApplicantRegisterDto registerDto)
        {
            var command = new RegisterCommand(registerDto);
            var result = await Sender.Send(command);
            return HandleResult(result);
        }

        [HttpPost("register-employer")]
        public async Task<IActionResult> RegisterEmployer(EmployerRegisterDto registerDto)
        {
            var command = new RegisterCommand(registerDto);
            var result = await Sender.Send(command);
            return HandleResult(result);
        }
    }
}

using Employment.Application.Features.VacancyManagement.Commands.ApplyForVacancy;
using Employment.Application.Features.VacancyManagement.Commands.CreateVacancy;
using Employment.Application.Features.VacancyManagement.Commands.DeActiveVacancy;
using Employment.Application.Features.VacancyManagement.Commands.DeleteVacancy;
using Employment.Application.Features.VacancyManagement.Commands.UpdateVacancy;
using Employment.Application.Features.VacancyManagement.Queries.ApplicantSearchVacancies;
using Employment.Application.Features.VacancyManagement.Queries.GetVacancies;
using Employment.Application.Features.VacancyManagement.Queries.GetVacancyApplicants;
using Employment.Presentation.Abstractions;
using Employment.Presentation.ActionFilters;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Employment.Presentation.Controllers
{
    [Route("api/[controller]")]
    public sealed class VacancyController : ApiController
    {
        public VacancyController(ISender sender) : base(sender)
        {
        }

        [HttpPost("create")]
        [Authorize(Roles = "Employer")]
        public async Task<IActionResult> Create([FromBody] CreateVacancyCommand command)
        {
            var result = await Sender.Send(command);
            return HandleResult(result);
        }

        [CachedAttribute(60)]
        [HttpGet("employer-get-vacancies")]
        [Authorize(Roles = "Employer")]
        public async Task<IActionResult> Get([FromQuery] GetVacanciesQuery query)
        {
            var result = await Sender.Send(query);
            return HandleResult(result);
        }

        [CachedAttribute(60)]
        [HttpGet("applicant-get-vacancies")]
        [Authorize(Roles = "Applicant")]
        public async Task<IActionResult> Get([FromQuery] ApplicantSearchVacanciesQuery query)
        {
            var result = await Sender.Send(query);
            return HandleResult(result);
        }

        [CachedAttribute(30)]
        [HttpGet("get-applicants")]
        [Authorize(Roles = "Employer")]
        public async Task<IActionResult> GetApplicants([FromQuery] GetVacancyApplicantsQuery query)
        {
            var result = await Sender.Send(query);
            return HandleResult(result);
        }

        [HttpPost("apply-vacancy")]
        [Authorize(Roles = "Applicant")]
        public async Task<IActionResult> ApplyVacancy(ApplyVacancyCommand command)
        {
            var result = await Sender.Send(command);
            return HandleResult(result);
        }

        [HttpPut("update")]
        [Authorize(Roles = "Employer")]
        public async Task<IActionResult> Update(UpdateVacancyCommand command)
        {
            var result = await Sender.Send(command);
            return HandleResult(result);
        }

        [HttpPut("deActive")]
        [Authorize(Roles = "Employer")]
        public async Task<IActionResult> DeActive(DeActiveVacancyCommand command)
        {
            var result = await Sender.Send(command);
            return HandleResult(result);
        }


        [HttpDelete("delete")]
        [Authorize(Roles = "Employer")]
        public async Task<IActionResult> Delete(DeleteVacancyCommand command)
        {
            var result = await Sender.Send(command);
            return HandleResult(result);
        }
    }
}

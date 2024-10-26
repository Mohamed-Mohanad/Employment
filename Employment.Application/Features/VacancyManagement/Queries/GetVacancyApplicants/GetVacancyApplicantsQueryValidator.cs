using Common.Application.Extensions.FluentValidation;
using Employment.Domain.Entities;
using Employment.Domain.Repositories;
using Employment.Domain.Resources;

namespace Employment.Application.Features.VacancyManagement.Queries.GetVacancyApplicants
{
    internal class GetVacancyApplicantsQueryValidator : AbstractValidator<GetVacancyApplicantsQuery>
    {
        public GetVacancyApplicantsQueryValidator(IGenericRepository<Vacancy> vacancyRepo)
        {
            RuleFor(x => x.VacancyId)
                .NotEmpty().WithMessage(Messages.EmptyField)
                .EntityExist(vacancyRepo).WithMessage(Messages.NotFound);
        }
    }
}

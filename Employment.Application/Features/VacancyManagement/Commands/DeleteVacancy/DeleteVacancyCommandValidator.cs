using Common.Application.Extensions.FluentValidation;
using Employment.Domain.Entities;
using Employment.Domain.Repositories;
using Employment.Domain.Resources;

namespace Employment.Application.Features.VacancyManagement.Commands.DeleteVacancy
{
    internal class DeleteVacancyCommandValidator : AbstractValidator<DeleteVacancyCommand>
    {
        public DeleteVacancyCommandValidator(IGenericRepository<Vacancy> vacancyRepo)
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage(Messages.EmptyField)
                .EntityExist(vacancyRepo).WithMessage(Messages.NotFound);
        }
    }
}

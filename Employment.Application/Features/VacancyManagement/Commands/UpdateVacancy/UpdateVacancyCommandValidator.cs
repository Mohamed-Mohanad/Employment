using Common.Application.Extensions.FluentValidation;
using Employment.Domain.Entities;
using Employment.Domain.Repositories;
using Employment.Domain.Resources;

namespace Employment.Application.Features.VacancyManagement.Commands.UpdateVacancy
{
    internal class UpdateVacancyCommandValidator : AbstractValidator<UpdateVacancyCommand>
    {
        public UpdateVacancyCommandValidator(IGenericRepository<Vacancy> vacancyRepo)
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage(Messages.EmptyField)
                .EntityExist(vacancyRepo).WithMessage(Messages.NotFound);

            RuleFor(x => x.Title)
                .NotEmpty().WithMessage(Messages.EmptyField)
                .MaximumLength(100).WithMessage(Messages.MaxLengthExceeded)
                .When(x => !string.IsNullOrWhiteSpace(x.Title));

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage(Messages.EmptyField)
                .MaximumLength(1000).WithMessage(Messages.MaxLengthExceeded)
                .When(x => !string.IsNullOrWhiteSpace(x.Description));

            RuleFor(x => x.Location)
                .NotEmpty().WithMessage(Messages.EmptyField)
                .MaximumLength(200).WithMessage(Messages.MaxLengthExceeded)
                .When(x => !string.IsNullOrWhiteSpace(x.Location));

            RuleFor(x => x.MaxApplications)
                .GreaterThan(0).WithMessage(Messages.InvalidMaxApplications)
                .When(x => x.MaxApplications.HasValue);

            RuleFor(x => x.ExpiryDate)
                .GreaterThan(DateTime.Now).WithMessage(Messages.ExpiryDateInFuture)
                .When(x => x.ExpiryDate.HasValue);
        }
    }
}

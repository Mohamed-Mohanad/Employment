using Employment.Domain.Resources;

namespace Employment.Application.Features.VacancyManagement.Commands.CreateVacancy
{
    internal class CreateVacancyCommandValidator : AbstractValidator<CreateVacancyCommand>
    {
        public CreateVacancyCommandValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage(Messages.EmptyField)
                .MaximumLength(100).WithMessage(Messages.MaxLengthExceeded);

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage(Messages.EmptyField)
                .MaximumLength(1000).WithMessage(Messages.MaxLengthExceeded);

            RuleFor(x => x.Location)
                .NotEmpty().WithMessage(Messages.EmptyField)
                .MaximumLength(200).WithMessage(Messages.MaxLengthExceeded);

            RuleFor(x => x.MaxApplications)
                .GreaterThan(0).WithMessage(Messages.InvalidMaxApplications);

            RuleFor(x => x.ExpiryDate)
                .GreaterThan(DateTime.Now).WithMessage(Messages.ExpiryDateInFuture);

            RuleFor(x => x.Status)
                .IsInEnum().WithMessage(Messages.InvalidVacancyStatus);
        }
    }
}

using Employment.Application.Authentication;
using Employment.Application.Features.VacancyManagement.Specifications;
using Employment.Domain.Entities;
using Employment.Domain.Enums;
using Employment.Domain.Repositories;
using Employment.Domain.Resources;

namespace Employment.Application.Features.VacancyManagement.Commands.ApplyForVacancy
{
    internal class ApplyVacancyCommandValidator : AbstractValidator<ApplyVacancyCommand>
    {
        private readonly IGenericRepository<Vacancy> _vacancyRepo;
        private readonly IGenericRepository<Domain.Entities.Application> _applicationRepo;
        private readonly ITokenExtractor _tokenExtractor;

        public ApplyVacancyCommandValidator(
            IGenericRepository<Vacancy> vacancyRepo,
            IGenericRepository<Domain.Entities.Application> applicationRepo,
            ITokenExtractor tokenExtractor)
        {
            _vacancyRepo = vacancyRepo;
            _applicationRepo = applicationRepo;
            _tokenExtractor = tokenExtractor;

            RuleFor(x => x.VacancyId)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage(Messages.EmptyField);

            RuleFor(x => x.VacancyId)
                .Cascade(CascadeMode.Stop)
                .MustAsync(IsValidVacancy).WithMessage(Messages.InvalidVacancyStatus);

            RuleFor(x => x.VacancyId)
                .Cascade(CascadeMode.Stop)
                .Must(MustNotExceedMaxApplications).WithMessage(Messages.MaxVacancyApplicationsExceeded);

            RuleFor(x => x.VacancyId)
                .Cascade(CascadeMode.Stop)
                .MustAsync(MustBeAfter24HoursSinceLastApplication).WithMessage(Messages.CannotApplyAgainWithin24Hours);
        }

        private async Task<bool> IsValidVacancy(Guid vacancyId, CancellationToken cancellationToken)
        {
            var vacancy = await _vacancyRepo.GetByIdAsync(vacancyId);

            return vacancy != null && vacancy.Status == VacancyStatus.Active && vacancy.ExpiryDate > DateTime.UtcNow;
        }

        private bool MustNotExceedMaxApplications(Guid vacancyId)
        {
            var vacancy = _vacancyRepo.GetEntityWithSpec(new GetVacancyWithApplicationsSpecification(vacancyId));

            return vacancy != null && vacancy.MaxApplications > vacancy.Applications?.Count;
        }

        private async Task<bool> MustBeAfter24HoursSinceLastApplication(Guid vacancyId, CancellationToken cancellationToken)
        {
            var currentDateTime = DateTime.UtcNow;
            var applicantId = _tokenExtractor.GetOtherId();

            var isExist = await _applicationRepo.IsExistAsync(x =>
                x.ApplicantId == applicantId &&
                x.CreatedOnUtc >= currentDateTime.AddHours(-24));


            return isExist == false;
        }
    }
}

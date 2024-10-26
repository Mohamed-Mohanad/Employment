using Employment.Domain.Primitives;

namespace Employment.Domain.Entities
{
    public class Application : AggregateRoot<Guid>, IAuditableEntity
    {
        public Guid VacancyId { get; private set; }
        public Guid ApplicantId { get; private set; }
        public virtual Vacancy? Vacancy { get; private set; }
        public virtual Applicant? Applicant { get; private set; }
        public DateTime CreatedOnUtc { get; set; }
        public DateTime? ModifiedOnUtc { get; set; }

        public Application()
        {

        }

        public Application(Guid vacancyId, Guid applicantId)
        {
            SetVacancy(vacancyId);
            SetApplicant(applicantId);
        }

        public void SetVacancy(Guid vacancyId)
        {
            if (vacancyId == Guid.Empty)
            {
                throw new ArgumentException("VacancyId cannot be empty", nameof(vacancyId));
            }
            VacancyId = vacancyId;
        }

        public void SetApplicant(Guid applicantId)
        {
            if (applicantId == Guid.Empty)
            {
                throw new ArgumentException("ApplicantId cannot be empty", nameof(applicantId));
            }
            ApplicantId = applicantId;
        }

        public void SetVacancy(Vacancy vacancy)
        {
            if (vacancy == null)
            {
                throw new ArgumentNullException(nameof(vacancy), "Vacancy cannot be null");
            }
            Vacancy = vacancy;
            VacancyId = vacancy.Id;
        }

        public void SetApplicant(Applicant applicant)
        {
            if (applicant == null)
            {
                throw new ArgumentNullException(nameof(applicant), "Applicant cannot be null");
            }
            Applicant = applicant;
            ApplicantId = applicant.Id;
        }

    }
}

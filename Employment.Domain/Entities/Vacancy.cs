using Employment.Domain.Enums;
using Employment.Domain.Primitives;

namespace Employment.Domain.Entities
{
    public class Vacancy : AggregateRoot<Guid>, IAuditableEntity
    {
        public Guid EmployerId { get; private set; }
        public string Title { get; private set; } = null!;
        public string Description { get; private set; } = null!;
        public string Location { get; private set; } = null!;
        public int MaxApplications { get; private set; }
        public DateTime ExpiryDate { get; private set; }
        public VacancyStatus Status { get; private set; }
        public virtual Employer? Employer { get; private set; }
        public virtual ICollection<Application>? Applications { get; private set; }
        public DateTime CreatedOnUtc { get; set; }
        public DateTime? ModifiedOnUtc { get; set; }

        public Vacancy()
        {

        }

        public Vacancy(Guid employerId, string title, string description, string location, int maxApplications, DateTime expiryDate, VacancyStatus? status = null)
        {
            SetEmployer(employerId);
            SetTitle(title);
            SetDescription(description);
            SetLocation(location);
            SetMaxApplications(maxApplications);
            SetExpiryDate(expiryDate);
            SetStatus(status ?? VacancyStatus.Active);
        }

        public void SetEmployer(Guid employerId)
        {
            if (employerId == Guid.Empty)
            {
                throw new ArgumentException("EmployerId cannot be empty", nameof(employerId));
            }
            EmployerId = employerId;
        }

        public void SetEmployer(Employer employer)
        {
            if (employer == null)
            {
                throw new ArgumentNullException(nameof(employer), "Employer cannot be null");
            }
            Employer = employer;
            EmployerId = employer.Id;
        }

        public void SetTitle(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                throw new ArgumentException("Title cannot be empty", nameof(title));
            }
            Title = title;
        }

        public void SetDescription(string description)
        {
            if (string.IsNullOrWhiteSpace(description))
            {
                throw new ArgumentException("Description cannot be empty", nameof(description));
            }
            Description = description;
        }

        public void SetLocation(string location)
        {
            if (string.IsNullOrWhiteSpace(location))
            {
                throw new ArgumentException("Location cannot be empty", nameof(location));
            }
            Location = location;
        }

        public void SetMaxApplications(int maxApplications)
        {
            if (maxApplications <= 0)
            {
                throw new ArgumentException("MaxApplications must be greater than zero", nameof(maxApplications));
            }
            MaxApplications = maxApplications;
        }

        public void SetExpiryDate(DateTime expiryDate)
        {
            if (expiryDate <= DateTime.UtcNow)
            {
                throw new ArgumentException("ExpiryDate must be a future date", nameof(expiryDate));
            }
            ExpiryDate = expiryDate;
        }

        public void SetStatus(VacancyStatus status)
        {
            Status = status;
        }
    }
}

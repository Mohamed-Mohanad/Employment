using Employment.Domain.Primitives;

namespace Employment.Domain.Entities
{
    public class Employer : AggregateRoot<Guid>, IAuditableEntity
    {
        public Guid UserId { get; private set; }
        public long CompanyId { get; private set; }
        public virtual User? User { get; private set; }
        public virtual Company? Company { get; private set; }
        public virtual ICollection<Vacancy>? Vacancies { get; private set; }
        public DateTime CreatedOnUtc { get; set; }
        public DateTime? ModifiedOnUtc { get; set; }

        public Employer()
        {

        }

        public Employer(Guid userId, long companyId)
        {
            SetUser(userId);
            SetCompany(companyId);
        }

        public void SetCompany(long companyId)
        {
            CompanyId = companyId;
        }

        public void SetCompany(Company company)
        {
            if (company == null)
            {
                throw new ArgumentNullException(nameof(company), "Company cannot be null");
            }
            Company = company;
        }

        public void SetUser(Guid userId)
        {
            if (userId == Guid.Empty)
            {
                throw new ArgumentException("UserId cannot be empty", nameof(userId));
            }
            UserId = userId;
        }

        public void SetUser(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user), "User cannot be null");
            }
            User = user;
            UserId = user.Id;
        }
    }
}

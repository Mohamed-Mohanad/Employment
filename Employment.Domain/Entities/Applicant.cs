using Employment.Domain.Primitives;

namespace Employment.Domain.Entities
{
    public class Applicant : AggregateRoot<Guid>, IAuditableEntity
    {
        public Guid UserId { get; private set; }
        public string ResumeUrl { get; private set; } = null!;
        public virtual User? User { get; private set; }
        public virtual ICollection<Application>? Applications { get; private set; }
        public DateTime CreatedOnUtc { get; set; }
        public DateTime? ModifiedOnUtc { get; set; }

        public Applicant()
        {

        }

        public Applicant(Guid userId, string resumeUrl)
        {
            SetUser(userId);
            SetResumeUrl(resumeUrl);
        }

        public void SetResumeUrl(string resumeUrl)
        {
            if (string.IsNullOrWhiteSpace(resumeUrl))
            {
                throw new ArgumentException("Resume URL cannot be empty", nameof(resumeUrl));
            }
            if (!Uri.IsWellFormedUriString(resumeUrl, UriKind.Absolute))
            {
                throw new ArgumentException("Invalid Resume URL format", nameof(resumeUrl));
            }
            ResumeUrl = resumeUrl;
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

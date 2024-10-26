using Employment.Domain.Primitives;

namespace Employment.Domain.Entities
{
    public class Company : AggregateRoot<long>, IAuditableEntity
    {
        public string Name { get; private set; } = null!;
        public virtual ICollection<Employer>? Employers { get; private set; }
        public virtual ICollection<Vacancy>? Vacancies { get; private set; }
        public DateTime CreatedOnUtc { get; set; }
        public DateTime? ModifiedOnUtc { get; set; }

        public Company(long id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}

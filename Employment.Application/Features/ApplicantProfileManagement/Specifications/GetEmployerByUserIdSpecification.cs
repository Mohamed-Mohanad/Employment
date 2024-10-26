using Employment.Domain.Entities;
using Employment.Domain.Specification;

namespace Employment.Application.Features.ApplicantProfileManagement.Specifications
{
    internal class GetEmployerByUserIdSpecification : Specification<Employer>
    {
        public GetEmployerByUserIdSpecification(Guid userId)
        {
            AddCriteria(x => x.UserId == userId);
            AddInclude($"{nameof(Employer.Company)}");
        }
    }
}

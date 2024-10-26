using Employment.Domain.Entities;
using Employment.Domain.Specification;

namespace Employment.Application.Features.ApplicantProfileManagement.Specifications
{
    internal class GetApplicantByUserIdSpecification : Specification<Applicant>
    {
        public GetApplicantByUserIdSpecification(Guid userId)
        {
            AddCriteria(x => x.UserId == userId);
        }
    }
}

using Employment.Domain.Specification;
using Microsoft.AspNetCore.Identity;

namespace Employment.Application.Features.ApplicantProfileManagement.Specifications
{
    internal class GetRoleByNameSpecification : Specification<IdentityRole<Guid>>
    {
        public GetRoleByNameSpecification(string name)
        {
            AddCriteria(x => x.Name == name);
        }
    }
}

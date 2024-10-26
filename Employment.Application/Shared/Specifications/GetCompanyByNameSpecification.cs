using Employment.Domain.Entities;
using Employment.Domain.Specification;

namespace Employment.Application.Shared.Specifications
{
    public class GetCompanyByNameSpecification : Specification<Company>
    {
        public GetCompanyByNameSpecification(string name)
        {
            AddCriteria(x => x.Name == name);
        }
    }
}

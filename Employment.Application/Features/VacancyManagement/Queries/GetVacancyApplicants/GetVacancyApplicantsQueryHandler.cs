using Employment.Application.Abstractions.Messaging;
using Employment.Application.Features.VacancyManagement.DTOs;
using Employment.Application.Features.VacancyManagement.Specifications;
using Employment.Domain.Repositories;
using Employment.Domain.Shared;

namespace Employment.Application.Features.VacancyManagement.Queries.GetVacancyApplicants
{
    internal class GetVacancyApplicantsQueryHandler : IQueryHandler<GetVacancyApplicantsQuery, IReadOnlyList<ApplicantDto>>
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Domain.Entities.Application> _applicationRepo;

        public GetVacancyApplicantsQueryHandler(IMapper mapper, IGenericRepository<Domain.Entities.Application> applicationRepo)
        {
            _mapper = mapper;
            _applicationRepo = applicationRepo;
        }

        public Task<ResponseModel<IReadOnlyList<ApplicantDto>>> Handle(GetVacancyApplicantsQuery request, CancellationToken cancellationToken)
        {
            (var data, var count) = _applicationRepo.GetWithSpec(new GetVacancyApplicantsSpecification(request));

            var applicants = data.Select(x => x.Applicant).ToList();

            var applicantsDtos = _mapper.Map<IReadOnlyList<ApplicantDto>>(applicants);

            return Task.FromResult(ResponseModel.Success(applicantsDtos, count));
        }
    }
}

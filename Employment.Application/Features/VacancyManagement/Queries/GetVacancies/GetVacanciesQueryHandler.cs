using Employment.Application.Abstractions.Messaging;
using Employment.Application.Features.VacancyManagement.DTOs;
using Employment.Application.Features.VacancyManagement.Specifications;
using Employment.Domain.Entities;
using Employment.Domain.Repositories;
using Employment.Domain.Shared;

namespace Employment.Application.Features.VacancyManagement.Queries.GetVacancies
{
    internal class GetVacanciesQueryHandler : IQueryHandler<GetVacanciesQuery, IReadOnlyList<VacancyDto>>
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Vacancy> _vacancyRepo;

        public GetVacanciesQueryHandler(IMapper mapper, IGenericRepository<Vacancy> vacancyRepo)
        {
            _mapper = mapper;
            _vacancyRepo = vacancyRepo;
        }
        public Task<ResponseModel<IReadOnlyList<VacancyDto>>> Handle(GetVacanciesQuery request, CancellationToken cancellationToken)
        {
            (var data, var count) = _vacancyRepo.GetWithSpec(new GetVacanciesSearchSpecification(request));

            var vacanciesDto = _mapper.Map<IReadOnlyList<VacancyDto>>(data);

            return Task.FromResult(ResponseModel.Success(vacanciesDto, count));
        }
    }
}

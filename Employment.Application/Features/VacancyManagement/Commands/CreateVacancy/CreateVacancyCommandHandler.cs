using Employment.Application.Abstractions.Messaging;
using Employment.Application.Authentication;
using Employment.Domain.Entities;
using Employment.Domain.Repositories;
using Employment.Domain.Shared;

namespace Employment.Application.Features.VacancyManagement.Commands.CreateVacancy
{
    internal class CreateVacancyCommandHandler : ICommandHandler<CreateVacancyCommand>
    {
        private readonly IMapper _mapper;
        private readonly ITokenExtractor _tokenExtractor;
        private readonly IGenericRepository<Vacancy> _vacancyRepo;

        public CreateVacancyCommandHandler(
            IMapper mapper,
            ITokenExtractor tokenExtractor,
            IGenericRepository<Vacancy> vacancyRepo)
        {
            _mapper = mapper;
            _tokenExtractor = tokenExtractor;
            _vacancyRepo = vacancyRepo;
        }
        public async Task<ResponseModel> Handle(CreateVacancyCommand request, CancellationToken cancellationToken)
        {
            var vacancy = _mapper.Map<Vacancy>(request);
            vacancy.SetEmployer(_tokenExtractor.GetOtherId());

            await _vacancyRepo.AddAsync(vacancy);
            await _vacancyRepo.SaveChangesAsync(cancellationToken);

            return ResponseModel.Success();
        }
    }
}

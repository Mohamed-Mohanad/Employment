using Employment.Application.Abstractions.Messaging;
using Employment.Domain.Entities;
using Employment.Domain.Repositories;
using Employment.Domain.Shared;

namespace Employment.Application.Features.VacancyManagement.Commands.DeleteVacancy
{
    internal class DeleteVacancyCommandHandler : ICommandHandler<DeleteVacancyCommand>
    {
        private readonly IGenericRepository<Vacancy> _vacancyRepo;

        public DeleteVacancyCommandHandler(IGenericRepository<Vacancy> vacancyRepo)
        {
            _vacancyRepo = vacancyRepo;
        }
        public async Task<ResponseModel> Handle(DeleteVacancyCommand request, CancellationToken cancellationToken)
        {
            var vacancy = await _vacancyRepo.GetByIdAsync(request.Id);

            _vacancyRepo.Delete(vacancy!);
            await _vacancyRepo.SaveChangesAsync(cancellationToken);

            return ResponseModel.Success();
        }
    }
}

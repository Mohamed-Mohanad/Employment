using Employment.Application.Features.VacancyManagement.DTOs;
using Employment.Domain.Entities;
using Mapster;

namespace Employment.Application.Features.VacancyManagement.MappingConfig
{
    internal class ApplicantDtoMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<Applicant, ApplicantDto>()
              .Map(dest => dest.FullName, src => src.User!.FullName)
              .Map(dest => dest.UserName, src => src.User!.UserName)
              .Map(dest => dest.Email, src => src.User!.Email)
              .Map(dest => dest.PhoneNumber, src => src.User!.PhoneNumber);
        }
    }
}

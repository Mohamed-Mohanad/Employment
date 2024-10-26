using Employment.Domain.Entities;

namespace Employment.Application.Authentication
{
    public interface IJwtProvider
    {
        Task<string> Generate(User user, Guid otherId);
    }
}
using Employment.Application.Features.ApplicantProfileManagement.Queries.Login.Abstract;

namespace Employment.Application.Features.ApplicantProfileManagement.Queries.Login.Base
{
    internal class LoginFactory : ILoginFactory
    {
        private readonly IEnumerable<BaseLogin> _baseLogins;

        public LoginFactory(IEnumerable<BaseLogin> baseLogins)
        {
            _baseLogins = baseLogins;
        }
        public BaseLogin Login(LoginType type)
        {
            var login = _baseLogins.FirstOrDefault(r => r.Type == type);

            return login!;
        }
    }
}

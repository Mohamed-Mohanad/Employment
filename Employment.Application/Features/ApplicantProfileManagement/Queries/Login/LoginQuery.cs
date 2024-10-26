using Employment.Application.Abstractions.Messaging;
using Employment.Application.Features.ApplicantProfileManagement.Queries.Login.Abstract;

namespace Employment.Application.Features.ApplicantProfileManagement.Queries.Login
{
    public class LoginQuery : IQuery<LoginQueryResponse>
    {
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public LoginType Type { get; private set; }

        public void SetType(LoginType type)
        {
            Type = type;
        }

        public LoginQuery()
        {

        }
    }
}

using Employment.Application.Abstractions.Messaging;
using Employment.Application.Features.ApplicantProfileManagement.Queries.Login.Abstract;
using Employment.Domain.Shared;

namespace Employment.Application.Features.ApplicantProfileManagement.Queries.Login
{
    internal class LoginQueryHandler : IQueryHandler<LoginQuery, LoginQueryResponse>
    {
        private readonly ILoginFactory _loginFactory;

        public LoginQueryHandler(ILoginFactory loginFactory)
        {
            _loginFactory = loginFactory;
        }
        public async Task<ResponseModel<LoginQueryResponse>> Handle(LoginQuery request, CancellationToken cancellationToken)
        {
            var login = _loginFactory.Login(request.Type);

            return await login.Login(request);
        }
    }
}

using Employment.Application.Abstractions.Messaging;
using Employment.Application.Features.Auth.Commands.Register.Abstract;
using Employment.Domain.Shared;

namespace Employment.Application.Features.Auth.Commands.Register
{
    internal class RegisterCommandHandler : ICommandHandler<RegisterCommand>
    {
        private readonly IRegisterFactory _registerFactory;

        public RegisterCommandHandler(IRegisterFactory registerFactory)
        {
            _registerFactory = registerFactory;
        }
        public async Task<ResponseModel> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            var register = _registerFactory.Register(request.Type);

            return await register.Register(request);
        }
    }
}

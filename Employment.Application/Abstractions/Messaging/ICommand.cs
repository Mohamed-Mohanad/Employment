using Employment.Domain.Shared;
using MediatR;

namespace Employment.Application.Abstractions.Messaging;

public interface ICommand : IRequest<ResponseModel>
{
}

public interface ICommand<TResponse> : IRequest<ResponseModel<TResponse>>
{
}

using Employment.Domain.Shared;
using MediatR;

namespace Employment.Application.Abstractions.Messaging;

public interface IQuery<TResponse> : IRequest<ResponseModel<TResponse>>
{
}
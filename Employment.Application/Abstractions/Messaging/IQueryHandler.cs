using Employment.Domain.Shared;
using MediatR;

namespace Employment.Application.Abstractions.Messaging;

public interface IQueryHandler<TQuery, TResponse>
    : IRequestHandler<TQuery, ResponseModel<TResponse>>
    where TQuery : IQuery<TResponse>
{
}
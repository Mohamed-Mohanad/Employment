using MediatR;

namespace Employment.Domain.Primitives
{
    public interface IDomainEvent : INotification
    {
        public Guid Id { get; init; }
    }
}

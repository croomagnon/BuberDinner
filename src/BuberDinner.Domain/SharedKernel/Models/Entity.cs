using System.Collections.ObjectModel;
using System.Text.Json.Serialization;
using BuberDinner.Domain.SharedKernel.Interfaces;

namespace BuberDinner.Domain.SharedKernel.Models;

public abstract class Entity<TId> : IEntity, IEquatable<Entity<TId>>
    where TId : notnull
{
    private readonly Collection<IDomainEvent> _domainEvents;

    protected Entity()
    {
    }

    protected Entity(TId id)
    {
        Id = id;
        _domainEvents = new Collection<IDomainEvent>();
    }

    public TId Id { get; }

    [JsonIgnore]
    public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();

    public DateTime CreatedDateTimeUtc { get; protected set; }

    public DateTime UpdatedDateTimeUtc { get; protected set; }

    public static bool operator ==(Entity<TId> left, Entity<TId> right)
    {
        return Equals(left, right);
    }

    public static bool operator !=(Entity<TId> left, Entity<TId> right)
    {
        return !Equals(left, right);
    }

    public virtual bool Equals(Entity<TId>? other)
    {
        return Equals((object?)other);
    }

    public override bool Equals(object? obj)
    {
        return obj is Entity<TId> entity && Id.Equals(entity.Id);
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }

    public void AddDomainEvent(IDomainEvent @event)
    {
        _domainEvents.Add(@event);
    }

    public void RemoveDomainEvent(IDomainEvent @event)
    {
        _domainEvents.Remove(@event);
    }

    public void ClearDomainEvents()
    {
        _domainEvents.Clear();
    }
}

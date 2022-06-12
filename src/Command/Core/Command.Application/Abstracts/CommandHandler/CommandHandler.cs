﻿using Command.Domain.DomainObject;
using Command.Domain.Event;
using EventSourcing.Shared.IntegrationEvent;

namespace Command.Application.Abstracts.CommandHandler;

public abstract class CommandHandler
{
    public IEnumerable<IIntegrationEvent> PrepareIntegrationEvents<T>(T aggregate) where T : AggregateRoot
    {
        List<IIntegrationEvent> integrationEvents = new List<IIntegrationEvent>();
        
        foreach (var @event in aggregate.GetRaisedEvents())
        {
            integrationEvents.Add(@event.ToIntegrationEvent(aggregate.AggregateId, aggregate.Version)); 
        }
        
        return integrationEvents;
    }
}
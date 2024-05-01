using MediatR;
using Order.Application.Repository;
using Order.Domain.AggregateModels.BuyerModels;
using Order.Domain.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Application.DomainEventHandlers
{
    public class OrderStartedDomainHandler : INotificationHandler<OrderStartedDomainEvent>
    {
        private readonly IBuyerRepository _buyerRepository;
        public OrderStartedDomainHandler(IBuyerRepository buyerRepository)
        {
            _buyerRepository = buyerRepository;
        }
        public Task Handle(OrderStartedDomainEvent notification, CancellationToken cancellationToken)
        {
            if (notification.Order.UserName == "") //bu UserName den yoksa
            {
                var user = new Buyer(notification.UserName);
                // _buyerRepository.Add(user);
            }
            return Task.CompletedTask;
        }
    }
}

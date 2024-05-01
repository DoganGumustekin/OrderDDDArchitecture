using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Domain.Event
{

    //bu eventin görevi mesela order oluşturuldu içindeki orderitem oluşturuldu mu? bunları kontrol edeceğiz.
    //mediatr kullanılıyor!!!
    public class OrderStartedDomainEvent : INotification //bu inherit mediatr den geliyor
    {
        public string UserName { get; set; }

        public AggregateModels.OrderModels.Order Order { get; set; }

        public OrderStartedDomainEvent(string userName, AggregateModels.OrderModels.Order order)
        {
            UserName = userName;
            Order = order;
        }
    }
}

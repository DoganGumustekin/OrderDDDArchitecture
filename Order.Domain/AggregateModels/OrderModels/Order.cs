using MediatR;
using Order.Domain.Event;
using Order.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Domain.AggregateModels.OrderModels
{
    public class Order : BaseEntity, IAggregateRoot
    {
        public DateTime OrderDate { get; private set; }
        public string Description { get; private set; }
        public string UserName { get; private set; }
        public string OrderStatus { get; private set; }
        public Address Address { get; private set; }
        public ICollection<OrderItem> OrderItems { get; private set; }

        //bu propertyler dışardan set edilebilsin istemiyorum bu yüzden hepsini private yaptım.
        //aynı zamanda aşağıda ctor ile bu entity nin kurallarını yazacağım. bunlar validasyon kuralları olacak.
        public Order(DateTime orderDate, string description, string userName, string orderStatus, Address address, ICollection<OrderItem> orderItems)
        {
            if (orderDate < DateTime.Now)
                throw new Exception("Order Date must be greater than now");

            if (address.City == "")
                throw new Exception("City cannot be empty");

            OrderDate = orderDate;
            Description = description;
            UserName = userName;
            OrderStatus = orderStatus;
            Address = address;
            OrderItems = orderItems;

            AddDomainEvents( new OrderStartedDomainEvent(userName, this));
        }

        //aynı şekilde bu orderitem içinde yapılmalı. order item e de ctor eklemeliyim orderitem in de validasyon kodları olabilr.
        //bir orderitem order olmadan düşünülemez. bu yüzden order bir aggregateroot tur. 
        public void AddOrderItem(int quantity, decimal price, int productId)
        {
            OrderItem item = new(quantity, price, productId);

            OrderItems.Add(item);
        }
    }
}

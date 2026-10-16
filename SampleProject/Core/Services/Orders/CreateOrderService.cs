using BusinessEntities;
using Common;
using Core.Factories;
using Core.Services.Products;
using Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace Core.Services.Orders
{
    [AutoRegister]
    public class CreateOrderService: ICreateOrderService    
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IIdObjectFactory<Order> _orderFactory;
        private readonly IUpdateOrderService _updateOrderService;
        public CreateOrderService(IOrderRepository orderRepository, IIdObjectFactory<Order> orderFactory, IUpdateOrderService updateOrderService)
        {
            _orderRepository = orderRepository;
            _orderFactory = orderFactory;
            _updateOrderService = updateOrderService;
        }
        public Order Create(Guid orderId, Guid customerID, string customerName, IEnumerable<OrderItem> items)
        {
            var order = _orderRepository.GetById(orderId);
            if (order == null)
            {
                order = _orderFactory.Create(orderId);
                _orderRepository.Add(order);
            }

            _updateOrderService.Update(order, customerID, customerName, items);
            return order;            
        }
    }
}

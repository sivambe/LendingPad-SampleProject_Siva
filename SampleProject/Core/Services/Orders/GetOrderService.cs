using BusinessEntities;
using Common;
using Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Services.Orders
{
    [AutoRegister]
    public class GetOrderService : IGetOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public GetOrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public Order GetById(Guid id)
        {
            return _orderRepository.GetById(id);
        }
        public IEnumerable<Order> GetAll()
        {
            return _orderRepository.GetAll();
        }

        public IEnumerable<Order> GetOrdersByDateRange(DateTime? startDate = null, DateTime? endDate = null)
        {
            return _orderRepository.GetOrdersByDateRange(startDate, endDate);
        }
    }
}

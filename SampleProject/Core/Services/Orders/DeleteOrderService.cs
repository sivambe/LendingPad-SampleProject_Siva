using Common;
using Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Services.Orders
{
    [AutoRegister]
    public class DeleteOrderService : IDeleteOrderService
    {
        private readonly IOrderRepository _orderRepository;
        public DeleteOrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public bool Delete(Guid id)
        {
            return _orderRepository.Delete(id);
        }

        public void DeleteAll()
        {
            _orderRepository.DeleteAll();
        }
    }
}

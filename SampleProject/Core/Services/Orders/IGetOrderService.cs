using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Services.Orders
{
    public interface IGetOrderService
    {
        Order GetById(Guid id);
        IEnumerable<Order> GetOrdersByDateRange(DateTime? startDate = null, DateTime? endDate = null);
    }
}

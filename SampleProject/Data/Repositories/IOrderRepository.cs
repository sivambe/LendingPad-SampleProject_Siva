using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Repositories
{
    public interface IOrderRepository : IInMemoryRepository<Order>
    {
        IEnumerable<Order> GetOrdersByDateRange(DateTime? startDate = null, DateTime? endDate = null);
    }
}

using BusinessEntities;
using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data.Repositories
{
    [AutoRegister(AutoRegisterTypes.Singleton)]
    public class OrderRepository : InMemoryRepository<Order>, IOrderRepository
    {
        public IEnumerable<Order> GetOrdersByDateRange(DateTime? startDate = null, DateTime? endDate = null)
        {
            var query = GetAll();
            if (startDate.HasValue)
            {
                query = query.Where(o => o.OrderDate >= startDate.Value);
            }
            if (endDate.HasValue)
            {
                query = query.Where(o => o.OrderDate <= endDate.Value.Date.AddDays(1).AddTicks(-1));
            }
            return query.ToList();
        }
    }
}

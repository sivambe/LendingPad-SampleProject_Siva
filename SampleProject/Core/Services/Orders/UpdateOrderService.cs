using BusinessEntities;
using Common;
using System;
using System.Collections.Generic;


namespace Core.Services.Orders
{
    [AutoRegister(AutoRegisterTypes.Singleton)]
    public class UpdateOrderService : IUpdateOrderService
    {
        public void Update(Order order, Guid customerID, string customerName, IEnumerable<OrderItem> items)
        {
            order.SetCustomerID(customerID);
            order.SetCustomerName(customerName);
            order.SetOrderItems(items);

        }
    }
}

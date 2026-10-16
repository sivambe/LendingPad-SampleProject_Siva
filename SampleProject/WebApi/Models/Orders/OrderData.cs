using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace WebApi.Models.Orders
{
    public class OrderData : IdObjectData
    {
        public OrderData(Order order) : base(order)
        {
            CustomerID = order.CustomerID;
            CustomerName = order.CustomerName;
            Items = order.Items;
            Status = order.Status;
            OrderDate = order.OrderDate;
            TotalAmount = order.Items.Sum(i => i.UnitPrice * i.Quantity);
        }
        public Guid CustomerID { get; set; }
        public string CustomerName { get; set; }
        public IEnumerable<OrderItem> Items { get; set; }
        public decimal TotalAmount { get; set; }
        public string Status { get; set; }
        public DateTime OrderDate { get; set; }
    }
}

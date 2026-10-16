using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessEntities
{
    public class Order : IdObject
    {
        public Guid CustomerID { get; private set; }
        public string CustomerName { get; private set; } = string.Empty;
        public IEnumerable<OrderItem> Items { get; private set; } = new List<OrderItem>();
        public decimal TotalAmount => Items.Sum(i => i.UnitPrice * i.Quantity);
        public string Status { get; private set; } = "Pending";
        public DateTime OrderDate { get; private set; } = DateTime.UtcNow;

        public void SetCustomerID(Guid customerId)
        {
            if (customerId == Guid.Empty)
            {
                throw new ArgumentException("Customer ID cannot be empty.");
            }
            CustomerID = customerId;
        }
        public void SetCustomerName(string customerName)
        {
            if (string.IsNullOrWhiteSpace(customerName))
            {
                throw new ArgumentException("Customer name cannot be empty.");
            }
            CustomerName = customerName;
        }   

        public void SetOrderItems(IEnumerable<OrderItem> items)
        {
            if (items == null)
            {
                throw new ArgumentNullException(nameof(items), "Order item cannot be null.");
            }
            Items = items.ToList();
        }

        public void SetStatus(string status)
        {
            if (string.IsNullOrWhiteSpace(status))
            {
                throw new ArgumentException("Order status cannot be empty.");
            }
            Status = status;
        }
    }
}

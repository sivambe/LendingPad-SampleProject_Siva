using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessEntities
{
    public class OrderItem : IdNameObject
    {
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }

        public OrderItem(Guid id, string name, int quantity, decimal unitPrice) : base(id, name)
        {
            if (quantity <= 0)
            {
                throw new ArgumentException("Quantity must be greater than zero.");
            }
            if (unitPrice < 0)
            {
                throw new ArgumentException("Unit price cannot be negative.");
            }
            Quantity = quantity;
            UnitPrice = unitPrice;
        }
    }
}

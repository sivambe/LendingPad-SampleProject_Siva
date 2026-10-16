using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessEntities
{
    public class Product : IdObject
    {
        public string Name { get; private set; } 
        public string SKU { get; private set; } 
        public decimal Price { get; private set; }
        public int StockQuantity { get; private set; }
        public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;

        public void SetName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Product name cannot be empty.");
            }
            Name = name;
        }

        public void SetSKU(string sku)
        {
            if (string.IsNullOrWhiteSpace(sku))
            {
                throw new ArgumentException("Product SKU cannot be empty.");
            }
            SKU = sku;
        }

        public void SetPrice(decimal price)
        {
            if (price < 0)
            {
                throw new ArgumentException("Product price cannot be negative.");
            }
            Price = price;
        }

        public void SetStockQuantity(int quantity)
        {
            if (quantity < 0)
            {
                throw new ArgumentException("Stock quantity cannot be negative.");
            }
            StockQuantity = quantity;
        }

    }
}

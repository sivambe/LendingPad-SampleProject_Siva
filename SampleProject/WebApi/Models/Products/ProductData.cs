using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;

namespace WebApi.Models.Products
{
    public class ProductData : IdObjectData
    {
        public ProductData(Product product) :base(product)
        {
            Name = product.Name;
            SKU = product.SKU;
            Price = product.Price;
            StockQuantity = product.StockQuantity;
        }
        public string Name { get; set; }
        public string SKU { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Models.Products
{
    public class ProductModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string SKU { get; set; }
        [Required, Range(1, int.MaxValue)]
        public decimal Price { get; set; }
        [Required, Range(0, int.MaxValue)]
        public int StockQuantity { get; set; }
    }
}

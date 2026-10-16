using BusinessEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Models.Orders
{
    public class OrderItemModel
    {
        [Required]
        public Guid ProductId { get; set; }

        [Required]
        public string ProductName { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required, Range(0, (double)decimal.MaxValue)]
        public decimal Price { get; set; }
    }
}

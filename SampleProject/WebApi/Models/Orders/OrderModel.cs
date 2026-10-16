using BusinessEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Models.Orders
{
    public class OrderModel
    {
        [Required]
        public Guid CustomerID { get; set; }
        
        [Required]
        public string CustomerName { get; set; }
        [Required]
        public IEnumerable<OrderItemModel> Items { get; set; }
        public string Status { get; set; }
    }
}

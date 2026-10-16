using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Services.Products
{
    public interface IGetProductService
    {
        Product GetProduct(Guid id);
        IEnumerable<Product> GetProducts(string name = null, string sku = null);
    }
}

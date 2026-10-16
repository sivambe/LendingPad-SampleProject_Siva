using BusinessEntities;
using Common;
using Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Services.Products
{
    [AutoRegister(AutoRegisterTypes.Singleton)]
    public class UpdateProductService : IUpdateProductService   
    {
        public void Update(Product product, string name, string sku, decimal price, int stockQuantity)
        {
            product.SetName(name);
            product.SetSKU(sku);
            product.SetPrice(price);
            product.SetStockQuantity(stockQuantity);
        }
    }
}

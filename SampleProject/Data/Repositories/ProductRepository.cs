using BusinessEntities;
using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Data.Repositories
{
    [AutoRegister(AutoRegisterTypes.Singleton)]
    public class ProductRepository : InMemoryRepository<Product>, IProductRepository
    {
        public IEnumerable<Product> GetProducts(string name = null, string sku = null   )
        {
            var query = GetAll();
            if (!string.IsNullOrWhiteSpace(name))
                query = query.Where(p => p.Name.IndexOf(name, StringComparison.OrdinalIgnoreCase) >= 0);
            if (!string.IsNullOrWhiteSpace(sku))
                query = query.Where(p => p.SKU.IndexOf(sku, StringComparison.OrdinalIgnoreCase) >= 0);
            
            return query.ToList();
        }
    }
}

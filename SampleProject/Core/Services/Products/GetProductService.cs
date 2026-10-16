using BusinessEntities;
using Common;
using Core.Services.Users;
using Data.Repositories;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Core.Services.Products
{
    [AutoRegister]
    public class GetProductService : IGetProductService 
    {
        private readonly IProductRepository _productRepository;

        public GetProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public Product GetProduct(Guid id)
        {
            return _productRepository.GetById(id);
        }

        public IEnumerable<Product> GetProducts(string name = null, string sku = null)
        {
            return _productRepository.GetProducts(name, sku);
        }
    }
}

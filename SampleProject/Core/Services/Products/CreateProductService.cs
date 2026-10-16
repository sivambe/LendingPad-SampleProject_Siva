using BusinessEntities;
using Common;
using Core.Factories;
using Core.Services.Users;
using Data.Repositories;
using System;


namespace Core.Services.Products
{
    [AutoRegister]
    public class CreateProductService : ICreateProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IIdObjectFactory<Product> _productFactory;
        private readonly IUpdateProductService _updateProductService;

        public CreateProductService(IProductRepository productRepository, IIdObjectFactory<Product> productFactory, IUpdateProductService updateProductService)
        {
            _productRepository = productRepository;
            _productFactory = productFactory;
            _updateProductService = updateProductService;
        }
        public Product Create(Guid productId, string name, string sku, decimal price, int stockQuantity)
        {

            var product = _productRepository.GetById(productId);
            if (product == null)
            {
                product = _productFactory.Create(productId);
                _productRepository.Add(product);
            }
           
            _updateProductService.Update(product, name, sku, price, stockQuantity);
            return product;
        }
    }
}

using BusinessEntities;
using Core.Services.Products;
using Core.Services.Users;
using Data.Repositories;
using Raven.Abstractions.Data;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi.Models.Products;
using WebApi.Models.Users;

namespace WebApi.Controllers
{
    [RoutePrefix("products")]
    public class ProductsController : BaseApiController
    {
        private readonly ICreateProductService _createProductService;
        private readonly IDeleteProductService _deleteProductService;
        private readonly IGetProductService _getProductService;
        private readonly IUpdateProductService _updateProductService;

        public ProductsController(ICreateProductService createProductService, IGetProductService getProductService, IUpdateProductService updateProductService, IDeleteProductService deleteProductService)
        {
            _createProductService = createProductService;
            _getProductService = getProductService;
            _updateProductService = updateProductService;
            _deleteProductService = deleteProductService;
        }

        // GET: /products or /products?name=laptop&minPrice=100
        [HttpGet]
        [Route("")]
        public HttpResponseMessage GetList(int skip=0, int take=10, string name = null, string sku =null)
        {
            var products = _getProductService.GetProducts(name, sku)
                                       .Skip(skip).Take(take)
                                       .Select(p => new ProductData(p))
                                       .ToList();
            return Found(products);
        }

        // GET: /products/{id}
        [HttpGet]
        [Route("{id}")]
        public HttpResponseMessage GetById(Guid id)
        {
            var product = _getProductService.GetProduct(id);
            if (product == null) return DoesNotExist();
            return Found(new ProductData(product));
        }

        // POST: /products
        [HttpPost]
        [Route("{productId:guid}/create")]
        public HttpResponseMessage Create(Guid productId, [FromBody] ProductModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadDataRequest(ModelState); // Returns validation errors to the client
            }
            var product = _createProductService.Create(productId, model.Name, model.SKU, model.Price, model.StockQuantity);
            return Found(new ProductData(product));
        }


        [Route("{productId:guid}/update")]
        [HttpPost]
        public HttpResponseMessage Update(Guid productId, [FromBody] ProductModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadDataRequest(ModelState); // Returns validation errors to the client
            }
            var product = _getProductService.GetProduct(productId);
            if (product == null)
            {
                return DoesNotExist();
            }
            _updateProductService.Update(product, model.Name, model.SKU, model.Price, model.StockQuantity);
            return Found(new ProductData(product));
        }

        [Route("{productId:guid}/delete")]
        [HttpDelete]
        public HttpResponseMessage Delete(Guid productId)
        {
            var deleted = _deleteProductService.Delete(productId);
            if (!deleted) return DoesNotExist();

            return Found();
        }

        [Route("clear")]
        [HttpDelete]
        public HttpResponseMessage DeleteAllProducts()
        {
            _deleteProductService.DeleteAll();
            return Found();
        }
    }
}

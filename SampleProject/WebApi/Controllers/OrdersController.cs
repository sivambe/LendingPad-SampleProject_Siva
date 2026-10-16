using BusinessEntities;
using Core.Services.Orders;
using Core.Services.Products;
using Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Xml.Linq;
using WebApi.Models.Orders; // <- changed from WebApi.Models.Products

namespace WebApi.Controllers
{
    [RoutePrefix("orders")]
    public class OrdersController : BaseApiController
    {
        private readonly ICreateOrderService _createOrderService;
        private readonly IDeleteOrderService _deleteOrderService;
        private readonly IGetOrderService _getOrderService;
        private readonly IUpdateOrderService _updateOrderService;

        // Constructor Injection (Your DI container will supply the IOrderRepository implementation)
        public OrdersController(ICreateOrderService createOrderService, IGetOrderService getOrderService, IUpdateOrderService updateOrderService, IDeleteOrderService deleteOrderService)
        {
            _createOrderService = createOrderService;
            _getOrderService = getOrderService;
            _updateOrderService = updateOrderService;
            _deleteOrderService = deleteOrderService;
        }

        // GET: api/orders
        [Route("")]
        [HttpGet]
        public HttpResponseMessage GetList(int skip=0, int take=10, DateTime? startDate = null, DateTime? endDate = null)
        {
            var orders = _getOrderService.GetOrdersByDateRange(startDate, endDate)
                                        .Skip(skip)
                                        .Take(take)
                                        .Select(o => new OrderData(o))
                                        .ToList();
            return Found(orders);
        }

        // GET: api/orders/{id}
        [HttpGet]
        [Route("{orderId:guid}")]
        public HttpResponseMessage GetById(Guid orderId)
        {
            var order = _getOrderService.GetById(orderId);
            if (order == null) return DoesNotExist();
            return Found(new OrderData(order));
        }

        // POST: api/orders
        [HttpPost]
        [Route("{orderId:guid}/create")]
        public HttpResponseMessage CreateOrder(Guid orderId, [FromBody] OrderModel model)
        {
            // Automatically triggers the [Required] and model validations on your Order entity
            if (!ModelState.IsValid)
            {
                return BadDataRequest(ModelState); // Returns 400 Bad Request with validation errors
            }
            var items = model.Items.Select(i => new OrderItem(i.ProductId, i.ProductName, i.Quantity, i.Price)).ToList();
            var order = _createOrderService.Create(orderId, model.CustomerID, model.CustomerName, items);
            return Found(new OrderData(order));
        }

        [Route("{orderId:guid}/update")]
        [HttpPost]
        public HttpResponseMessage Update(Guid orderId, [FromBody] OrderModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadDataRequest(ModelState); // Returns validation errors to the client
            }
            var order = _getOrderService.GetById(orderId);
            if (order == null)
            {
                return DoesNotExist();
            }
            var items = model.Items.Select(i => new OrderItem(i.ProductId, i.ProductName, i.Quantity, i.Price)).ToList();
            _updateOrderService.Update(order, model.CustomerID, model.CustomerName, items);
            return Found(new OrderData(order));
        }

        [Route("{orderId:guid}/delete")]
        [HttpDelete]
        public HttpResponseMessage Delete(Guid orderId)
        {
            var deleted = _deleteOrderService.Delete(orderId);
            if (!deleted) return DoesNotExist();

            return Found();
        }

        [Route("clear")]
        [HttpDelete]
        public HttpResponseMessage DeleteAllOrders()
        {
            _deleteOrderService.DeleteAll();
            return Found();
        }
    }
}

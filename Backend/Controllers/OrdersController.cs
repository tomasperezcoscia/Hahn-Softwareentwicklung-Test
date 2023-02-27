using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Hahn_Softwareentwicklung.Entities;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Text.Json;

namespace Hahn_Softwareentwicklung.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly ApplicationContext _context;
        private readonly ILogger<OrdersController> _logger;

        public OrdersController(ApplicationContext context, ILogger<OrdersController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET: api/Orders
        [HttpGet]
        public ActionResult<IEnumerable<Order>> GetListOfOrders()
        {
            return _context.Orders.ToList();
        }

        // GET: api/Orders/5
        [HttpGet("{id}")]
        public ActionResult<Order> GetOrderById(Guid id)
        {
            var order = _context.Orders.Find(id);

            if (order == null)
            {
                return NotFound();
            }

            return order;
        }

        [HttpGet("dateRange/{startDate}/{endDate}")]
        public ActionResult<IEnumerable<Order>> getOrdersByDateRange(DateTime startDate, DateTime endDate) {
            var orders = _context.Orders.Where(o => o.OrderDate >= startDate && o.OrderDate <= endDate).ToList();
            return Ok(orders);
        }

        [HttpGet("paymentMethod/{paymentMethod}")]
        public ActionResult<IEnumerable<Order>> getOrdersByPaymentMethod(string paymentMethod)
        {
            var orders = _context.Orders.Where(o => o.PaymentMethod == paymentMethod).ToList();
            return Ok(orders);
        }

        [HttpGet("paymentMethods")]
        public ActionResult<IEnumerable<PaymentMethod>> getPaymentMethods()
        {
            return Ok(_context.PaymentMethods.ToList());
        }

        // POST: api/Orders
        [HttpPost]
        public ActionResult<Order> AddOrder(Order order)
        {
            order.Id = Guid.NewGuid();
            _context.Orders.Add(order);
            _context.SaveChanges();


            return order;
        }

        // PUT: api/Orders/5
        [HttpPut("{id}")]
        public ActionResult<Order> EditOrderById(Guid id, Order order)
        {
            var orderS = _context.Orders.FirstOrDefault(o => o.Id == id);

            if (orderS == null)
            {
                return NotFound();
            }

            _context.Entry(orderS).State = EntityState.Detached;
            _context.Entry(order).State = EntityState.Modified;

            _context.SaveChanges();

            return orderS;
        }

        // DELETE: api/Orders/5
        [HttpDelete("{id}")]
        public ActionResult<Order> DeleteOrderById(Guid id)
        {
            var order = _context.Orders.Find(id);
            if (order == null)
            {
                return NotFound();
            }

            _context.Orders.Remove(order);
            _context.SaveChanges();

            return order;
        }


        // GET: api/Orders/OrderItems
        [HttpGet("OrderItems")]
        public ActionResult<IEnumerable<OrderItem>> GetListOfOrderItems()
        {
            return _context.OrderItems.ToList();
        }

        // GET: api/Orders/{id}/OrderItems
        [HttpGet("{id}/OrderItems")]
        public ActionResult<IEnumerable<OrderItem>> GetListOfOrderItemsFromOrder(Guid id)
        {
            var orderItems = _context.OrderItems
                .Where(oi => oi.OrderId == id)
                .ToList();

            return orderItems;
        }

        // POST: api/Orders/OrderItems
        [HttpPost("OrderItems")]
        public ActionResult<OrderItem> AddOrderItem(OrderItem orderItem)
        {
            _logger.LogInformation(JsonSerializer.Serialize(orderItem));
            _context.OrderItems.Add(orderItem);
            _context.SaveChanges();

            return orderItem;
        }

        // PUT: api/Orders/OrderItems/{itemId}
        [HttpPut("OrderItems/{itemId}")]
        public ActionResult<OrderItem> EditOrderItem(Guid itemId, OrderItem orderItem)
        {
            var existingOrderItem = _context.OrderItems.Find(itemId);
            if (existingOrderItem == null)
            {
                return NotFound();
            }

            existingOrderItem = orderItem;

            _context.OrderItems.Update(existingOrderItem);
            _context.SaveChanges();

            return NoContent();
        }

        // DELETE: api/Orders/OrderItems/{itemId}
        [HttpDelete("OrderItems/{itemId}")]
        public ActionResult<OrderItem> DeleteOrderItem(Guid itemId)
        {
            var orderItem = _context.OrderItems.Find(itemId);
            if (orderItem == null)
            {
                return NotFound();
            }

            _context.OrderItems.Remove(orderItem);
            _context.SaveChanges();

            return orderItem;
        }
    }
}
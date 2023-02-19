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
            if (id != order.Id)
            {
                return BadRequest();
            }

            _context.Entry(order).State = EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
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
            var order = _context.Orders.Find(id);
            return order.OrderItems.ToList();
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


        // GET: api/Orders/Payments
        [HttpGet("Payments")]
        public ActionResult<IEnumerable<Payment>> GetListOfPayments()
        {
            return _context.Payments.ToList();
        }

        // GET: api/Orders/{id}/Payments
        [HttpGet("{id}/Payments")]
        public ActionResult<IEnumerable<Payment>> GetListOfOrderPayments(Guid id)
        {
            return _context.Payments.Where(item => item.OrderId == id).ToList();
        }

        // POST: api/Orders/Payment
        [HttpPost("Payment")]
        public ActionResult<Payment> AddPayment(Payment payment)
        {

            payment.Id = Guid.NewGuid();
            _context.Payments.Add(payment);
            _context.SaveChanges();

            return payment;
        }

        // PUT: api/Orders/Payments/{paymentId}
        [HttpPut("Payments/{paymentId}")]
        public ActionResult<Payment> EditPayment(Guid paymentId, Payment payment)
        {
            var existingPayment = _context.Payments.Find(paymentId);
            if (existingPayment == null)
            {
                return NotFound();
            }

            existingPayment = payment;

            _context.Payments.Update(existingPayment);
            _context.SaveChanges();

            return NoContent();
        }

        // DELETE: api/Orders/Payments/{paymentId}
        [HttpDelete("Payments/{paymentId}")]
        public ActionResult<Payment> DeletePayment(Guid paymentId)
        {
            var payment = _context.Payments.Find(paymentId);
            if (payment == null)
            {
                return NotFound();
            }

            _context.Payments.Remove(payment);
            _context.SaveChanges();

            return payment;
        }

        [HttpGet("paymentMethods")]
        public ActionResult<IEnumerable<PaymentMethod>> getPaymentMethods()
        {
            return _context.PaymentMethods.ToList();
        }
    }
}
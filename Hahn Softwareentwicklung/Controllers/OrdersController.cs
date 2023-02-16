using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Hahn_Softwareentwicklung.Entities;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Hahn_Softwareentwicklung.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public OrdersController(ApplicationContext context)
        {
            _context = context;
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
            order.OrderId = Guid.NewGuid();
            _context.Orders.Add(order);
            _context.SaveChanges();

            return order;
        }

        // PUT: api/Orders/5
        [HttpPut("{id}")]
        public ActionResult<Order> EditOrderById(Guid id, Order order)
        {
            if (id != order.OrderId)
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

        // POST: api/Orders/{id}/OrderItems
        [HttpPost("{id}/OrderItems")]
        public ActionResult<OrderItem> AddOrderItem(Guid id, OrderItem orderItem)
        {
            var order = _context.Orders.Find(id);
            if (order == null)
            {
                return NotFound();
            }

            orderItem.OrderItemId = Guid.NewGuid();
            orderItem.Order = order;
            _context.OrderItems.Add(orderItem);
            _context.SaveChanges();

            return orderItem;
        }

        // PUT: api/Orders/{id}/OrderItems/{itemId}
        [HttpPut("{id}/OrderItems/{itemId}")]
        public ActionResult<OrderItem> EditOrderItem(Guid id, Guid itemId, OrderItem orderItem)
        {
            var existingOrder = _context.Orders.Find(id);
            if (existingOrder == null)
            {
                return NotFound();
            }

            var existingOrderItem = _context.OrderItems.Find(itemId);
            if (existingOrderItem == null)
            {
                return NotFound();
            }

            existingOrderItem.CarId = orderItem.CarId;
            existingOrderItem.Quantity = orderItem.Quantity;
            existingOrderItem.UnitPrice = orderItem.UnitPrice;

            _context.OrderItems.Update(existingOrderItem);
            _context.SaveChanges();

            return NoContent();
        }

        // DELETE: api/Orders/{id}/OrderItems/{itemId}
        [HttpDelete("{id}/OrderItems/{itemId}")]
        public ActionResult<OrderItem> DeleteOrderItem(Guid id, Guid itemId)
        {
            var existingOrder = _context.Orders.Find(id);
            if (existingOrder == null)
            {
                return NotFound();
            }

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
using System.Collections.Generic;
using System.Linq;
using LampApp.Core.DomainService;
using LampApp.Core.Entity;
using Microsoft.EntityFrameworkCore;

namespace LampApp.Infrastructure.Data.Repositories
{
    
    public class OrderRepositories : IOrderRepository
    {
        readonly LampAppContext _ltx;

        public OrderRepositories(LampAppContext ltx)
        {
            _ltx = ltx;
        }
        
        public Order Create(Order order)
        {
            _ltx.Attach(order).State = EntityState.Added;
            _ltx.SaveChanges();
            return order;
        }

        public Order ReadyById(int id)
        {
            return _ltx.Orders.Include(o => o.OrderLines)
                .ThenInclude(ol => ol.Lamp)
                .FirstOrDefault(o => o.Id == id);
        }

        public IEnumerable<Order> ReadAll(Filter filter = null)
        {
            if (filter == null)
            {
                return _ltx.Orders;
            }

            return _ltx.Orders
                .Skip((filter.CurrentPage - 1) * filter.ItemsPrPage)
                .Take(filter.ItemsPrPage);
        }

        public int Count()
        {
            return _ltx.Orders.Count();
        }

        public Order Update(Order OrderUpdate)
        {
            var newOrderLines = new List<OrderLine>(OrderUpdate.OrderLines);
            _ltx.Attach(OrderUpdate).State = EntityState.Modified;
            _ltx.OrderLines.RemoveRange(
                _ltx.OrderLines.Where(ol => ol.OrderId == OrderUpdate.Id));

            foreach (var ol in newOrderLines)
            {
                _ltx.Entry(ol).State = EntityState.Added;
            }
            _ltx.SaveChanges();
            return OrderUpdate;
        }

        public Order Delete(int id)
        {
            var remove = _ltx.Remove(new Order {Id = id}).Entity;
            _ltx.SaveChanges();
            return remove;
        }
    }
}
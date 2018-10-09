using System.Collections.Generic;
using System.IO;
using System.Linq;
using LampApp.Core.DomainService;
using LampApp.Core.Entity;

namespace LampApp.Core.ApplicationService.Services
{
    public class OrderService : IOrderService
    {
        readonly IOrderRepository _orderRepo;
        readonly ILampRepository _lampRepo;

        public OrderService(IOrderRepository orderRepo,
            ILampRepository lampRepository)
        {
            _orderRepo = orderRepo;
            _lampRepo = lampRepository;
        }
        public Order CreateOrder(Order order)
        {
                throw new InvalidDataException("Lamp not found");
            if (order.OrderDate == null)
                throw new InvalidDataException("Order need an order date");
            return _orderRepo.Create(order);
        }

        public Order ReadyById(int id)
        {
            return _orderRepo.ReadyById(id);
        }

        public List<Order> GetFilteredOrder(Filter filter)
        {
            if (filter.CurrentPage < 0 || filter.ItemsPrPage <0)
            {
                throw new InvalidDataException("Current and ItemsPage must be zero or more");
            }

            if ((filter.CurrentPage -1 * filter.ItemsPrPage) >= _orderRepo.Count())
            {
                throw new InvalidDataException("Index out of bounds, currentPage is to high");
            }

            return _orderRepo.ReadAll(filter).ToList();
        }

        public List<Order> ReadAll()
        {
            return _orderRepo.ReadAll().ToList();
        }

        public Order Update(Order OrderUpdate)
        {
            return _orderRepo.Update(OrderUpdate);
        }

        public Order Delete(int id)
        {
            return _orderRepo.Delete(id);
        }
    }
}
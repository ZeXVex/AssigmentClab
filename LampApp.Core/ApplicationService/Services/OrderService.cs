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
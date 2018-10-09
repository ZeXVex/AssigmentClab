using System.Collections.Generic;
using System.IO;
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
            if (order.Lamps == null || order.Lamps.Id <= 0)
                throw new InvalidDataException("To Create order please create a lamp");
            if (_lampRepo.ReadById(order.Lamps.Id) == null)
                throw new InvalidDataException("Lamp not found");
            if (order.OrderDate == null)
                throw new InvalidDataException("Order need an order date");
            return _orderRepo.Create(order);
        }

        public Order ReadyById(int id)
        {
            throw new System.NotImplementedException();
        }

        public List<Order> ReadAll()
        {
            throw new System.NotImplementedException();
        }

        public Order Update(Order OrderUpdate)
        {
            throw new System.NotImplementedException();
        }

        public Order Delete(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
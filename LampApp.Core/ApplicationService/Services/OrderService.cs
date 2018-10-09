using System.Collections.Generic;
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
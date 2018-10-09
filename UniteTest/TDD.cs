using System;
using System.Collections.Generic;
using LampApp.Core.ApplicationService;
using LampApp.Core.ApplicationService.Services;
using LampApp.Core.DomainService;
using LampApp.Core.Entity;
using Xunit;
using Moq;
namespace UniteTest


{
    public class TDD
    {
        [Fact]
        public void CreateOrderWithLamp()
        {
            var lampRepo = new Mock<ILampRepository>();
            lampRepo.Setup(x => x.ReadById(It.IsAny<int>()))
                .Returns(new Lamp(){Id = 1});
            
            var orderRepo = new Mock<IOrderRepository>();
            IOrderService service =
                new OrderService(orderRepo.Object, lampRepo.Object);
            var order = new Order()
            {
                Lamps = new Lamp() {Id = 1},
                DeliveryDate = DateTime.Now,
                OrderDate = DateTime.Now
            };
            service.CreateOrder(order);
            orderRepo.Verify(x => x.Create(It.IsAny<Order>()), Times.Once);
            
        }
    }
}
using System;
using System.Collections.Generic;
using System.IO;
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
        public void CreateOrderWithMissingLampExecption()
        {
            var lampRepo = new Mock<ILampRepository>();
            var orderRepo = new Mock<IOrderRepository>();
            IOrderService service =
                new OrderService(orderRepo.Object, lampRepo.Object);
            var order =new Order()
            {
                OrderDate = DateTime.Now,
                DeliveryDate = DateTime.Now
            };
            Exception ex = Assert.Throws<InvalidDataException>(() =>
                service.CreateOrder(order));
            Assert.Equal("To Create order please create a lamp", ex.Message);
        }
    }
}
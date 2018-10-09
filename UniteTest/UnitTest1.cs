using System;
using System.IO;
using LampApp.Core.ApplicationService;
using LampApp.Core.ApplicationService.Services;
using LampApp.Core.DomainService;
using LampApp.Core.Entity;
using Moq;
using Xunit;

namespace UniteTest
{
    public class UnitTest1
    {
        [Fact]
        public void CreateOrderMissingOrderDate()
        {
            var lampRepo = new Mock<ILampRepository>();
            lampRepo.Setup(x => x.ReadById(It.IsAny<int>()))
                .Returns(new Lamp(){Id = 1});
            
            var orderRepo = new Mock<IOrderRepository>();
            IOrderService service =
                new OrderService(orderRepo.Object, lampRepo.Object);
            var order = new Order()
            {
                Lamps = new Lamp(){Id = 1},
                DeliveryDate = DateTime.Now
            };
            Exception ex = Assert.Throws<InvalidDataException>(() =>
                service.CreateOrder(order));
            Assert.Equal("Order need an order date", ex.Message);
        }
    }
}
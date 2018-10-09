using System;
using LampApp.Core.Entity;

namespace LampApp.Infrastructure.Data
{
    public class DBInitializer
    {
        public static void SeedDB(LampAppContext ltx)
        {
            ltx.Database.EnsureDeleted();
            ltx.Database.EnsureCreated();
            var lamp1 = ltx.Lamps.Add(new Lamp()
            {
                Name = "Column Floor Lamp",
                Color = "Black",
                Designer = "Zipcode Design",
                Price = 45,
                Qty = 8,
            }).Entity;
            
            var lamp2 = ltx.Lamps.Add(new Lamp()
            {
                Name = "Tree Floor Lamp",
                Color = "White",
                Designer = "House of Hampton",
                Price = 45,
                Qty = 8,
            }).Entity;
            
            var order1 = ltx.Orders.Add(new Order()
            {
                DeliveryDate = DateTime.Now,
                OrderDate = DateTime.Now
            }).Entity;
            
            var order2 = ltx.Orders.Add(new Order()
            {
                DeliveryDate = DateTime.Now,
                OrderDate = DateTime.Now
            }).Entity;

            ltx.OrderLines.Add(new OrderLine()
            {
                Lamp = lamp1,
                Order = order2
            });
            
            ltx.OrderLines.Add(new OrderLine()
            {
                Lamp = lamp2,
                Order = order1
            });
            ltx.SaveChanges();
        }
    }
}
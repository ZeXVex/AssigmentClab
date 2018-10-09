using System;
using System.Collections.Generic;

namespace LampApp.Core.Entity
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public Lamp Lamps { get; set; }
    }
}
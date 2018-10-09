namespace LampApp.Core.Entity
{
    public class OrderLine
    {
        public int LampId { get; set; }
        public Lamp Lamp { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public int Qty { get; set; }
    }
}
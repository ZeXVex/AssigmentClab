namespace LampApp.Core.Entity
{
    public class Lamp
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public string Comoany { get; set; }
        public double Price { get; set; }
        public int Qty { get; set; }
        public Order Order { get; set; }
    }
}
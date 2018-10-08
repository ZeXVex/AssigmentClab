namespace LampApp.Core.ApplicationService
{
    public interface IOrderService
    {
        //Create Data
        //No Id when enter, but Id when exits
        Order Create(Order order);
        //Read Data
        Order ReadyById(int id);
        IEnumerable<Order> ReadAll(Filter filter = null);
        int Count();
        //Update Data
        Order Update(Order OrderUpdate);
        //Delete Data
        Order Delete(int id);
    }
}
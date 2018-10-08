using System.Collections.Generic;
using LampApp.Core.Entity;

namespace LampApp.Core.DomainService
{
    public interface IOrderRepository
    {
        //Create Data
        //No Id when enter, but Id when exits
        Order Create(Order order);
        //Read Data
        Order ReadyById(int id);
        IEnumerable<Order> ReadAll<Filter>(Filter filter = null);
        int Count();
        //Update Data
        Order Update(Order OrderUpdate);
        //Delete Data
        Order Delete(int id);
    }
}
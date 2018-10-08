using System.Collections.Generic;
using LampApp.Core.Entity;

namespace LampApp.Core.ApplicationService
{
    public interface IOrderService
    {
        //Create Data
        //No Id when enter, but Id when exits
        Order Create(Order order);
        //Read Data
        Order ReadyById(int id);
        List<Order> ReadAll();
        //Update Data
        Order Update(Order OrderUpdate);
        //Delete Data
        Order Delete(int id);
    }
}
using System.Collections.Generic;
using LampApp.Core.ApplicationService.Services;

namespace LampApp.Core.DomainService
{
    public interface ICustomerRepository
    {
        //CustomerRepository Interface
        //Create Data
        //No Id when enter, but Id when exits
        Customer Create(Customer customer);
        //Read Data
        Customer ReadyById(int id);
        IEnumerable<Customer> ReadAll();
        //Update Data
        Customer Update(Customer customerUpdate);
        //Delete Data
        Customer Delete(int id);
        Customer ReadyByIdIncludeOrders(int id);
    }
}
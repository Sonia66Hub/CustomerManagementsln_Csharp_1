using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomerManagement.Entites;

namespace CustomerManagement.Contracts
{
    public interface ICustomerContract
    {
        IEnumerable<Customer> GetCustomers();
        Customer GetCustomer(int id);
        Customer CreateNewCustomer(Customer customer);
        Customer UpdateCustomer(Customer customer);
        Customer DeleteCustomer(int id);
    }
}

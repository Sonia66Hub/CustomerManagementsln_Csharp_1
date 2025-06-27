using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomerManagement.Entites;
using CustomerManagement.Enums;

namespace CustomerManagement.Factory
{
    public class CustomerManagerFactory
    {
        public BaseCustomerFactory CreateFactory(Customer customer)
        {
            BaseCustomerFactory returnValue = null;
            if (customer.Type == CustomerType.Regular)
            {
                returnValue = new RegularCustomerFactory(customer);
            }
            else if (customer.Type == CustomerType.Irregular)
            {
                returnValue = new IrregularCustomerFactory(customer);
            }
            return returnValue;
        }
    }
}

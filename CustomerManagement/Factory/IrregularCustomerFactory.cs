using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomerManagement.Entites;
using CustomerManagement.Manager;

namespace CustomerManagement.Factory
{
    public class IrregularCustomerFactory : BaseCustomerFactory
    {

        public IrregularCustomerFactory(Customer customer):base(customer) 
        {
           
        }
        public override ICustomerManager Create()
        {
            IrregularCustomerManager manager= new IrregularCustomerManager();
            decimal price=_customer.TotalPrice;
            return manager;
        }
    }
}

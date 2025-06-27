using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomerManagement.Entites;
using CustomerManagement.Manager;

namespace CustomerManagement.Factory
{
    public class RegularCustomerFactory : BaseCustomerFactory
    {
        public RegularCustomerFactory(Customer customer):base(customer) 
        
        {
            
        }
        public override ICustomerManager Create()
        {
            RegularCustomerManager manager = new RegularCustomerManager(); 
            decimal Price=_customer.TotalPrice;
            return manager;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomerManagement.Entites;
using CustomerManagement.Enums;
using CustomerManagement.Manager;

namespace CustomerManagement.Factory
{
    public abstract class BaseCustomerFactory
    {
        public abstract ICustomerManager Create();
        protected Customer _customer;

        public BaseCustomerFactory(Customer customer)
        {
            _customer=customer;
        }

        public Customer ApplyCost()
        {
            ICustomerManager customerManager =this.Create();
            _customer.TotalPriceDiscount = customerManager.GetDiscount();
            if (_customer.Type == CustomerType.Regular)
            {
                _customer.TotalAmount = _customer.TotalPrice * _customer.TotalPriceDiscount / 100;
            }
            else
            {
                _customer.TotalAmount= _customer.TotalPrice;
            }
            _customer.TotalPriceDiscount= customerManager.GetDiscount()/100 * _customer.TotalPrice;
            _customer.TotalAmount= _customer.TotalPrice- _customer.TotalPriceDiscount;
            return _customer;
        }
    }
}

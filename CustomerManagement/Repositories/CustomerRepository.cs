using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomerManagement.Contracts;
using CustomerManagement.Entites;
using CustomerManagement.Enums;

namespace CustomerManagement.Repositories
{
    public class CustomerRepository : ICustomerContract
    {
        private readonly List<Customer> customerList;
        public CustomerRepository()
        {
            customerList = new List<Customer>()
            { 
                new Customer() {Id=1,Name="Sonia",Email="Sonia@gmail.com",Type= CustomerType.Regular,PaymentType=PaymentType.DebitCard,TotalPrice=200000,TotalPriceDiscount=0,TotalAmount=0},

                new Customer() {Id=2,Name="Yesmin",Email="Yesmin@gmail.com",Type= CustomerType.Irregular,PaymentType=PaymentType.CreditCard,TotalPrice=300000,TotalPriceDiscount=0,TotalAmount=0 },

                new Customer() {Id=3,Name="Habiba",Email="Habiba@gmail.com",Type= CustomerType.Regular,PaymentType=PaymentType.BankTransfer,TotalPrice=400000,TotalPriceDiscount=0,TotalAmount=0 },

                new Customer() {Id=4,Name="Mahia",Email="Mahia@gmail.com",Type= CustomerType.Irregular,PaymentType=PaymentType.DebitCard,TotalPrice=300000,TotalPriceDiscount=0,TotalAmount=0 },

                new Customer() {Id=5,Name="Rifah",Email="Rifah@gmail.com",Type= CustomerType.Regular,PaymentType=PaymentType.CreditCard,TotalPrice=500000,TotalPriceDiscount=0,TotalAmount=0 },

                new Customer() {Id=6,Name="Rubina",Email="Rubina@gmail.com",Type= CustomerType.Irregular,PaymentType=PaymentType.DebitCard ,TotalPrice=200000,TotalPriceDiscount=0,TotalAmount=0},

                new Customer() {Id=7,Name="Ruma",Email="Ruma@gmail.com",Type= CustomerType.Regular,PaymentType=PaymentType.BankTransfer,TotalPrice=300000,TotalPriceDiscount=0,TotalAmount=0 },

                new Customer() {Id=8,Name="Sima",Email="Sima@gmail.com",Type= CustomerType.Irregular,PaymentType=PaymentType.DebitCard,TotalPrice=600000,TotalPriceDiscount=0,TotalAmount=0 },

                new Customer() {Id=9,Name="Shajib",Email="Shajib@gmail.com",Type= CustomerType.Regular,PaymentType=PaymentType.BankTransfer,TotalPrice=100000,TotalPriceDiscount=0,TotalAmount=0 },

                new Customer() {Id=10,Name="Rajib",Email="Rajib@gmail.com",Type= CustomerType.Irregular,PaymentType=PaymentType.DebitCard,TotalPrice=300000,TotalPriceDiscount=0,TotalAmount=0 }
            };
        }
        public Customer CreateNewCustomer(Customer customer)
        {
            Customer existingCustomer=(from c in customerList orderby c.Id descending select c).FirstOrDefault();
            customer.Id = existingCustomer.Id+1;
            customerList.Add(customer);
            return customer;
        }

        public Customer DeleteCustomer(int id)
        {
           var customer=GetCustomer(id);
            if (customer != null)
            { 
                customerList.Remove(customer);
            }
            return customer;
        }

        public Customer GetCustomer(int id)
        {
           var customer=(from row in customerList where row.Id==id select row).FirstOrDefault();
            return customer;
        }

        public IEnumerable<Customer> GetCustomers()
        {
           return from rows in customerList select rows;
        }

        public Customer UpdateCustomer(Customer customer)
        {
            Customer customer1 = GetCustomer(customer.Id);
            if (customer1 != null)
            {
                customer1.Name = customer.Name;
                customer1.Email = customer.Email;
                customer1.Type = customer.Type;
                customer1.PaymentType = customer.PaymentType;
                customer1.TotalPrice=customer.TotalPrice;
                customer1.TotalPriceDiscount=customer.TotalPriceDiscount;
                customer1.TotalAmount=customer.TotalAmount;
            }
            return customer1;
        }
    }
}

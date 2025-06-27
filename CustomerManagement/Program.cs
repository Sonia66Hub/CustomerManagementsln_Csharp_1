using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using CustomerManagement.Entites;
using CustomerManagement.Enums;
using CustomerManagement.Factory;
using CustomerManagement.Repositories;

namespace CustomerManagement
{
    internal class Program
    {
        public static CustomerRepository repo=new CustomerRepository();
        static void Main(string[] args)
        {
            try
            {
                DoTask();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.ReadLine();
            }
        }

        private static void DoTask()
        {
            int operation = 0;

            Console.WriteLine("\t\t\t\t\t\t\t    **Trainee Information**\r");
            Console.WriteLine("\t\t\t\t\t\t\t   =========================\n");
            Console.WriteLine();
            Console.WriteLine("\t\t\t\t\t\t\t *Trainee Name\t: SONIA KHATUN\r");
            Console.WriteLine("\t\t\t\t\t\t\t *Trainee ID\t: 1285868\r");
            Console.WriteLine("\t\t\t\t\t\t\t *Batch ID\t: CS/SCSL-M/63/01\r");
            Console.WriteLine("\t\t\t\t\t\t\t----------------------------------\n");
            Console.WriteLine();
            Console.WriteLine("\t\t\t\t\t\t  -----***Project on Customer Management***-----\r");
            Console.WriteLine("\t\t\t\t\t\t ===============================================\n");
            Console.WriteLine();
            Console.WriteLine("*How many operation would you like to perform?\r");
            Console.WriteLine("==================================================");
            Console.WriteLine();
            int count = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            for (int i = 0; i < count; i++)
            {

                Console.WriteLine("\t\t\t\t---Select Operation\nHints: \n1-Read,\n2-Create, \n3-Update, \n4-Delete, \n5-Single");
                operation = Convert.ToInt32(Console.ReadLine());
                switch (operation)
                {
                    case 1:
                        ShowCustomer(null);
                        break;
                    case 2:
                        CreateCustomer();
                        break;
                    case 3:
                        UpdateCustomer();
                        break;
                    case 4:
                        DeleteCustomer();
                        break;
                    case 5:
                        ShowSingleCustomer();
                        break;
                    default:
                        break;
                }
            }
        }

        private static void ShowSingleCustomer()
        {
            Console.WriteLine("Enter Customer Id");
            int cusId=Convert.ToInt32(Console.ReadLine());
            Customer customer = repo.GetCustomer(cusId);
            ShowCustomer(customer);
        }

        private static void DeleteCustomer()
        {
            Console.WriteLine();
            Console.WriteLine("\t\t\t\t\t-------------------***** Customer Deleted Successfully ****-------------------");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("\t\t\t\t\t\t\t**********Deleted Customer**********");
            Console.WriteLine();
            Console.WriteLine("\t\t\t\t\t\t\t***********All Customers************");
            Console.WriteLine("Enter Customer Id");
            int delId=Convert.ToInt32(Console.ReadLine());
            Customer customer=repo.DeleteCustomer(delId);
            ShowCustomer(customer);
        }

        private static void UpdateCustomer()
        {
            Console.WriteLine();
            Console.WriteLine("\t\t\t\t\t-------------------***** Customer Updated Successfully ****-------------------");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("\t\t\t\t\t\t\t*********Updated Customer**********");
            Console.WriteLine();
            Console.WriteLine("\t\t\t\t\t\t\t***********All Projects*********");    
            Console.WriteLine("Enter Customer Id");
            int cusId=Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Customer Name");
            string name=Console.ReadLine();
            Console.WriteLine("Enter Customer Email");
            string email=Console.ReadLine();
            EnterCustomerType:
            Console.WriteLine("Enter Customer Type Hints:\n1--Regular,\n2--Irregular");
            int cusType=Convert.ToInt32(Console.ReadLine());
            CustomerType type;
            try
            {
                type=(CustomerType)(Enum.Parse(typeof(CustomerType) ,cusType.ToString()));
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                goto EnterCustomerType;
            }
            EnterPaymentType:
            Console.WriteLine("Enter Customer Payment Type Hints:\n1--CreditCard,\n2--DebitCard,\n3--BankTransfer");
            int payType=Convert.ToInt32(Console.ReadLine());
            PaymentType paymentType;
            try
            {
                paymentType = (PaymentType)(Enum.Parse(typeof(PaymentType), payType.ToString()));
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                goto EnterPaymentType;
            }
            Console.WriteLine("Enter Total Price");
            decimal totalPrice=Convert.ToDecimal(Console.ReadLine());

            decimal totalAmount = 0;
            Customer customer=new Customer(cusId, name,email,type,paymentType,totalPrice,totalAmount);
            BaseCustomerFactory customerFactory=new CustomerManagerFactory().CreateFactory(customer);
            customerFactory.ApplyCost();
            Customer customer1 = repo.UpdateCustomer(customer);
            ShowCustomer(customer1);
        }
      
       


        private static void CreateCustomer()
        {
            Console.WriteLine();
            Console.WriteLine("\t\t\t\t\t-------------------***** Customer Added Successfully ****-------------------");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("\t\t\t\t\t\t\t*********New Customer**********");
            Console.WriteLine();
            Console.WriteLine("\t\t\t\t\t\t\t*********All Customers*********");
            

            int id = 0;
            Console.WriteLine("Enter Customer Name");
            string name=Console.ReadLine() ;
            Console.WriteLine("Enter Customer Email");
            string email = Console.ReadLine();
        EnterCustomerType:
            Console.WriteLine("Enter Customer Type Hints:\n1--Regular,\n2--Irregular");
            int cusType = Convert.ToInt32(Console.ReadLine());
            CustomerType type;
            try
            {
                type = (CustomerType)(Enum.Parse(typeof(CustomerType), cusType.ToString()));
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                goto EnterCustomerType;
            }
        EnterPaymentType:
            Console.WriteLine("Enter Customer Payment Type Hints:\n1--CreditCard,\n2--DebitCard,\n3--BankTransfer");
            int payType = Convert.ToInt32(Console.ReadLine());
            PaymentType paymentType;
            try
            {
                paymentType = (PaymentType)(Enum.Parse(typeof(PaymentType), payType.ToString()));
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                goto EnterPaymentType;
            }
            Console.WriteLine("Enter Total Price");
            decimal totalPrice = Convert.ToDecimal(Console.ReadLine());

            decimal totalAmount = 0;
            Customer customer = new Customer(id, name, email, type, paymentType,totalPrice,totalAmount);
            BaseCustomerFactory customerFactory = new CustomerManagerFactory().CreateFactory(customer);
            customerFactory.ApplyCost();
            Customer customer1 = repo.CreateNewCustomer(customer);
            ShowCustomer(customer1);

           
        }
       

        private static void ShowCustomer(Customer cus)
        {
           List<Customer> customers = new List<Customer>();
            Console.WriteLine(string.Format("|{0,5}|{1,10}|{2,20}|{3,10}|{4,15}| {5,15}|{6,15}|{7,15}|", "ID", "Name", "Email",  "Type", "PaymentType","Total Price","DisCount","Total Amount"));
            Console.WriteLine("===================================================================================================================");
            if (cus == null)
            {
                customers = repo.GetCustomers().ToList();
                foreach (Customer item in customers)
                {
                    Console.WriteLine(string.Format("|{0,5}|{1,10}|{2,20}|{3,10}|{4,15}|{5,15}|{6,15}|{7,15}| ", item.Id, item.Name, item.Email, item.Type, item.PaymentType,item.TotalPrice,item.TotalPriceDiscount,item.TotalAmount));
                    Console.WriteLine("===================================================================================================================");
                }
                Console.WriteLine("===================================================================================================================");
            }
            else
            {
                Console.WriteLine(string.Format("|{0,5}|{1,10}|{2,-20}|{3,10}|{4,15}| {5,15}|{6,15}|{7,15}|", cus.Id, cus.Name, cus.Email, cus.Type, cus.PaymentType,cus.TotalPrice,cus.TotalPriceDiscount,cus.TotalAmount));
                Console.WriteLine("===================================================================================================================");
            }
            Console.WriteLine();
        }
    }
    
}

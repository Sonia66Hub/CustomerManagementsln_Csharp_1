using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomerManagement.Enums;

namespace CustomerManagement.Entites
{
    public class Customer
    {
        int id;
        string name;
        string email;
        CustomerType type;
       PaymentType paymentType;
        decimal totalPrice;
        decimal totalPriceDiscount;
        decimal totalAmount;

        public Customer()
        {
            
        }

        

        public Customer(int id, string name, string email, CustomerType type, PaymentType paymentType, decimal totalPrice,  decimal totalAmount)
        {
            this.Id = id;
            this.Name = name;
            this.Email = email;
            this.Type = type;
            this.PaymentType = paymentType;
            this.TotalPrice = totalPrice;
            this.TotalPriceDiscount = totalPriceDiscount;
            this.TotalAmount = totalAmount;
        }

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Email { get => email; set => email = value; }
        public CustomerType Type { get => type; set => type = value; }
        public PaymentType PaymentType { get => paymentType; set => paymentType = value; }
        public decimal TotalPrice { get => totalPrice; set => totalPrice = value; }
        public decimal TotalPriceDiscount { get => totalPriceDiscount; set => totalPriceDiscount = value; }
        public decimal TotalAmount { get => totalAmount; set => totalAmount = value; }
    }
}

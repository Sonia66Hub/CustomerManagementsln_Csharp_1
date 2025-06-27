using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.Manager
{
    public class RegularCustomerManager : ICustomerManager
    {
        public decimal GetDiscount()
        {
            return 10;
        }
    }
}

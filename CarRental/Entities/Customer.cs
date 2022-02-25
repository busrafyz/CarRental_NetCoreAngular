using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRental.Entities
{
    public class Customer
    {
        public int CustomerId { get; set; }

        public int UserId { get; set; }
        public string CompanyName { get; set; }
    }
}

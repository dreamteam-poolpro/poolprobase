using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace poolprobase.Web.Models.Customer
{
    public class Customer
    {
        //primary key
        public int CustomerID { get; set; }

        //data
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }

        
        //associated 
        public List<WorkOrder> WorkOrders { get; set; }
        

    }
}

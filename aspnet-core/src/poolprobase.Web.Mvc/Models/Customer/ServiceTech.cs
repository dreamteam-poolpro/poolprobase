using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace poolprobase.Web.Models.Customer
{
    public class ServiceTech
    {
        // primary key
        public int ServiceTechID { get; set; }

        // foreign key

        // data
        public string FirstName { get; set; }
        public string LastName { get; set; }

        //navigation properties
        public List<WorkOrder> CU_WorkOrders { get; set; }
        
    }
}

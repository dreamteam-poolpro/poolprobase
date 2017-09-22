using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace poolprobase.Web.Models.Customer
{
    public class WorkOrder
    {
        //primary key
        public int WorkOrderID { get; set; }
        
        //foreign key
        public int CustomerID { get; set; }
        public int ServiceTechID { get; set; }

        //data
        public List<LineItem> LineItems { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace poolprobase.Web.Models.Customer
{
    
    public enum Status
    {
        Assigned, InProgress, Completed, Invoiced, Paid
    }

    public class WorkOrder
    {
       //primary key
       public int WorkOrderID { get; set; }

       //foreign key
       public int CustomerID { get; set; }
       public int ServiceTechID { get; set; }

       //navigation properties
       public Customer WO_Customer { get; set; }
       public ServiceTech WO_ServiceTech { get; set; }
       public List<LineItem> WO_LineItems { get; set; }

        //properties
        public Status WO_Status { get; set; } = Status.Assigned;

    }
}

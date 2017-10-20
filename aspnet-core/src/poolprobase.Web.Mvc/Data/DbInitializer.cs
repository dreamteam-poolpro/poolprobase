using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using poolprobase.Web.Models.Customer;

namespace poolprobase.Web.Data
{
    public class DbInitializer
    {
        public static void Initialize(CustomerContext context)
        {
            if (context.Customers.Any())
            {
                return;
            }

            //add customers
            var customer = new Customer[]
            {
                new Customer{FirstName="John", LastName="Smith", Address="1234 Main St.\nNorth Port, Florida, 34287", EmailAddress="john.smith@gmail.com", PhoneNumber="555-555-5555"},
                new Customer{FirstName="Tim", LastName="Doe", Address="1234 Main St.\nTucson, Arizona, 12345", EmailAddress="tim.doe@gmail.com", PhoneNumber="555-555-5555"}
            };

            foreach(Customer c in customer)
            {
                context.Customers.Add(c);
            }

            //add lineitems
            var lineitems = new LineItem[]
            {
           //     new LineItem{Description="Labor", Unit="Hours", UnitCost=50.00, Quantity=80, WorkOrderID=1},
            //    new LineItem{Description="Labor", Unit="Hours", UnitCost=50.00, Quantity=160, WorkOrderID=2},
            //    new LineItem{Description="Tile", Unit="Boxes", UnitCost=75.00, Quantity=10, WorkOrderID=1},
            //    new LineItem{Description="CoolKrete", Unit="Bags", UnitCost=30.00, Quantity=80, WorkOrderID=2 }
            };
            foreach(LineItem l in lineitems)
            {
                context.LineItems.Add(l);
            }

            //add work orders
            var workorder = new WorkOrder[]
            {
                new WorkOrder{CustomerID=1, ServiceTechID=1},
                new WorkOrder{CustomerID=2, ServiceTechID=1}
            };
            foreach(WorkOrder w in workorder)
            {
                context.WorkOrders.Add(w);
            }

            //add service techs
            var servicetech = new ServiceTech[]
            {
                new ServiceTech{FirstName="Jerry", LastName="Davis"}
            };
            foreach(ServiceTech s in servicetech)
            {
                context.ServiceTechs.Add(s);
            }

            context.SaveChanges();



        }

    }
}

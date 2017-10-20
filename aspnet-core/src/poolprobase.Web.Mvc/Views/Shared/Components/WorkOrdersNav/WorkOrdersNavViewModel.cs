using Abp.Application.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace poolprobase.Web.Views.Shared.Components.WorkOrdersNav
{
    public class WorkOrdersNavViewModel
    {
        public UserMenu WorkOrders { get; set; }

        public String ActiveMenuItemName { get; set; }

    }
}

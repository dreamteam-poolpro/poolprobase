using System.Threading.Tasks;
using Abp.Application.Navigation;
using Abp.Runtime.Session;
using Microsoft.AspNetCore.Mvc;

namespace poolprobase.Web.Views.Shared.Components.WorkOrdersNav
{
    public class WorkOrdersNavViewCompenent : poolprobaseViewComponent
    {
        private readonly IUserNavigationManager _userNavigationManager;
        private readonly IAbpSession _abpSession;

        public WorkOrdersNavViewCompenent(
            IUserNavigationManager userNavigationManager,
            IAbpSession abpSession
            )
        {
            _userNavigationManager = userNavigationManager;
            _abpSession = abpSession;
        }

        //public async<IViewComponentComponent> InvokeAsync(string activeMenu = "")
        //{
        //    WorkOrdersMenu = await _userNavigationManager.GetMenuAsync("Menus[WorkOrders]", _abpSession.ToUserIdentifier()),
        //    ActiveMenuItemName = activeMenu;
        //};

    }
}

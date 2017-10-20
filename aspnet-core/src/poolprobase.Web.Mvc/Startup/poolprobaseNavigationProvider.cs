using Abp.Application.Navigation;
using Abp.Localization;
using poolprobase.Authorization;
using poolprobase.Web.Models.Customer;
using poolprobase.Web.Startup;

namespace poolprobase.Web.Startup
{
    /// <summary>
    /// This class defines menus for the application.
    /// </summary>
    public class poolprobaseNavigationProvider : NavigationProvider
    {
        public override void SetNavigation(INavigationProviderContext context)
        {
            context.Manager.MainMenu
                .AddItem(
                    new MenuItemDefinition(
                        PageNames.Home,
                        L("HomePage"),
                        url: "",
                        icon: "home",
                        requiresAuthentication: true
                    )
                ).AddItem(
                    new MenuItemDefinition(
                        PageNames.Tenants,
                        L("Tenants"),
                        url: "Tenants",
                        icon: "business",
                        requiredPermissionName: PermissionNames.Pages_Tenants
                    )
                ).AddItem(
                    new MenuItemDefinition(
                        PageNames.Customers,
                        L("Customers"),
                        url: "Customers",
                        icon: "business",
                        requiredPermissionName: PermissionNames.Pages_Customers
                    )
                ).AddItem(
                new MenuItemDefinition(
                        PageNames.ServiceTechs,
                        L("ServiceTechs"),
                        url: "ServiceTechs",
                        icon: "people",
                        requiredPermissionName: PermissionNames.Pages_ServiceTechs
                    )
                ).AddItem(
                new MenuItemDefinition(
                        PageNames.WorkOrders,
                        L("WorkOrders"),
                        url: "WorkOrders",
                        icon: "menu",
                        requiredPermissionName: PermissionNames.Pages_WorkOrders
                    )
                ).AddItem(
                    new MenuItemDefinition(
                        PageNames.Roles,
                        L("Roles"),
                        url: "Roles",
                        icon: "local_offer",
                        requiredPermissionName: PermissionNames.Pages_Roles
                    )
                ).AddItem(
                new MenuItemDefinition(
                    PageNames.Users,
                    L("Users"),
                    url: "Users",
                    icon: "local_offer",
                    requiredPermissionName: PermissionNames.Pages_Users
                )
                )
                .AddItem(
                    new MenuItemDefinition(
                        PageNames.About,
                        L("About"),
                        url: "About",
                        icon: "info"
                    )
                ).AddItem( //Menu items below is just for demonstration!
                    new MenuItemDefinition(
                        "MultiLevelMenu",
                        L("MultiLevelMenu"),
                        icon: "menu"
                    ).AddItem(
                        new MenuItemDefinition(
                            "AspNetBoilerplate",
                            new FixedLocalizableString("ASP.NET Boilerplate")
                        ).AddItem(
                            new MenuItemDefinition(
                                "AspNetBoilerplateHome",
                                new FixedLocalizableString("Home"),
                                url: "https://aspnetboilerplate.com?ref=abptmpl"
                            )
                        ).AddItem(
                            new MenuItemDefinition(
                                "AspNetBoilerplateTemplates",
                                new FixedLocalizableString("Templates"),
                                url: "https://aspnetboilerplate.com/Templates?ref=abptmpl"
                            )
                        ).AddItem(
                            new MenuItemDefinition(
                                "AspNetBoilerplateSamples",
                                new FixedLocalizableString("Samples"),
                                url: "https://aspnetboilerplate.com/Samples?ref=abptmpl"
                            )
                        ).AddItem(
                            new MenuItemDefinition(
                                "AspNetBoilerplateDocuments",
                                new FixedLocalizableString("Documents"),
                                url: "https://aspnetboilerplate.com/Pages/Documents?ref=abptmpl"
                            )
                        )
                    ).AddItem(
                        new MenuItemDefinition(
                            "AspNetZero",
                            new FixedLocalizableString("ASP.NET Zero")
                        ).AddItem(
                            new MenuItemDefinition(
                                "AspNetZeroHome",
                                new FixedLocalizableString("Home"),
                                url: "https://aspnetzero.com?ref=abptmpl"
                            )
                        ).AddItem(
                            new MenuItemDefinition(
                                "AspNetZeroDescription",
                                new FixedLocalizableString("Description"),
                                url: "https://aspnetzero.com/?ref=abptmpl#description"
                            )
                        ).AddItem(
                            new MenuItemDefinition(
                                "AspNetZeroFeatures",
                                new FixedLocalizableString("Features"),
                                url: "https://aspnetzero.com/?ref=abptmpl#features"
                            )
                        ).AddItem(
                            new MenuItemDefinition(
                                "AspNetZeroPricing",
                                new FixedLocalizableString("Pricing"),
                                url: "https://aspnetzero.com/?ref=abptmpl#pricing"
                            )
                        ).AddItem(
                            new MenuItemDefinition(
                                "AspNetZeroFaq",
                                new FixedLocalizableString("Faq"),
                                url: "https://aspnetzero.com/Faq?ref=abptmpl"
                            )
                        ).AddItem(
                            new MenuItemDefinition(
                                "AspNetZeroDocuments",
                                new FixedLocalizableString("Documents"),
                                url: "https://aspnetzero.com/Documents?ref=abptmpl"
                            )
                        )
                    )
                );

            // still trying to figure out how to create another menu, there are several interfaces/objects required, still sorting through them,
            // I'm pretty sure the new menu has to be added here and then registered somewhere, not sure where it needs to be registered

            //context.Manager.Menus.Add(); - is used to add a new menu, //.Add requires a MenuItemDefinition, signature is below
            //intellisense tells me it takes a disctionary
            //context.Manager.Menus.Add(string key, MenuDefinition value);

            // key - I believe this is just a name that can be ignored because the Localication will be used instead, "WorkOrdersMenu" should work fine

            // MenuDefinition - public MenuDefinition(string name, ILocalizableString displayName, object customData = null);
            // name - I believe this should match the previously defined key, "WorkOrdersMenu"
            // displayName - I think this is what would displayed when I use the @L("WorkOrdersMenu"), so "Work Orders Menu"
            // customData - this is probably where I would require the link to have associated data like an id to pass into a controller method

            //context.Manager.Menus.Add("WorkOrdersMenu", new MenuDefinition("WorkOrdersMenu", "Work Orders Menu", Models.) ) );
            // ^^ work in progress


            //context.Manager.Menus.Add("WorkOrdersMenu", new MenuDefinition("WorkOrders", L("WorkOrdersMenu")));
            // ^^ the example I was given on stackoverflow

            //context.Manager.name.AddItem(); - is use to add menu items
            ////public MenuItemDefinition(string name, ILocalizableString displayName, string icon = null, string url = null, bool requiresAuthentication = false, string requiredPermissionName = null, int order = 0, object customData = null, IFeatureDependency featureDependency = null, string target = null, bool isEnabled = true, bool isVisible = true, IPermissionDependency permissionDependency = null);

            //context.Manager.Menus.Add("WorkOrdersMenu", new MenuDefinition(PageNames.WorkOrders, L("WorkOrdersMenu")));
            // ^^ work in progress


        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, poolprobaseConsts.LocalizationSourceName);
        }
    }
}

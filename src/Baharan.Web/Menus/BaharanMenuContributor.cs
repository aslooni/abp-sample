using System.Threading.Tasks;
using Baharan.Localization;
using Baharan.MultiTenancy;
using Baharan.Permissions;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Identity.Web.Navigation;
using Volo.Abp.SettingManagement.Web.Navigation;
using Volo.Abp.TenantManagement.Web.Navigation;
using Volo.Abp.UI.Navigation;
namespace Baharan.Web.Menus;
public class BaharanMenuContributor : IMenuContributor
{
    public async Task ConfigureMenuAsync(MenuConfigurationContext context)
    {
        if (context.Menu.Name == StandardMenus.Main)
        {
            await ConfigureMainMenuAsync(context);
        }
    }
    private Task ConfigureMainMenuAsync(MenuConfigurationContext context)
    {
        var l = context.GetLocalizer<BaharanResource>();
        context.Menu.Items.Insert(
            0,
            new ApplicationMenuItem(
                BaharanMenus.Home,
                l["Menu:Home"],
                "~/",
                icon: "fas fa-home",
                order: 0
            )
        );
        //context.Menu.AddItem(new ApplicationMenuItem(
        //    BaharanMenus.Documents,
        //    l["Documents"],
        //    icon: "fas fa-book",
        //    url: "/Documents").RequirePermissions(BaharanPermissions.Documents.Menu));
        context.Menu.AddItem(new ApplicationMenuItem(
          BaharanMenus.Personnels,
          l["Personnels"],
          icon: "fas fa-user",
          url: "/Personnels").RequirePermissions(BaharanPermissions.Personnels.Menu));
        //context.Menu.AddItem(new ApplicationMenuItem(
        //  BaharanMenus.Experinces,
        //  l["Experinces"],
        //  icon: "fas fa-history",
        //  url: "/Experinces").RequirePermissions(BaharanPermissions.Experiences.Menu));
        context.Menu.AddItem(new ApplicationMenuItem(
            BaharanMenus.Documents, 
            l["Profile"], icon: "fas fa-book",
            url: "/Profile").RequirePermissions(BaharanPermissions.Personnels.UserMenu));

        var administration = context.Menu.GetAdministration();
        if (MultiTenancyConsts.IsEnabled)
        {
            administration.SetSubItemOrder(TenantManagementMenuNames.GroupName, 1);
        }
        else
        {
            administration.TryRemoveMenuItem(TenantManagementMenuNames.GroupName);
        }
        administration.SetSubItemOrder(IdentityMenuNames.GroupName, 2);
        administration.SetSubItemOrder(SettingManagementMenuNames.GroupName, 3);
        return Task.CompletedTask;
    }
}

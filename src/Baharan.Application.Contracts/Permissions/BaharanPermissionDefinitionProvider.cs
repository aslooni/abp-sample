using Baharan.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;
namespace Baharan.Permissions;
public class BaharanPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var documentGroup = context.AddGroup(BaharanPermissions.DocumentGroupName,L("Document Managment"));
        documentGroup.AddPermission(BaharanPermissions.Documents.Default, L("Default"));
        documentGroup.AddPermission(BaharanPermissions.Documents.Create, L("Create"));
        documentGroup.AddPermission(BaharanPermissions.Documents.Edit, L("Edit"));
        documentGroup.AddPermission(BaharanPermissions.Documents.Delete, L("Delete"));
        documentGroup.AddPermission(BaharanPermissions.Documents.Menu, L("Menu"));

        var personnelGroup = context.AddGroup(BaharanPermissions.PersonnelsGroupName, L("Personnel Managment"));
        personnelGroup.AddPermission(BaharanPermissions.Personnels.Default, L("Default"));
        personnelGroup.AddPermission(BaharanPermissions.Personnels.Create, L("Create"));
        personnelGroup.AddPermission(BaharanPermissions.Personnels.Edit, L("Edit"));
        personnelGroup.AddPermission(BaharanPermissions.Personnels.Delete, L("Delete"));
        personnelGroup.AddPermission(BaharanPermissions.Personnels.Menu, L("Menu"));
        personnelGroup.AddPermission(BaharanPermissions.Personnels.UserMenu, L("UserMenu"));

        var experienceGroup = context.AddGroup(BaharanPermissions.ExperienceGroupName, L("Experience Managment"));
        experienceGroup.AddPermission(BaharanPermissions.Experiences.Default, L("Default"));
        experienceGroup.AddPermission(BaharanPermissions.Experiences.Create, L("Create"));
        experienceGroup.AddPermission(BaharanPermissions.Experiences.Edit, L("Edit"));
        experienceGroup.AddPermission(BaharanPermissions.Experiences.Delete, L("Delete"));
        experienceGroup.AddPermission(BaharanPermissions.Experiences.Menu, L("Menu"));
    }
    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<BaharanResource>(name);
    }
}

using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace Account;

[DependsOn(
    typeof(AbpVirtualFileSystemModule)
    )]
public class AccountInstallerModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<AccountInstallerModule>();
        });
    }
}

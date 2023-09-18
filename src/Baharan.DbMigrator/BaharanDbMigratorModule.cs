using Baharan.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace Baharan.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(BaharanEntityFrameworkCoreModule),
    typeof(BaharanApplicationContractsModule)
    )]
public class BaharanDbMigratorModule : AbpModule
{
}

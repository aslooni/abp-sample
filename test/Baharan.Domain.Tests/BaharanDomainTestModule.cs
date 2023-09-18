using Baharan.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Baharan;

[DependsOn(
    typeof(BaharanEntityFrameworkCoreTestModule)
    )]
public class BaharanDomainTestModule : AbpModule
{

}

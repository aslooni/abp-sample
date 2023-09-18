using Volo.Abp.Modularity;

namespace Baharan;

[DependsOn(
    typeof(BaharanApplicationModule),
    typeof(BaharanDomainTestModule)
    )]
public class BaharanApplicationTestModule : AbpModule
{

}

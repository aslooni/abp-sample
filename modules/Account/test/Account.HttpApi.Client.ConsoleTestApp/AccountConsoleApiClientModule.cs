using Volo.Abp.Autofac;
using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace Account;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(AccountHttpApiClientModule),
    typeof(AbpHttpClientIdentityModelModule)
    )]
public class AccountConsoleApiClientModule : AbpModule
{

}

using Volo.Abp.Modularity;

namespace Account;

[DependsOn(
    typeof(AccountApplicationModule),
    typeof(AccountDomainTestModule)
    )]
public class AccountApplicationTestModule : AbpModule
{

}

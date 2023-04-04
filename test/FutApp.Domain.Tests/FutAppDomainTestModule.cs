using FutApp.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace FutApp;

[DependsOn(
    typeof(FutAppEntityFrameworkCoreTestModule)
    )]
public class FutAppDomainTestModule : AbpModule
{

}

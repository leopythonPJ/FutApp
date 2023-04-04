using Volo.Abp.Modularity;

namespace FutApp;

[DependsOn(
    typeof(FutAppApplicationModule),
    typeof(FutAppDomainTestModule)
    )]
public class FutAppApplicationTestModule : AbpModule
{

}

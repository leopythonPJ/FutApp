using FutApp.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace FutApp.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(FutAppEntityFrameworkCoreModule),
    typeof(FutAppApplicationContractsModule)
    )]
public class FutAppDbMigratorModule : AbpModule
{

}

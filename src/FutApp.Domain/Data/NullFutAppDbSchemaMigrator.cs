using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace FutApp.Data;

/* This is used if database provider does't define
 * IFutAppDbSchemaMigrator implementation.
 */
public class NullFutAppDbSchemaMigrator : IFutAppDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}

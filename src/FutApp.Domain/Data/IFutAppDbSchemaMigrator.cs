using System.Threading.Tasks;

namespace FutApp.Data;

public interface IFutAppDbSchemaMigrator
{
    Task MigrateAsync();
}

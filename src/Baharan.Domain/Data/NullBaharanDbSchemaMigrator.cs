using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Baharan.Data;

/* This is used if database provider does't define
 * IBaharanDbSchemaMigrator implementation.
 */
public class NullBaharanDbSchemaMigrator : IBaharanDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}

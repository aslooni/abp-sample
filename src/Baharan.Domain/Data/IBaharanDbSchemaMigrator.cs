using System.Threading.Tasks;

namespace Baharan.Data;

public interface IBaharanDbSchemaMigrator
{
    Task MigrateAsync();
}

using System.Threading.Tasks;

namespace ABP.Demo1.Data;

public interface IDemo1DbSchemaMigrator
{
    Task MigrateAsync();
}

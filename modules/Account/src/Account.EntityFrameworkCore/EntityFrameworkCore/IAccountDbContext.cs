using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace Account.EntityFrameworkCore;

[ConnectionStringName(AccountDbProperties.ConnectionStringName)]
public interface IAccountDbContext : IEfCoreDbContext
{
    /* Add DbSet for each Aggregate Root here. Example:
     * DbSet<Question> Questions { get; }
     */
}

/// <summary>
/// DBContext implementation
/// </summary>

using LiteDB;
using Microsoft.Extensions.Options;


namespace ContactManagerApi.Data
{
    public class DbContext : IDbContext
    {
        public LiteDatabase Database { get;  }

        public DbContext(IOptions<DbOptions> options)
        {
            Database = new LiteDatabase(options.Value.DatabaseLocation);
        }
    }
}

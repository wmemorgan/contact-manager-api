/// <summary>
/// This interface connects the app to the database
/// </summary>

using LiteDB;

namespace ContactManagerApi.Data
{
    public interface IDbContext
    {
        LiteDatabase Database { get; }
    }
}

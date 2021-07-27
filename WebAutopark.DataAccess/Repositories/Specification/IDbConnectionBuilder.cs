using System.Data.Common;

namespace WebAutopark.DataAccess.Repositories.Specification
{
    public interface IDbConnectionBuilder
    {
        DbConnection GetConnection();
    }
}

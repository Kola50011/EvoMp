using System.Data.Entity;

namespace EvoMp.Core.Core.Server
{
    public class QueryLogDbConfiguration : DbConfiguration
    {
        public QueryLogDbConfiguration()
        {
            SetDatabaseLogFormatter(
                (context, writeAction) => new QueryLogFormatter(context, writeAction));
        }
    }
}

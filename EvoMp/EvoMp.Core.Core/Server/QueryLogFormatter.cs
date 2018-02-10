using System;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Infrastructure.Interception;
using System.Threading.Tasks;
using EvoMp.Core.ConsoleHandler.Server;

namespace EvoMp.Core.Core.Server
{
    public class QueryLogFormatter : DatabaseLogFormatter
    {
        public QueryLogFormatter(DbContext context, Action<string> writeAction)
            : base(context, writeAction)
        {
        }

        public override void LogCommand<TResult>(
            DbCommand command, DbCommandInterceptionContext<TResult> interceptionContext)
        {
            // Write logging async
            ConsoleOutput.WriteLine(ConsoleType.Sql, $"{Context.GetType().Name}:");
            ConsoleOutput.PrintLine("=", "", ConsoleType.Sql);
            ConsoleOutput.WriteLine(ConsoleType.Sql, $"~#a39b00~{command.CommandText}");
            ConsoleOutput.WriteLine(ConsoleType.Sql, $"~#a39b00~{command.Parameters}");
        }
    }
}

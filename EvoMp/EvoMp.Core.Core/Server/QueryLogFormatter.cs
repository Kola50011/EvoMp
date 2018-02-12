using System;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Infrastructure.Interception;
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
            ConsoleOutput.WriteLine(ConsoleType.Sql, $"{Context.GetType().Name}:");
            ConsoleOutput.PrintLine("=", "", ConsoleType.Sql);
            ConsoleOutput.WriteLine(ConsoleType.Sql, $"{command.CommandText}");
            string parameterString = "";
            for (int i = 0; i < command.Parameters.Count; i++)
                parameterString +=
                    $"~c~{command.Parameters[i].DbType}\t\t~#a3a075~{command.Parameters[i].ParameterName} ~c~->~#a3a075~ {command.Parameters[i].Value}\n";

            ConsoleOutput.WriteLine(ConsoleType.Sql, $"~#a3a075~{parameterString}");
        }

        public override void LogResult<TResult>(DbCommand command,
            DbCommandInterceptionContext<TResult> interceptionContext)
        {
            if (interceptionContext.Exception == null)
                return;

            // Exception
            ConsoleOutput.PrintLine("=", "", ConsoleType.Warn);
            ConsoleOutput.WriteLine(ConsoleType.Sql, $"{Context.GetType().Name}:");
            ConsoleOutput.WriteLine(ConsoleType.Sql, $"{interceptionContext.Exception}");
            ConsoleOutput.PrintLine("=", "", ConsoleType.Warn);
        }
    }
}

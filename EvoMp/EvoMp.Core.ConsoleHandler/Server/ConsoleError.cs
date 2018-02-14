using System.Threading;
using System.Windows.Forms;

namespace EvoMp.Core.ConsoleHandler.Server
{
    public static class ConsoleError
    {
        /// <summary>
        ///     Prepares the ConsoleError.
        ///     Mostly setup fetch other console inputs.
        /// </summary>
        internal static void PrepareConsoleError()
        {
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException, true);
            Application.ThreadException += ApplicationOnThreadException;
        }

        private static void ApplicationOnThreadException(object sender,
            ThreadExceptionEventArgs threadExceptionEventArgs)
        {
            ConsoleOutput.WriteLine(ConsoleType.Fatal, threadExceptionEventArgs.Exception.ToString());
            ConsoleUtils.SafeSystemConsoleUse(() => throw threadExceptionEventArgs.Exception);
        }
    }
}

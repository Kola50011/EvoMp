using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using EvoMp.Core.ColorHandler;
using GrandTheftMultiplayer.Server.Util;

namespace EvoMp.Core.ConsoleHandler
{
    public static class ConsoleError
    {
        /// <summary>
        /// Prepares the ConsoleError.
        /// Mostly setup fetch other console inputs. 
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
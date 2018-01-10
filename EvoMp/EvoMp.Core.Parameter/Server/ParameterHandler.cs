using System;
using System.Collections.Generic;
using EvoMp.Core.ConsoleHandler.Server;

namespace EvoMp.Core.Parameter.Server
{
	/// <summary>
	///     Handler for startup parameter managment
	/// </summary>
	public class ParameterHandler
	{
		private const string leftArgsColor = "~#90A4AE~";
		private const string rightArgsColor = "~#ECEFF1~";
		private static Dictionary<string, string> _commandLineArgs = new Dictionary<string, string>();
		private static Dictionary<string, string> _defaults = new Dictionary<string, string>();

		/// <summary>
		///     Reads all command line args
		/// </summary>
		public static void LoadParams()
		{
			_commandLineArgs = new Dictionary<string, string>();
			_defaults = new Dictionary<string, string>();

			string[] args = Environment.GetCommandLineArgs();
			try
			{
				for (int i = 1; i < args.Length; i += 2)
					_commandLineArgs[args[i].Replace("-", "").ToLower()] = args[i + 1];
			}
			catch (Exception e)
			{
				ConsoleOutput.WriteLine(ConsoleType.Error, $"Error in Command Line arguments! Len: {args.Length}" +
				                                           $" Current args are: {string.Join(" ", args)}");
			}
		}

		/// <summary>
		///     Sets the default value for a parameter
		/// </summary>
		/// <param name="key"></param>
		/// <param name="value"></param>
		public static void SetDefault(string key, string value)
		{
			_defaults[key.ToLower()] = value;
			if (GetValue(key) == null)
				_commandLineArgs[key.ToLower()] = value;
		}

		/// <summary>
		///     Returns true if the key has the default value
		/// </summary>
		/// <param name="key"></param>
		/// <returns>True, if default; False, if not default</returns>
		public static bool IsDefault(string key)
		{
			if (_defaults[key.ToLower()] == _commandLineArgs[key.ToLower()])
				return true;
			return false;
		}

		public static string GetValue(string key)
		{
			string res;
			if (_commandLineArgs.TryGetValue(key.ToLower(), out res))
				return res;
			return null;
		}

		public static void PrintArgs()
		{
			// Small centered line with headline & developer
			ConsoleOutput.WriteCentredText(ConsoleType.Note,
				"".PadRight(55, '-') + "\n" +
				"Startup Parameters\n" +
				"".PadRight(55, '-'));

			string text = "";
			foreach (string key in _commandLineArgs.Keys)
				text +=
					$"{leftArgsColor}{key}{string.Empty.PadRight(5)}{rightArgsColor}{$"{GetValue(key)}".PadLeft(40)}\n";
			ConsoleOutput.WriteCentredText(ConsoleType.Info, text);
		}
	}
}

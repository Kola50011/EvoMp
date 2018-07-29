using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace EvoMp.Core.ConsoleHandler.Server
{
    internal class ConsoleInput
    {
        public delegate void ConsoleKeyPress(ConsoleKeyInfo moduleInstance);

        public delegate void ConsoleString(string consoleString, CancelEventArgs cancelEventArgs);

        public delegate void InputValueChange(string consoleInput);

        internal static string CurrentConsoleInput = "... Blocked on startup ...";

        private static readonly List<string> InputHistory = new List<string>();

        private static int _historyIndex = -1;
        private static int _cursorPos;
        internal static bool CursorInsertMode = true;
        private static readonly int OriginalCursorSize = Console.CursorSize;

        public static event ConsoleKeyPress OnConsoleKeyPress;
        public static event ConsoleString OnConsoleString;
        public static event InputValueChange OnInputValueChange;

        /// <summary>
        ///     Prepares the console input routine.
        ///     Fetching Console.KeyAvailable,
        ///     writing events, etc..
        /// </summary>
        public static void PrepareConsoleInput()
        {
            CurrentConsoleInput = "";
            Console.CursorVisible = true;
            
            // Watch console inputs
            new Task(ConsoleKeyInputWatcher).Start();

            // Bind console input events
            OnConsoleKeyPress += WriteConsoleKeyPress;
            OnInputValueChange += WriteHistoryChange;
        }

        /// <summary>
        ///     Watcher for the console input keys.
        ///     Parsing and writing events
        /// </summary>
        private static void ConsoleKeyInputWatcher()
        {
            while (true)
            {
                Thread.Sleep(50);

                if (!Console.KeyAvailable)
                    continue;

                ConsoleKeyInfo key = Console.ReadKey(true);
                switch (key.Key)
                {
                    case ConsoleKey.Insert:
                        {
                            CursorInsertMode = !CursorInsertMode;
                            Console.CursorSize = CursorInsertMode ? OriginalCursorSize : 100;
                            break;
                        }
                    case ConsoleKey.Enter:
                        {
                            string newConsoleInput = CurrentConsoleInput;
                            CurrentConsoleInput = string.Empty;

                            // Remove current temp
                            if (_historyIndex != -1)
                                InputHistory.Remove(InputHistory.Last());
                            _historyIndex = -1;
                            _cursorPos = 0;

                            // Save in settings
                            if (!string.IsNullOrWhiteSpace(newConsoleInput))
                            {
                                InputHistory.Remove(newConsoleInput);
                                InputHistory.Add(newConsoleInput);
                            }

                            TriggerConsoleString(newConsoleInput);
                            break;
                        }
                    case ConsoleKey.Backspace:
                        {
                            if (CurrentConsoleInput.Length <= 0)
                            {
                                _cursorPos = 0;
                                break;
                            }

                            _cursorPos--;
                            CurrentConsoleInput = CurrentConsoleInput.Remove(_cursorPos, 1);

                            if (_historyIndex != -1)
                                InputHistory.Remove(InputHistory.Last());

                            _historyIndex = -1;
                            break;
                        }
                    case ConsoleKey.Delete:
                        {
                            if (_cursorPos == CurrentConsoleInput.Length)
                                break;

                            CurrentConsoleInput = CurrentConsoleInput.Remove(_cursorPos, 1);

                            if (_historyIndex != -1)
                                InputHistory.Remove(InputHistory.Last());

                            _historyIndex = -1;
                            break;
                        }
                    case ConsoleKey.UpArrow:
                        {
                            if (!InputHistory.Any() || _historyIndex == 0)
                                break;

                            if (_historyIndex == -1)
                            {
                                InputHistory.Add(CurrentConsoleInput);
                                _historyIndex = InputHistory.Count - 1;
                                _historyIndex--;
                            }
                            else
                            {
                                _historyIndex--;
                            }

                            TriggerInputValueChange(InputHistory[_historyIndex]);
                            break;
                        }
                    case ConsoleKey.DownArrow:
                        {
                            if (!InputHistory.Any())
                                break;

                            if (InputHistory.Count - 1 > _historyIndex)
                                _historyIndex++;

                            TriggerInputValueChange(InputHistory[_historyIndex]);
                            break;
                        }
                    case ConsoleKey.RightArrow:
                        {
                            if (_cursorPos == CurrentConsoleInput.Length)
                                break;

                            _cursorPos++;
                            break;
                        }
                    case ConsoleKey.LeftArrow:
                        {
                            if (_cursorPos == 0)
                                break;

                            _cursorPos--;
                            break;
                        }
                    case ConsoleKey.End:
                        {
                            _cursorPos = CurrentConsoleInput.Length;
                            break;
                        }
                    case ConsoleKey.Home:
                        {
                            _cursorPos = 0;
                            break;
                        }
                    default:
                        {
                            if (char.IsControl(key.KeyChar))
                                break;

                            if (_historyIndex != -1)
                                InputHistory.Remove(InputHistory.Last());

                            _historyIndex = -1;

                            // Cursor at end, append
                            if (_cursorPos == CurrentConsoleInput.Length)
                                CurrentConsoleInput += key.KeyChar;
                            else // Insert new char
                                CurrentConsoleInput = CurrentConsoleInput
                                    .Remove(_cursorPos, CursorInsertMode ? 0 : 1)
                                    .Insert(_cursorPos, key.KeyChar.ToString());

                            _cursorPos++;

                            break;
                        }
                }

                TriggerConsoleKeyPress(key);
            }
        }

        /// <summary>
        ///     Triggerd if a history console input entry is selected.
        ///     Rewrites the console input field
        /// </summary>
        /// <param name="consoleInput">The new console input string</param>
        internal static void WriteHistoryChange(string consoleInput)
        {
            ConsoleUtils.SafeSystemConsoleUse(() =>
            {
                string cleanUpStr = string.Empty.PadRight(Console.BufferWidth - ConsoleUtils.InputCursorLeftStart);
                Console.CursorLeft = ConsoleUtils.InputCursorLeftStart;
                Console.Write(cleanUpStr);
                Console.CursorLeft = ConsoleUtils.InputCursorLeftStart;
                Console.Write(consoleInput);
            });
        }

        /// <summary>
        ///     Writes the console key press live to console window.
        /// </summary>
        /// <param name="consoleKeyInfo">Pressed informations</param>
        internal static void WriteConsoleKeyPress(ConsoleKeyInfo consoleKeyInfo)
        {
            if (consoleKeyInfo.Key == ConsoleKey.Enter)
                return;

            ConsoleUtils.SafeSystemConsoleUse(() =>
            {
                switch (consoleKeyInfo.Key)
                {
                    case ConsoleKey.Backspace:
                        if (Console.CursorLeft > 0)
                            Console.CursorLeft--;
                        Console.Write(" ");
                        break;
                    case ConsoleKey.Delete:
                        Console.Write(" ");
                        if (Console.CursorLeft > 0)
                            Console.CursorLeft--;
                        break;
                    default:
                        if (char.IsControl(consoleKeyInfo.KeyChar))
                            break;

                        Console.Write(consoleKeyInfo.KeyChar);
                        if (CursorInsertMode)
                            Console.Write(CurrentConsoleInput.Substring(_cursorPos));
                        break;
                }

                // Set correct console cursor position
                Console.CursorLeft = ConsoleUtils.InputCursorLeftStart + _cursorPos;
            });
        }

        private static void TriggerConsoleKeyPress(ConsoleKeyInfo moduleInstance)
        {
            OnConsoleKeyPress?.Invoke(moduleInstance);
        }

        private static void TriggerConsoleString(string consoleString)
        {
            OnConsoleString?.Invoke(consoleString, new CancelEventArgs());
        }

        private static void TriggerInputValueChange(string newValue)
        {
            CurrentConsoleInput = newValue;
            _cursorPos = newValue.Length;
            OnInputValueChange?.Invoke(newValue);
        }
    }
}

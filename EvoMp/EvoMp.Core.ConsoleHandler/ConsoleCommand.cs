using System;
using System.Reflection;

namespace EvoMp.Core.ConsoleHandler
{
    [AttributeUsage(AttributeTargets.Method)]
    public class ConsoleCommand : Attribute
    {
        public ConsoleCommand(string command, string[] commandAliases = null, string description = null)
        {
            Command = command;
            Description = description ?? "...";
            CommandAliases = commandAliases ?? new string[] { };
        }

        public string Command { get; set; }
        public string Description { get; }

        public string[] CommandAliases { get; set; }

        public MethodInfo MethodInfo { get; set; }

        public object ClassInstance { get; set; }

        public string FullName()
        {
            return $"{MethodInfo.DeclaringType?.FullName}.{MethodInfo.Name}";
        }
    }
}
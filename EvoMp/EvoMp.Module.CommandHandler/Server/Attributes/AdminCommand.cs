using System;
using System.Reflection;

namespace EvoMp.Module.CommandHandler.Server.Attributes
{
    [AttributeUsage(AttributeTargets.Method)]
    public class AdminCommand : Attribute, ICommand
    {
        public AdminCommand(string command, string[] commandAliases = null,
            PlayerOnlyState playerOnlyState = PlayerOnlyState.Any)
        {
            Command = command;
            PlayerOnlyState = playerOnlyState;           
            CommandAliases = commandAliases ?? new string[] { };
        }

        public string Command { get; set; }

        public string[] CommandAliases { get; set; }

        public PlayerOnlyState PlayerOnlyState { get; }

        public MethodInfo MethodInfo { get; set; }

        public object ClassInstance { get; set; }

        public string FullName()
        {
            return $"{MethodInfo.DeclaringType?.FullName}.{MethodInfo.Name}";
        }
    }
}

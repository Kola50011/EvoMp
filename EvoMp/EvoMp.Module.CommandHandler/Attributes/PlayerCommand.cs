using System;
using System.Reflection;

namespace EvoMp.Module.CommandHandler.Attributes
{
    [AttributeUsage(AttributeTargets.Method)]
    public class PlayerCommand : Attribute, ICommand
    {
        public string Command { get; set; }

        public string[] CommandAliases { get; set; }

        public PlayerOnlyState PlayerOnlyState { get; }

        public MethodInfo MethodInfo { get; set; }

        public object ClassInstance { get; set; }

        public string FullName()
        {
            return $"{Command} (~c~{MethodInfo.DeclaringType?.FullName}~;~)";
        }
        public int TestMinHealth { get; }

        public PlayerCommand(string command, string[] commandAliases = null,
            PlayerOnlyState playerOnlyState = PlayerOnlyState.Any, int testMinHealth = 0)
        {
            Command = command;
            PlayerOnlyState = playerOnlyState;
            TestMinHealth = testMinHealth;
            CommandAliases = commandAliases ?? new string[] { };
        }
    }
}

using System;
using System.Reflection;

namespace EvoMp.Module.CommandHandler.Attributes
{
    [AttributeUsage(AttributeTargets.Method)]
    public class PlayerCommand : Attribute, ICommand
    {
        public string Command { get; }
        public string[] CommandAliases { get; }

        public PlayerOnlyState PlayerOnlyState { get; }
        public MethodInfo MethodInfo { get; set; }

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

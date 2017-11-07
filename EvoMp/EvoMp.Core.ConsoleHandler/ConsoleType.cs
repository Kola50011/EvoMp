namespace EvoMp.Core.ConsoleHandler
{
    public enum ConsoleType
    {
        [ConsoleTypeProperties("~w~")] Core,
        [ConsoleTypeProperties("~g~")] Info,
        [ConsoleTypeProperties("~o~~bw~")] Warn,
        [ConsoleTypeProperties("~r~~bw~")] Error,
        [ConsoleTypeProperties("~r~~_~")] Fatal,
        [ConsoleTypeProperties("~c~")] Note,
        [ConsoleTypeProperties("~b~")] Debug,
        [ConsoleTypeProperties("~y~~bw~")] Database,
        [ConsoleTypeProperties("~c~", "", "----")] Line
    }
}
namespace EvoMp.Core.Core
{
    public interface IModule
    {
        string ModuleName { get; }
        string ModuleDesc { get; }
        string ModuleAuth { get; }
    }
}
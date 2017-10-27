using System.Collections.Generic;
using EvoMp.Core.Core;
using EvoMp.Core.ModuleProperties;
using GrandTheftMultiplayer.Server.Constant;

namespace EvoMp.Module.Logger
{
    [ModuleProperties("shared", "Koka, Lukas, DevGrab", "Wrapper for outputting stuff to different locations ex. Console, Discord, File")]
    public interface ILogger
    {
        Dictionary<string, Color[]> SyntaxMap { get; set; }

        void AddSyntax(string syntaxname, string foreGround, string backGround);
        void AddSyntax(string syntaxname, Color foreGround, Color backGround);
        void RemoveSyntax(string syntaxname);

        void Write(string message, LogCase logCase = LogCase.Info);
        int GetBiggestSyntax();
        void AddTransport(string message);
    }
}
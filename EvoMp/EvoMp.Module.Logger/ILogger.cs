using System.Collections.Generic;
using EvoMp.Core.Core;
using GrandTheftMultiplayer.Server.Constant;

namespace EvoMp.Module.Logger
{
    public interface ILogger : IModule
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
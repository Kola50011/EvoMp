using System;
using System.Runtime.InteropServices;
using EvoMp.Core.Module.Server;
using EvoMp.Module.ClientHandler.Server.Entity;
using GrandTheftMultiplayer.Server.Elements;

namespace EvoMp.Module.ClientHandler.Server
{
    [ModuleProperties("shared", "Koka, Lukas", "Everything that has to do with a user")]
    public interface IClientHandler
    {
        bool SpawnExtendetClient(ExtendetClient extendetClient);
        bool Restrict([Optional] Client client, [Optional] ExtendetClient extendetClient);
        bool UnRestrict([Optional] Client client, [Optional] ExtendetClient extendetClient);
    }
}

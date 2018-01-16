using System;
using System.Runtime.InteropServices;
using EvoMp.Core.Module.Server;
using EvoMp.Module.UserHandler.Server.Entity;
using GrandTheftMultiplayer.Server.Elements;

namespace EvoMp.Module.UserHandler.Server
{
    [ModuleProperties("shared", "Koka, Lukas", "Everything that has to do with a user")]
    public interface IClientHandler
    {
        ExtendetClient GetExtendetClient(Func<ClientDto, bool> predicate);
        bool SpawnExtendetClient(ExtendetClient extendetClient);
        bool Restrict([Optional] Client client, [Optional] ExtendetClient extendetClient);
        bool UnRestrict([Optional] Client client, [Optional] ExtendetClient extendetClient);
    }
}

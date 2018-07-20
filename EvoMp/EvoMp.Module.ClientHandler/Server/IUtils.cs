using GrandTheftMultiplayer.Server.Constant;
using System.Collections.Generic;

namespace EvoMp.Module.ClientHandler.Server
{
    public interface IUtils
    {
        /// <summary>
        /// Returns list of ped hashes that comply search attributes
        /// </summary>
        /// <param name="searchName"></param>
        /// <returns>List<PedHash></PedHash></returns>
        List<PedHash> GetPedHashesByName(string searchName);
    }
}

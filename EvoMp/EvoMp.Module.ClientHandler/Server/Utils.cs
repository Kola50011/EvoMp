using System;
using System.Collections.Generic;
using System.Linq;
using GrandTheftMultiplayer.Server.Constant;

namespace EvoMp.Module.ClientHandler.Server
{
    public class Utils : IUtils
    {
        /// <inheritdoc />
        public List<PedHash> GetPedHashesByName(string searchName)
        {
            // include animal pedhashes also
            searchName = searchName.ToLower();
            return Enum.GetValues(typeof(PedHash)).Cast<PedHash>().AsParallel()
                .Where(pH => searchName == $"{pH}".ToLower()
                || $"{pH}".ToLower().StartsWith(searchName)
                || $"{pH}".ToLower().Contains(searchName))
                .Distinct()
                .ToList();    
        }
    }
}

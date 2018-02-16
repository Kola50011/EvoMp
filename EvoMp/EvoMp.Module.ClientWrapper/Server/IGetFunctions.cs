using System.Threading.Tasks;
using GrandTheftMultiplayer.Server.Elements;
using GrandTheftMultiplayer.Shared.Math;

namespace EvoMp.Module.ClientWrapper.Server
{
    public interface IGetFunctions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="position"></param>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        /// <returns></returns>
        Task<string> GetStreetName(Client sender, Vector3 position);
    }
}

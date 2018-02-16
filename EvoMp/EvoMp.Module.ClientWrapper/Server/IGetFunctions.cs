using System.Threading.Tasks;
using GrandTheftMultiplayer.Server.Elements;
using GrandTheftMultiplayer.Shared.Math;

namespace EvoMp.Module.ClientWrapper.Server
{
    public interface IGetFunctions
    {
        Task<string> GetStreetName(Client sender, Vector3 position);
    }
}

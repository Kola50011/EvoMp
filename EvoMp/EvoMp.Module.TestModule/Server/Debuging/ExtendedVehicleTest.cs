using EvoMp.Module.CommandHandler.Server;
using EvoMp.Module.CommandHandler.Server.Attributes;
using EvoMp.Module.MessageHandler.Server;
using EvoMp.Module.VehicleHandler.Server;
using GrandTheftMultiplayer.Server.Elements;

namespace EvoMp.Module.TestModule.Server.Debuging
{
    public class ExtendedVehicleTest
    {
        private readonly IMessageHandler _messageHandler;
        private readonly IVehicleHandler _vehicleHandler;

        public ExtendedVehicleTest(IVehicleHandler vehicleHandler, IMessageHandler messageHandler)
        {
            _vehicleHandler = vehicleHandler;
            _messageHandler = messageHandler;
        }

        [PlayerCommand("/dbvUFull", playerOnlyState: PlayerOnlyState.OnlyInVehicle)]
        public void UpdateVehicleFull(Client sender)
        {
            ExtendedVehicle extendedVehicle = _vehicleHandler.CreateExtendedVehicle(sender.vehicle);
            extendedVehicle.FullUpdate();
            extendedVehicle.Save();
        }


        [PlayerCommand("/dbvDestroy", playerOnlyState: PlayerOnlyState.OnlyInVehicle)]
        public void DestroyVehicle(Client sender)
        {
            ExtendedVehicle extendedVehicle = _vehicleHandler.CreateExtendedVehicle(sender.vehicle);
            extendedVehicle.Destroy(true);
        }

        [PlayerCommand("/dbvspawn")]
        public void SpawnVehicle(Client sender, int vehicleId)
        {
            ExtendedVehicle extendedVehicle = _vehicleHandler.CreateExtendedVehicle(vehicleId);
            extendedVehicle.Create();
        }
    }
}

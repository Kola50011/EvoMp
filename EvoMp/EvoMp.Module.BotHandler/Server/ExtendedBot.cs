using System;
using EvoMp.Module.BotHandler.Server.Entity;
using GrandTheftMultiplayer.Server.API;
using GrandTheftMultiplayer.Server.Elements;

namespace EvoMp.Module.BotHandler.Server
{
    public class ExtendedBot
    {
        private const string EntityDataStringRecording = "BotHandler.Recording";
        private readonly Client owner;
        public bool IsRecording;
        public BotDto Properties;

        public ExtendedBot(Client sender)
        {
            owner = sender;
            //IsRecording = API.shared.hasEntityData(sender, EntityDataStringRecording) &&
            //              (bool)API.shared.getEntityData(sender, EntityDataStringRecording);
        }


        public void StartRecording()
        {
            // Is already recording
            if (!IsRecording)
                throw new Exception();

            IsRecording = true;
            API.shared.setEntityData(owner, EntityDataStringRecording, IsRecording);
        }

        public void StopRecording()
        {
            API.shared.setEntityData(owner, EntityDataStringRecording, false);
        }
    }
}

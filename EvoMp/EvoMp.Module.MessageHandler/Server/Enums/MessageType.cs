using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EvoMp.Module.MessageHandler.Server.Attributes;

namespace EvoMp.Module.MessageHandler.Server.Enums
{
    public enum MessageType
    {
        [MessageType("", "")] None,
        [MessageType("~g~", "Info")] Info,
        [MessageType("~o~", "Warn")] Warn,
        [MessageType("~r~~h~", "Error")] Error,
        [MessageType("~b~~h~", "Debug")] Debug,
        [MessageType("~b~", "Help")] Help,
        [MessageType("~c~", "Note")] Note,
    }
}

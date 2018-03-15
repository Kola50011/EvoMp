using GrandTheftMultiplayer.Server.Managers;
using GrandTheftMultiplayer.Shared;

namespace EvoMp.Module.ColShapeHandler.Server
{
    /// <summary>
    ///     Wrapper for GT-MP OnEntityEnterColShape, OnEntityExitColShape
    /// </summary>
    public class ColShapeEvent
    {
        /// <inheritdoc />
        public delegate void Callback(ColShape shape, NetHandle entity);

        /// <summary>
        ///     Gets called when the event is triggered
        /// </summary>
        public Callback Cab;

        /// <inheritdoc />
        public ColShapeEvent(Callback cab)
        {
            Cab = cab;
        }
    }
}

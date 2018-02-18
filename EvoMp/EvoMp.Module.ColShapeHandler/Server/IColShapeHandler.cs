using EvoMp.Core.Module.Server;
using GrandTheftMultiplayer.Server.Managers;
using GrandTheftMultiplayer.Shared;
using GrandTheftMultiplayer.Shared.Math;

namespace EvoMp.Module.ColShapeHandler.Server
{
    /// <summary>
    ///     Interface representing the ColShapeHandler
    /// </summary>
    [ModuleProperties("shared", "Koka", "Wrapper for GT-MP ColShapes")]
    public interface IColShapeHandler
    {
        /// <summary>
        /// </summary>
        /// <param name="name">Unique name of the ColShape</param>
        void RemoveColShape(string name);

        #region CreateShapes

        /// <summary>
        ///     Creates a 2D collision shape which checks whether an entity is inside of a rectangular area, where height does not
        ///     count.
        ///     https://wiki.gt-mp.net/index.php?title=Create2DColShape
        /// </summary>
        /// <param name="name">Unique name of the ColShape for later identification</param>
        /// <param name="x">x positon in the world</param>
        /// <param name="y">y position in the world</param>
        /// <param name="width">Width in x direction</param>
        /// <param name="height">Height in y direction</param>
        void Create2DColShape(string name, float x, float y, float width, float height);

        /// <summary>
        ///     Creates a 3D collision shape which checks whether an entity is inside of a rectangular area. If you don't care
        ///     about the height, you can use create2DColShape instead.
        ///     https://wiki.gt-mp.net/index.php?title=Create3DColShape
        /// </summary>
        /// <param name="name">Unique name of the ColShape for later identification</param>
        /// <param name="start">Start position</param>
        /// <param name="end">End position</param>
        void Create3DColShape(string name, Vector3 start, Vector3 end);

        /// <summary>
        ///     Creates a spherical collision shape which checks whether an entity is inside of the spherical area.
        ///     https://wiki.gt-mp.net/index.php?title=CreateSphereColShape
        /// </summary>
        /// <param name="name">Unique name of the ColShape for later identification</param>
        /// <param name="position">Position in the world</param>
        /// <param name="range">Range from middle to border</param>
        void CreateSphereColShape(string name, Vector3 position, float range);

        /// <summary>
        ///     Creates a cylinder shaped colshape object.
        ///     https://wiki.gt-mp.net/index.php?title=CreateCylinderColShape
        /// </summary>
        /// <param name="name">Unique name of the ColShape for later identification</param>
        /// <param name="position">Position in the world</param>
        /// <param name="range">Range from middle to border</param>
        /// <param name="height">Height of the ColShape</param>
        void CreateCylinderColShape(string name, Vector3 position, float range, float height);

        #endregion

        #region SubUnSub

        /// <summary>
        ///     Subscribe to the onEntityEnterColShape event
        /// </summary>
        /// <param name="name">Unique name of the ColShape</param>
        /// <param name="colShapeEvent">Event which gets called later</param>
        void SubscribeToEntityEnterColShape(string name, ColShapeEvent colShapeEvent);

        /// <summary>
        ///     Subscribe to the onEntityExitColShape event
        /// </summary>
        /// <param name="name">Unique name of the ColShape</param>
        /// <param name="colShapeEvent">Event which gets called later</param>
        void SubscribeToEntityExitColShape(string name, ColShapeEvent colShapeEvent);

        /// <summary>
        ///     UnSubscribe from the onEntityEnterColShape event
        /// </summary>
        /// <param name="name">Unique name of the ColShape</param>
        /// <param name="colShapeEvent">Event which gets called later</param>
        void UnSubscribeFromEntityEnterColShape(string name, ColShapeEvent colShapeEvent);

        /// <summary>
        ///     UnSubscribe from the onEntityExitColShape event
        /// </summary>
        /// <param name="name">Unique name of the ColShape</param>
        /// <param name="colShapeEvent">Event which gets called later</param>
        void UnSubscribeFromEntityExitColShape(string name, ColShapeEvent colShapeEvent);

        #endregion
    }

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

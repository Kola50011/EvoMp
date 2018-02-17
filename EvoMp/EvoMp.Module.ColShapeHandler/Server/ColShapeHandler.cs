using System.Collections.Generic;
using System.Linq;
using EvoMp.Core.ConsoleHandler.Server;
using GrandTheftMultiplayer.Server.API;
using GrandTheftMultiplayer.Server.Managers;
using GrandTheftMultiplayer.Shared;
using GrandTheftMultiplayer.Shared.Math;

namespace EvoMp.Module.ColShapeHandler.Server
{
    /// <inheritdoc />
    public class ColShapeHandler : IColShapeHandler
    {
        private readonly API _api;

        //Events
        private readonly Dictionary<ColShape, string> _colShapeList = new Dictionary<ColShape, string>();

        private readonly Dictionary<string, List<ColShapeEvent>> _subscriberListEnter =
            new Dictionary<string, List<ColShapeEvent>>();

        private readonly Dictionary<string, List<ColShapeEvent>> _subscriberListExit =
            new Dictionary<string, List<ColShapeEvent>>();

        /// <inheritdoc />
        public ColShapeHandler(API api)
        {
            _api = api;
            _api.onEntityEnterColShape += InvokeEnterEvent;
            _api.onEntityExitColShape += InvokeExitEvent;
        }

        /// <inheritdoc />
        public void Create2DColShape(string name, float x, float y, float width, float height)
        {
            ConsoleOutput.WriteLine(ConsoleType.Info,
                $"Created 2DColShape ~#85a7dd~{name}~;~ at x: ~#85a7dd~{x}~;~, y: ~#85a7dd~{y}~;~ " +
                $"with width: ~#85a7dd~{width}~;~ and height: ~#85a7dd~{height}~;~");
            ColShape colShape = _api.create2DColShape(x, y, width, height);
            _colShapeList.Add(colShape, name);
        }

        /// <inheritdoc />
        public void Create3DColShape(string name, Vector3 start, Vector3 end)
        {
            ConsoleOutput.WriteLine(ConsoleType.Info, $"Created 3DColShape ~#85a7dd~{name}~;~ at start: " +
                                                      $"~#85a7dd~{start}~;~ end: ~#85a7dd~{end}~;~");
            ColShape colShape = _api.create3DColShape(start, end);
            _colShapeList.Add(colShape, name);
        }

        /// <inheritdoc />
        public void CreateSphereColShape(string name, Vector3 position, float range)
        {
            ConsoleOutput.WriteLine(ConsoleType.Info,
                $"Created SphereColShape ~#85a7dd~{name}~;~ at position: ~#85a7dd~{position}~;~ with range: ~#85a7dd~{range}~;~");
            ColShape colShape = _api.createSphereColShape(position, range);
            _colShapeList.Add(colShape, name);
        }

        /// <inheritdoc />
        public void CreateCylinderColShape(string name, Vector3 position, float range, float height)
        {
            ConsoleOutput.WriteLine(ConsoleType.Info,
                $"Created CylinderColShape ~#85a7dd~{name}~;~ at position: ~#85a7dd~{position}~;~ with range: ~#85a7dd~{range}~;~ and height: ~#85a7dd~{height}~;~");
            ColShape colShape = _api.createCylinderColShape(position, range, height);
            _colShapeList.Add(colShape, name);
        }

        /// <inheritdoc />
        public void SubscribeToEntityEnterColShape(string name, ColShapeEvent colShapeEvent)
        {
            ConsoleOutput.WriteLine(ConsoleType.Info,
                $"Subscribe to ColShapeEnter event ~#85a7dd~{name}~;~ in ~#85a7dd~" +
                (colShapeEvent.Cab.Method.DeclaringType != null
                    ? colShapeEvent.Cab.Method.DeclaringType.FullName
                    : "?." + colShapeEvent.Cab.Method.Name));

            if (_subscriberListEnter[name] == null)
            {
                List<ColShapeEvent> toInsert = new List<ColShapeEvent>();
                toInsert.Add(colShapeEvent);
                _subscriberListEnter[name] = toInsert;
            }
            else
            {
                _subscriberListEnter[name].Add(colShapeEvent);
            }
        }

        /// <inheritdoc />
        public void SubscribeToEntityExitColShape(string name, ColShapeEvent colShapeEvent)
        {
            ConsoleOutput.WriteLine(ConsoleType.Info,
                $"Subscribe to ColShapeExit event ~#85a7dd~{name}~;~ in ~#85a7dd~" +
                (colShapeEvent.Cab.Method.DeclaringType != null
                    ? colShapeEvent.Cab.Method.DeclaringType.FullName
                    : "?." + colShapeEvent.Cab.Method.Name));

            if (_subscriberListExit[name] == null)
            {
                List<ColShapeEvent> toInsert = new List<ColShapeEvent>();
                toInsert.Add(colShapeEvent);
                _subscriberListExit[name] = toInsert;
            }
            else
            {
                _subscriberListExit[name].Add(colShapeEvent);
            }
        }

        /// <inheritdoc />
        public void UnSubscribeFromEntityEnterColShape(string name, ColShapeEvent colShapeEvent)
        {
            ConsoleOutput.WriteLine(ConsoleType.Info,
                $"UnSubscribe from ColShapeEnter event ~#85a7dd~{name}~;~ in ~#85a7dd~" +
                (colShapeEvent.Cab.Method.DeclaringType != null
                    ? colShapeEvent.Cab.Method.DeclaringType.FullName
                    : "?." + colShapeEvent.Cab.Method.Name));

            if (_subscriberListEnter[name] != null)
                _subscriberListEnter[name].Remove(colShapeEvent);
        }

        /// <inheritdoc />
        public void UnSubscribeFromEntityExitColShape(string name, ColShapeEvent colShapeEvent)
        {
            ConsoleOutput.WriteLine(ConsoleType.Info,
                $"UnSubscribe from ColShapeExit event ~#85a7dd~{name}~;~ in ~#85a7dd~" +
                (colShapeEvent.Cab.Method.DeclaringType != null
                    ? colShapeEvent.Cab.Method.DeclaringType.FullName
                    : "?." + colShapeEvent.Cab.Method.Name));

            if (_subscriberListExit[name] != null)
                _subscriberListExit[name].Remove(colShapeEvent);
        }

        /// <inheritdoc />
        public void RemoveColShape(string name)
        {
            ConsoleOutput.WriteLine(ConsoleType.Info,
                $"Removed ColShape ~#85a7dd~{name}");

            _subscriberListEnter.Remove(name);
            _subscriberListExit.Remove(name);

            if (_colShapeList.ContainsValue(name))
            {
                ColShape toRemove = _colShapeList.First(x => x.Value == name).Key;
                _api.deleteColShape(toRemove);
                _colShapeList.Remove(toRemove);
            }
        }

        private void InvokeEnterEvent(ColShape shape, NetHandle entity)
        {
            string name = _colShapeList[shape];
            if (name == null)
                return;

            ConsoleOutput.WriteLine(ConsoleType.Event,
                $"Invoked ColShapeEnterEvent ~#85a7dd~{name}~;~ by ~#85a7dd~{entity}~;~");

            foreach (ColShapeEvent colShapeEvent in _subscriberListEnter[name])
                colShapeEvent.Cab.Invoke(shape, entity);
        }

        private void InvokeExitEvent(ColShape shape, NetHandle entity)
        {
            string name = _colShapeList[shape];
            if (name == null)
                return;

            ConsoleOutput.WriteLine(ConsoleType.Event,
                $"Invoked ColShapeExitEvent ~#85a7dd~{name}~;~ by ~#85a7dd~{entity}~;~");

            foreach (ColShapeEvent colShapeEvent in _subscriberListExit[name])
                colShapeEvent.Cab.Invoke(shape, entity);
        }
    }
}

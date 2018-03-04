using System;
using System.Runtime.Serialization;

namespace EvoMp.Module.VehicleHandler.Server.Exceptions
{
    /// <inheritdoc />
    /// <summary>
    ///     Handles exceptions for the ExtendedVehicle
    /// </summary>
    public class ExtendedVehicleException : Exception
    {
        /// <inheritdoc />
        /// <summary>
        ///     Creates new empty ExtendedVehicleException
        /// </summary>
        public ExtendedVehicleException()
        {
        }

        /// <inheritdoc />
        /// <summary>
        ///     Creates new message based ExtendedVehicleException.
        /// </summary>
        /// <param name="message">The exception message</param>
        public ExtendedVehicleException(string message) : base(message)
        {
        }

        /// <inheritdoc />
        /// <summary>
        ///     Creates new message based ExtendedVehicleException with an inner exception.
        /// </summary>
        /// <param name="message">The exception message</param>
        /// <param name="innerException">The inner exception</param>
        public ExtendedVehicleException(string message, Exception innerException) : base(message, innerException)
        {
        }

        /// <inheritdoc />
        /// <summary>
        ///     Creates new SerializationInfo based ExtendedVehicleException with an StreamingContext.
        /// </summary>
        /// <param name="info">SerializationInfo</param>
        /// <param name="context">StreamingContext</param>
        protected ExtendedVehicleException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}

using System;
using System.Runtime.Serialization;

namespace EvoMp.Module.VehicleHandler.Server.Exceptions
{
    /// <inheritdoc />
    /// <summary>
    ///     Handles exceptions for the VehicleHandler object
    /// </summary>
    public class VehicleHandlerException : Exception
    {
        /// <inheritdoc />
        /// <summary>
        ///     Creates new empty VehicleHandlerException
        /// </summary>
        public VehicleHandlerException()
        {
        }

        /// <inheritdoc />
        /// <summary>
        ///     Creates new message based VehicleHandlerException.
        /// </summary>
        /// <param name="message">The exception message</param>
        public VehicleHandlerException(string message) : base(message)
        {
        }

        /// <inheritdoc />
        /// <summary>
        ///     Creates new message based VehicleHandlerException with an inner exception.
        /// </summary>
        /// <param name="message">The exception message</param>
        /// <param name="innerException">The inner exception</param>
        public VehicleHandlerException(string message, Exception innerException) : base(message, innerException)
        {
        }

        /// <inheritdoc />
        /// <summary>
        ///     Creates new SerializationInfo based VehicleHandlerException with an StreamingContext.
        /// </summary>
        /// <param name="info">SerializationInfo</param>
        /// <param name="context">StreamingContext</param>
        protected VehicleHandlerException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}

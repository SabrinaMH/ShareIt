using System;
using System.Runtime.Serialization;

namespace ShareIt.UserCtx.Domain
{
    [Serializable]
    public class EmailAlreadyRegisteredException : Exception
    {
        /// <summary>
        /// Calls the default exception constructor.
        /// </summary>
        public EmailAlreadyRegisteredException()
        {
        }
        /// <summary>
        /// Calls the default exception constructor with a message parameter.
        /// </summary>
        /// <param name="message">The exception message.</param>
        public EmailAlreadyRegisteredException(string message) : base(message)
        {
        }
        /// <summary>
        /// Calls the default exception constructor with a message and innerException parameter.
        /// </summary>
        /// <param name="message">The exception message.</param>
        /// <param name="inner">The inner exception.</param>
        public EmailAlreadyRegisteredException(string message, Exception inner): base(message, inner)
        {
        }
        /// <summary>
        /// Calls the default exception constructor with a serialization info and streaming context parameter.
        /// </summary>
        /// <param name="info">The SerializationInfo that holds the serialized object data about the exception being thrown.</param>
        /// <param name="context">The StreamingContext that contains contextual information about the source or destination.</param>
        public EmailAlreadyRegisteredException(SerializationInfo info, StreamingContext context) : base( info, context )
        {
        }
    }
} 

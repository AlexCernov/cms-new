using System;
using System.Collections;
using System.Runtime.Serialization;

namespace CMS.Exceptions
{
        [Serializable]
        public class DatabaseException : Exception
        {
            public DatabaseException()
            {
            }

            public DatabaseException(string message) : base(message)
            {
            }

            public DatabaseException(string message, System.Exception innerException) : base(message, innerException)
            {
            }

            protected DatabaseException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

        }
}
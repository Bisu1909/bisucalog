using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AQC
{
    public class InvalidUnitySetUpException : Exception
    {
        public InvalidUnitySetUpException()
        {
        }

        public InvalidUnitySetUpException(string message) : base(message)
        {
        }

        public InvalidUnitySetUpException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidUnitySetUpException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}

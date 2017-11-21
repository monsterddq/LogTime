using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace LogTime.CustomException
{
    public class LogTimeException : ApplicationException
    {
        public LogTimeException()
        {
        }

        public LogTimeException(string message) : base(message)
        {

        }

        public LogTimeException(string message, Exception innerException) : base(message, innerException)
        {

        }

        protected LogTimeException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}

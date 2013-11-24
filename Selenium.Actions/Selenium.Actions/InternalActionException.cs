using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Selenium.Actions
{
    public class InternalActionException : ApplicationException
    {
        #region Constructors

        public InternalActionException()
            : base() { }

        public InternalActionException(string message)
            : base(message) { }

        public InternalActionException(string format, params object[] args)
            : base(string.Format(format, args)) { }

        public InternalActionException(string message, Exception innerException)
            : base(message, innerException) { }

        public InternalActionException(string format, Exception innerException, params object[] args)
            : base(string.Format(format, args), innerException) { }

        protected InternalActionException(SerializationInfo info, StreamingContext context)
            : base(info, context) { }


        #endregion
    }
}

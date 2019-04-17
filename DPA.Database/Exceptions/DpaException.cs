using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace DPA.Database.Exceptions
{
    [Serializable]
    public class DpaException : Exception
    {
        public int StatusCode { get; }
        public string ExceptionMessage { get; set; }
        public Dictionary<string, string> Parameters { get; } = new Dictionary<string, string>();

        public DpaException(int statusCode, string message, Exception innerException = null) : base(message, innerException)
        {
            StatusCode = statusCode;
            ExceptionMessage = message;
        }
        protected DpaException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            StatusCode = info.GetInt32("StatusCode");
            //Parameters
        }

        [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
                throw new ArgumentNullException(nameof(info));
            info.AddValue("StatusCode", StatusCode);
            info.AddValue("Parameters", Parameters);
            base.GetObjectData(info, context);
        }
    }
}

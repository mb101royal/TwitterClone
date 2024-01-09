using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace TwitterClone.Business.Exceptions.Topic
{
    internal class TopicNotFoundException : Exception
    {
        public TopicNotFoundException()
        {
        }

        public TopicNotFoundException(string? message) : base(message)
        {
        }

        public TopicNotFoundException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected TopicNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}

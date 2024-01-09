using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using TwitterClone.Core.Entities.Common;

namespace TwitterClone.Business.Exceptions.Common
{
    public class NotFoundException<T> : Exception where T : BaseEntity
    {
        public NotFoundException() : base(typeof(T).Name + " not found")
        {
        }

        public NotFoundException(string? message) : base(message)
        {
        }

        public NotFoundException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected NotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace TwitterClone.Business.Exceptions.Role
{
    public class RoleCreationFailedException : Exception
    {
        public RoleCreationFailedException() : base("This role doesn't exist.")
        {
        }

        public RoleCreationFailedException(string? message) : base(message)
        {
        }

        public RoleCreationFailedException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected RoleCreationFailedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}

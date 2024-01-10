using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace TwitterClone.Business.Exceptions.Role
{
    internal class RoleAssigningFailedException : Exception
    {
        public RoleAssigningFailedException() : base("Role cannot be assigned.")
        {
        }

        public RoleAssigningFailedException(string? message) : base(message)
        {
        }

        public RoleAssigningFailedException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected RoleAssigningFailedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}

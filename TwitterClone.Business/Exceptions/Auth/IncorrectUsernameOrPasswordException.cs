using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace TwitterClone.Business.Exceptions.Auth
{
    internal class IncorrectUsernameOrPasswordException : Exception
    {
        public IncorrectUsernameOrPasswordException() : base("Username or password is incorrect.")
        {
        }

        public IncorrectUsernameOrPasswordException(string? message) : base(message)
        {
        }

        public IncorrectUsernameOrPasswordException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected IncorrectUsernameOrPasswordException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}

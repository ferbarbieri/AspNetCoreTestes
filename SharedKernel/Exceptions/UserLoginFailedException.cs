using System;
using System.Runtime.Serialization;

namespace Domain.SharedKernel.Exceptions
{
    [Serializable]
    public class UserLoginFailedException : MeritusException
    {
        public UserLoginFailedException() : base("Email ou senha inválidos")
        {
        }

        public UserLoginFailedException(string message) : base(message)
        {
        }

        public UserLoginFailedException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected UserLoginFailedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}

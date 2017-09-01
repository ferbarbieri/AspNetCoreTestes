using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Domain.SharedKernel.Exceptions
{
    public class NotFoundException : Exception
    {
        public int Id { get; private set; }

        public NotFoundException()
        {
        }

        public NotFoundException(int id)
        {
            Id = id;
        }

        public NotFoundException(string message, int id) : base(message)
        {
            Id = id;
        }
    }
}

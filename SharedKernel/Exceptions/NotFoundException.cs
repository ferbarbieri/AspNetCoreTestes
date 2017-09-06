using System;

namespace Domain.SharedKernel.Exceptions
{
    [Serializable]
    public class NotFoundException : MeritusException
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

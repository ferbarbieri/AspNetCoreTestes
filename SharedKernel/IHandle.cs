using System;
using System.Collections.Generic;
using System.Text;

namespace SharedKernel
{
    public interface IHandle<T> where T : IDomainEvent
    {
        void Handle(T args);
    }
}

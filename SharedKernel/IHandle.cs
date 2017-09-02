using System;
using System.Collections.Generic;
using System.Text;

namespace SharedKernel
{
    public interface IHandle<in T> where T : IDomainEvent
    {
        void Handle(T args);
    }
}

using DependencyResolver;
using SimpleInjector;
using System;
using System.Collections.Generic;

namespace SharedKernel
{
    public static class DomainEvents
    {
        [ThreadStatic]
        private static List<Delegate> actions;

        static DomainEvents()
        {
            Container = ContainerFactory.Container;
        }

        public static Container Container { get; set; }
        public static void Register<T>(Action<T> callback) where T : IDomainEvent
        {
            if (actions == null)
            {
                actions = new List<Delegate>();
            }
            actions.Add(callback);
        }

        public static void ClearCallbacks()
        {
            actions = null;
        }

        public static void Raise<T>(T args) where T : IDomainEvent
        {
            try
            {
                foreach (var handler in Container.GetAllInstances<IHandle<T>>())
                {
                    handler.Handle(args);
                }
            }
            catch (Exception ex)
            {
                Logger.Trace("Erro ao lançar evento:" + ex.Message);
            }

            if (actions != null)
            {
                foreach (var action in actions)
                {
                    if (action is Action<T>)
                    {
                        ((Action<T>)action)(args);
                    }
                }
            }
        }
    }
}

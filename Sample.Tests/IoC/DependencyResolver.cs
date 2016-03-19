using Castle.Windsor;
using System;

namespace Sample.IoC
{
    public class DependencyResolver:IDisposable
    {
        private static IWindsorContainer _container;

        //Initialize the container
        public static void Initialize()
        {
            _container = new WindsorContainer();
            _container.Register(new ComponentRegistration());
        }

        //Resolve types
        public static T For<T>()
        {
            return _container.Resolve<T>();
        }

        public void Dispose()
        {
            _container = null;
        }
    }
}
using Castle.MicroKernel;
using Castle.MicroKernel.Registration;
using Sample.Core;
using Sample.Instance;
namespace Sample.IoC
{
    public class ComponentRegistration : IRegistration
    {
        public void Register(IKernelInternal kernel)
        {
            kernel.Register(
                 Component.For<ISmartCoffeeCup>().ImplementedBy<CoffeeCup>().LifestyleTransient(),
                 Component.For<ICoffeeVendingMachine>().ImplementedBy<CoffeeVendingMachine>().LifestyleSingleton());
        }
    }
}

using Sample.Core;
using Sample.IoC;
using System.Drawing;
using Xunit;

namespace Sample.Tests
{
    public class InstanceTests
    {
        public InstanceTests()
        {
            //Initialize the dependency resolver
            DependencyResolver.Initialize();
        }

        [Fact]
        public void When_First_Machine_Is_On_Second_Is_On()
        {
            var firstMachine = DependencyResolver.For<ICoffeeVendingMachine>();
            firstMachine.SwitchOn();
            var secondMachine = DependencyResolver.For<ICoffeeVendingMachine>();
            Assert.Equal(firstMachine.IsOn(), secondMachine.IsOn());            
        }

        [Fact]
        public void Stock_Matches_On_Both_Machine_After_Serving_Coffee()
        {
            var firstMachine = DependencyResolver.For<ICoffeeVendingMachine>();
            firstMachine.AddStock(new Stock() { Coffee = 100, Cream = 100, Sugar = 100 });
            firstMachine.SwitchOn();
            var cup = new CoffeeCup(Color.Violet);
            firstMachine.ServeCoffee(CoffeeType.Cappuccino, cup);
            var firstmachineStock = firstMachine.CheckStock();
            var secondMachine = DependencyResolver.For<ICoffeeVendingMachine>();
            var secondMachineStock = secondMachine.CheckStock();
            Assert.Equal(firstmachineStock.Cream, secondMachineStock.Cream);
        }
       
    }
}

using Sample.IoC;
using Sample.Core;
using System;
using Sample.Instance;
using Sample.Singleton;
using System.Drawing;

namespace Sample.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //Singleton Test

            var cup = new CoffeeCup(Color.White);
            var singletonMachine= Sample.Singleton.CoffeeVendingMachine.Instance;
            singletonMachine.AddStock(new Stock() { Coffee = 200, Cream = 200, Sugar = 200 });
            singletonMachine.SwitchOn();
            singletonMachine.CheckStock();
            singletonMachine.ServeCoffee(CoffeeType.Cappuccino, cup);
            singletonMachine.ServeCoffee(CoffeeType.Espresso, cup);
            singletonMachine.CheckStock();

            Console.ReadLine();
        }
    }
}

using System;
using Sample.Core;
namespace Sample.Instance
{
    public class CoffeeVendingMachine : CoffeeVendingMachineBase, ICoffeeVendingMachine
    {
        public CoffeeVendingMachine()
        {
            _rawMaterialStock = new Stock { Coffee = 0, Cream = 0, Sugar = 0 };
        }

        protected override bool IsOnInternal()
        {
            return _isSwitchedOn;
        }

        protected override void SwitchOnInternal()
        {
            if (_isSwitchedOn)
            {
                Console.WriteLine("Coffee machine is already on");
                return;
            }
            _isSwitchedOn = true;
        }

        protected override void SwitchOffInternal()
        {
            if (!_isSwitchedOn)
            {
                Console.WriteLine("Coffee machine is already off");
                return;
            }
            _isSwitchedOn = false;
        }

        protected override Stock CheckStockInternal()
        {
            if (!_isSwitchedOn)
            {
                Console.WriteLine("Coffee machine is off");
                return null;
            }
            return _rawMaterialStock;
        }

        protected override void AddStockInternal(Stock stock)
        {
            if (_isSwitchedOn)
            {
                Console.WriteLine("Coffee machine is on. Please switch off before feeding the machine.");
                return;
            }
            _rawMaterialStock.Sugar += stock.Sugar;
            _rawMaterialStock.Cream += stock.Cream;
            _rawMaterialStock.Coffee += stock.Coffee;
        }

        protected override void ServeCoffeeInternal(CoffeeType type, ISmartCoffeeCup cup)
        {
            if (!_isSwitchedOn)
            {
                Console.WriteLine("Coffee machine is off.");
                return;
            }
            _orderNumber += 1;
            var coffee = PrepareCoffee(type);
            if (!cup.IsClean) cup.Clean();
            if (coffee != null) cup.Fill(coffee);
            Console.WriteLine(string.Format("Order Number:{0}", _orderNumber));
            Console.WriteLine(string.Format("Successfully filled coffee in {0} cup", cup.Color.Name));
            Console.WriteLine("---------------------------------");
        }
    }
}

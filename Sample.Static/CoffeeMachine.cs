using Sample.Core;
using System;
using System.Drawing;
namespace Sample.Static
{
    public static class CoffeeMachine 
    {
        #region properties
        public static Stock RawMaterialStock
        {
            get
            {
                return _rawMaterial;
            }
        }

        #endregion

        #region private fields
        private static Stock _rawMaterial { get; set; }
        private static bool _isOn { get; set; }
        private static int _orderNumber { get; set; }
        #endregion

        public static void ServeCoffee(CoffeeType type, ISmartCoffeeCup cup)
        {
            if (!_isOn)
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

        public static ICoffee PrepareCoffee(CoffeeType type)
        {
            var coffee = new Coffee() { Type = type };

            switch (type)
            {
                case CoffeeType.Cappuccino:
                    if (_rawMaterial.Coffee < 10 || _rawMaterial.Cream < 10 || _rawMaterial.Sugar < 10)
                    {
                        Console.WriteLine("No enough stock");
                        return null;
                    }
                    _rawMaterial.Sugar -= 10;
                    _rawMaterial.Cream -= 10;
                    _rawMaterial.Coffee -= 10;

                    break;
                case CoffeeType.Espresso:
                    if (_rawMaterial.Coffee < 20 || _rawMaterial.Cream < 20 || _rawMaterial.Sugar < 20)
                    {
                        Console.WriteLine("No enough stock");
                        return null;
                    }
                    _rawMaterial.Sugar -= 20;
                    _rawMaterial.Cream -= 20;
                    _rawMaterial.Coffee -= 20;

                    break;
            }

            return coffee;
        }

        public static void CheckStock()
        {
            if (!_isOn)
            {
                Console.WriteLine("Coffee machine is off");
                return;
            }

            Console.WriteLine(String.Format("Sugar Quantity:{0}", _rawMaterial.Sugar));
            Console.WriteLine(String.Format("Coffee Quantity:{0}", _rawMaterial.Coffee));
            Console.WriteLine(String.Format("Cream Quantity:{0}", _rawMaterial.Cream));
        }

        public static void AddStock(Stock stock)
        {
            if (_isOn)
            {
                Console.WriteLine("Coffee machine is on. Please switch off before feeding the machine.");
                return;
            }
            _rawMaterial.Sugar += stock.Sugar;
            _rawMaterial.Cream += stock.Cream;
            _rawMaterial.Coffee += stock.Coffee;
        }

        public static void SwitchOn()
        {
            if (_isOn)
            {
                Console.WriteLine("Coffee machine is already on");
                return;
            }
            _isOn = true;
        }

        public static void SwitchOff()
        {
            if (_isOn)
            {
                Console.WriteLine("Coffee machine is already off");
                return;
            }
            _isOn = false;
        }

    }
}

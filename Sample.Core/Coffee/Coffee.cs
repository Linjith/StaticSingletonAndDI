using System;

namespace Sample.Core
{
    public class Coffee : ICoffee
    {

        public CoffeeType Type
        {
            get
            {
                return _coffeeType;
            }
            set
            {
                _coffeeType = value;
            }
        }

        private CoffeeType _coffeeType { get; set; }
    }
}

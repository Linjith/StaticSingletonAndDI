using System;
using System.Drawing;

namespace Sample.Core
{
    public sealed class CoffeeCup : ISmartCoffeeCup
    {
        private bool _empty { get; set; }
        private bool _clean { get; set; }
        private Color _color { get; set; }

        public CoffeeCup(Color color)
        {
            _color = color;
            _empty = true;
        }

        public Color Color
        {
            get
            {
                return _color;
            }
        }

        public bool IsClean
        {
            get
            {
                return _clean;
            }
          
        }

        public bool IsEmpty
        {
            get
            {
                return _empty;
            }           
        }

        public void Clean()
        {
            if (_clean)
            {
                Console.WriteLine("Cup is already clean");
                return;
            }
            if (!_empty)
            {
                _empty = true;
                Console.WriteLine("Cup has been emptied");
            }
            Console.WriteLine("Cup has been cleaned");
            _clean = true;
        }

        public void Empty()
        {
            if (_empty)
            {
                Console.WriteLine("Cup is already empty");
                return;
            }
            Console.WriteLine("Cup has been emptied");
            _empty = true;
        }

        public void Fill(ICoffee coffee)
        {
            _empty = false;
            _clean = false;
        }
    }
}

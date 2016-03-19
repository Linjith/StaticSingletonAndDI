using System;

namespace Sample.Core
{
    public abstract class CoffeeVendingMachineBase : ICoffeeVendingMachine
    {
        #region fields

        protected Stock _rawMaterialStock;
        protected bool _isSwitchedOn;
        protected int _orderNumber { get; set; }

        #endregion

        #region abstract method signatures

        protected abstract bool IsOnInternal();
        protected abstract void SwitchOnInternal();
        protected abstract void SwitchOffInternal();
        protected abstract Stock CheckStockInternal();
        protected abstract void AddStockInternal(Stock stock);
        protected abstract void ServeCoffeeInternal(CoffeeType type, ISmartCoffeeCup cup);

        #endregion

        public CoffeeVendingMachineBase()
        {
            _rawMaterialStock = new Stock { Coffee = 0, Cream = 0, Sugar = 0 };
        }

        #region public methods

        public void AddStock(Stock stock)
        {
            try
            {
               AddStockInternal(stock);
               Audit("Successfully added stock");
            }
            catch (Exception ex)
            {
                Audit("Error while adding stock");
                throw;
            }
        }

        public Stock CheckStock()
        {
            try
            {
                var stock = CheckStockInternal();
                if(stock!=null)
                {
                    Audit(string.Format("Current Stock:: Sugar:{0}, Coffee{1}, Cream{2}", stock.Sugar, stock.Coffee, stock.Cream));
                }
                return stock;
            }
            catch(Exception ex)
            {
                Audit("Error while checking stock");
                throw;
            }
            
        }

        protected virtual ICoffee PrepareCoffee(CoffeeType type)
        {
            var coffee = new Coffee() { Type = type };

            switch(type)
            {
                case CoffeeType.Cappuccino:
                    if(_rawMaterialStock.Coffee<10|| _rawMaterialStock.Cream<10|| _rawMaterialStock.Sugar<10)
                    {
                        Console.WriteLine("No enough stock");
                        return null;
                    }
                    _rawMaterialStock.Sugar -= 10;
                    _rawMaterialStock.Cream -= 10;
                    _rawMaterialStock.Coffee -= 10;

                    break;
                case CoffeeType.Espresso:
                    if (_rawMaterialStock.Coffee < 20 || _rawMaterialStock.Cream < 20 || _rawMaterialStock.Sugar < 20)
                    {
                        Console.WriteLine("No enough stock");
                        return null;
                    }
                    _rawMaterialStock.Sugar -= 20;
                    _rawMaterialStock.Cream -= 20;
                    _rawMaterialStock.Coffee -= 20;

                    break;
            }

            return coffee;
        }

        public virtual void ServeCoffee(CoffeeType type, ISmartCoffeeCup cup)
        {
            try
            {
                ServeCoffeeInternal(type, cup);
            }
            catch (Exception ex)
            {
                Audit("Ërror while serving coffee");
                throw;
            }
        }

        public bool IsOn()
        {
            try
            {
                return IsOnInternal();
            }
            catch (Exception ex)
            {
                Audit("failed to verify state");
                throw;
            }
        }

        public void SwitchOff()
        {
            try
            {
                SwitchOffInternal();
            }
            catch (Exception ex)
            {
                Audit("failed to switch off");
                throw;
            }
           
        }

        public void SwitchOn()
        {
            try
            {
                SwitchOnInternal();
            }
            catch (Exception ex)
            {
                Audit("Failed to switch on!");
                throw;
            }
        }

        #endregion

        #region private methods

        private void Audit(string message)
        {
            Console.WriteLine(message);
        }
        
        #endregion
    }
}

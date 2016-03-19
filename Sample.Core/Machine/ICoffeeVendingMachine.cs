namespace Sample.Core
{
    public interface ICoffeeVendingMachine
    {
        bool IsOn();

        void SwitchOn();
        void SwitchOff();
        
        Stock CheckStock();
        void AddStock(Stock stock);

        void ServeCoffee(CoffeeType type, ISmartCoffeeCup cup);                
    }
}

using System.Drawing;
namespace Sample.Core
{
    public interface ISmartCoffeeCup
    {
        Color Color { get; }
        bool IsEmpty { get; }
        bool IsClean { get; }
        void Clean();
        void Empty();
        void Fill(ICoffee coffee);
    }
}

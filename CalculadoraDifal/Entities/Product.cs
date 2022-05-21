using CalculadoraDifal.Entities.Enums;

namespace CalculadoraDifal.Entities
{
    class Product
    {
        public double ProductValue { get; set; }
        public double InternalRate { get; set; }
        public Origin Origin { get; set; }

        public Product()
        {
        }

        public Product(double productValue, double internalRate, Origin origin)
        {
            ProductValue = productValue;
            InternalRate = internalRate;
            Origin = origin;
        }
    }
}

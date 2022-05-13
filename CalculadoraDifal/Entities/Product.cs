using CalculadoraDifal.Entities.Enums;

namespace CalculadoraDifal.Entities
{
    class Product
    {
        public double ProductValue { get; set; }
        public int InternalRate { get; set; } // Alíquota Interna Produto
        public Origin Origin { get; set; }

        public Product()
        {
        }

        public Product(double productValue, int internalRate, Origin origin)
        {
            ProductValue = productValue;
            InternalRate = internalRate / 100;
            Origin = origin;
        }
    }
}

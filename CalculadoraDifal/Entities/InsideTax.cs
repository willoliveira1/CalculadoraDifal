namespace CalculadoraDifal.Entities
{
    internal class InsideTax : InitialParams
    {
        public double Icms { get; set; }

        public InsideTax()
        {
        }
         
        public InsideTax(Product product, Contributor contributor) : base(product, contributor)
        {
            Product = product;
            Contributor = contributor;
            Icms = IcmsTax();
        }

        public double ProductIcms()
        {
            return Product.ProductValue * Icms;
        }

        public double CalculationBasis()
        {
            return (Product.ProductValue - ProductIcms()) / (1 - Product.InternalRate);
        }

        public double Difal()
        {
            return CalculationBasis() - Product.ProductValue;
        }

        public double TotalValue()
        {
            return Product.ProductValue + Difal();
        }

        public override string ToString()
        {
            return $"ICMS do Produto: R$ {ProductIcms().ToString("F2")}\n" +
                   $"Base de Cálculo: R$ {CalculationBasis().ToString("F2")}\n" +
                   $"Difal: R$ {Difal().ToString("F2")}\n" +
                   $"Valor Total: R$ {TotalValue().ToString("F2")}";
        }
    }
}

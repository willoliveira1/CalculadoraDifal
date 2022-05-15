namespace CalculadoraDifal.Entities
{
    internal class InsideTax : InitialParams
    {
        public double IcmsTax { get; set; }
        public Product Product { get; set; }
        public Contributor Contributor { get; set; }

        public InsideTax()
        {
        }
         
        public InsideTax(Product product, Contributor contributor) : base(product, contributor)
        {
            Product = product;
            Contributor = contributor;
            IcmsTax = IcmsTax();
        }

        public double ProductIcms()
        {
            return Product.ProductValue * IcmsTax;
        }

        public double CalculationBasis()
        {
            return (Product.ProductValue - ProductIcms()) / (1 - Product.InternalRate);
        }
        /*public double ProductIcms()
        {
            return Product.ProductValue * (IcmsTax / 100);
        }

        public double CalculationBasis()
        {
            return (Product.ProductValue - ProductIcms()) / (1 - (Product.InternalRate / 100));
        }*/

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

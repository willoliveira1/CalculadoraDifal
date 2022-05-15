namespace CalculadoraDifal.Entities
{
    internal class NonContributorTax : InitialParams
    {
        public double IcmsTax { get; set; }
        public Product Product { get; set; }
        public Contributor Contributor { get; set; }

        public NonContributorTax()
        {
        }

        public NonContributorTax(Product product, Contributor contributor) : base(product, contributor)
        {
            Product = product;
            Contributor = contributor;
            IcmsTax = IcmsTax();
        }

        public double DifalRate()
        {
            return Product.InternalRate - IcmsTax;
        }

        public double Difal()
        {
            return Product.ProductValue * DifalRate();
        }

        public double TotalValue()
        {
            return Product.ProductValue;
        }

        public override string ToString()
        {
            return $"Difal: R$ {Difal().ToString("F2")}\n" +
                   $"Valor Total: R$ {TotalValue().ToString("F2")}";
        }
    }
}

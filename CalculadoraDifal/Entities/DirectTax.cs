namespace CalculadoraDifal.Entities
{
    internal class DirectTax : InitialParams
    {
        double difal, totalValue, calculationBasis, productIcms;

        public double IcmsTax { get; set; }
        public Product Product { get; set; }
        public Contributor Contributor { get; set; }

        public DirectTax()
        {
        }

        public DirectTax(Product product, Contributor contributor) : base(product, contributor)
        {
            Product = product;
            Contributor = contributor;
            IcmsTax = IcmsTax();
        }

        public void Calculate()
        {
            productIcms = Product.ProductValue * IcmsTax;
            calculationBasis = (Product.ProductValue - productIcms) / (1 - Product.InternalRate);
            difal = calculationBasis - Product.ProductValue;
            totalValue = Product.ProductValue + difal;
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
            return Product.ProductValue + Difal();
        }
    }
}

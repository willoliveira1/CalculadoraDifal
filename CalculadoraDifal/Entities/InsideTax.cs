namespace CalculadoraDifal.Entities
{
    internal class InsideTax : InitialParams
    {
        double difal, totalValue, calculationBasis, productIcms;

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

        public void Calculate() 
        {
            productIcms = Product.ProductValue * IcmsTax;
            calculationBasis = (Product.ProductValue - productIcms) / (1 - Product.InternalRate);
            difal = calculationBasis - Product.ProductValue;
            totalValue = Product.ProductValue + difal;
        }

        public double ProductIcms()
        {
            return Product.ProductValue * IcmsTax;
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
    }
}

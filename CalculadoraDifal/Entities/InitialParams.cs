namespace CalculadoraDifal.Entities
{
    class InitialParams
    {
        string[] insideTax = { "AL", "BA", "GO", "MG", "PA", "PR", "PE", "RS", "RO", "SC", "SE", "TO" }; // Imposto Por Dentro
        string[] directTax = { "AC", "AP", "AM", "CE", "DF", "ES", "MA", "MT", "MS", "PB", "PI", "RJ", "RN", "RR" }; //Imposto Direto
        string[] twelvePercent = { "MG", "PR", "RJ", "RS", "SC" };
        string[] sevenPercent = { "AC", "AP", "AM", "CE", "DF", "ES", "MA", "MT", "MS", "PB", "PI", "RN", "RR" +
                                  "AL", "BA", "GO", "PA", "PE", "RO", "SE", "TO" };

        public Product Product { get; set; }
        public string State { get; set; }
        public int Tax { get; }

        public InitialParams()
        {
        }

        public InitialParams(Product product, string state)
        {
            Product = product;
            State = state;
        }

        public double insideCalc(double productValue, )

    }
}

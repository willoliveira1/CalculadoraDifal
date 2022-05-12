using System.Collections.Generic;

namespace CalculadoraDifal.Entities
{
    class InitialParams
    {
        public List<string> Tw1 = new List<string>();
        public List<string> Tw2 = new List<string>();
        string[] insideTax = { "AL", "BA", "GO", "MG", "PA", "PR", "PE", "RS", "RO", "SC", "SE", "TO" }; // Imposto Por Dentro
        string[] directTax = { "AC", "AP", "AM", "CE", "DF", "ES", "MA", "MT", "MS", "PB", "PI", "RJ", "RN", "RR" }; //Imposto Direto
        string twelvePercent = "MG PR RJ RS SC";
        string sevenPercent = "AC AP AM CE DF ES MA MT MS PB PI RN RR AL BA GO PA PE RO SE TO";

        public Product Product { get; set; }
        public string State { get; set; }

        public InitialParams()
        {
        }

        public InitialParams(Product product, string state)
        {
            Product = product;
            State = state;
        }
            
        private int IcmsTax(string state)
        {
            Tw1.AddRange(twelvePercent.Split(" "));
            Tw2.AddRange(sevenPercent.Split(" "));

            if (Tw1.Contains(state))
            {
                return 12;
            }
            else if (Tw2.Contains(state))
            {
                return 7;
            }
            return 0;
        }
    }
}


using System.Collections.Generic;

namespace CalculadoraDifal.Entities
{
    class InitialParams
    {
        public List<string> twelvePercentList, sevenPercenteList = new List<string>();
        public List<string> insideTax, directTax = new List<string>();

        string twelvePercentStates = "MG PR RJ RS SC";
        string sevenPercentStates = "AC AP AM CE DF ES MA MT MS PB PI RN RR AL BA GO PA PE RO SE TO";
        string insideTaxStates = "AL BA GO MG PA PR PE RS RO SC SE TO";     // Difal Por Dentro
        string directTaxStates = "AC AP AM CE DF ES MA MT MS PB PI RJ RN RR";   // Difal Direto

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
            twelvePercentList.AddRange(twelvePercentStates.Split(" "));
            if (twelvePercentList.Contains(state))
            {
                return 12;
            }
            else
            {
                sevenPercenteList.AddRange(sevenPercentStates.Split(" "));
                if (sevenPercenteList.Contains(state))
                {
                    return 7;
                }
            }
            return 0;
        }
    }
}


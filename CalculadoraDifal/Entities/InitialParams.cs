using System;
using System.Collections.Generic;
using CalculadoraDifal.Entities.Enums;

namespace CalculadoraDifal.Entities
{
    class InitialParams
    {
        public List<string> twelvePercentList, sevenPercenteList = new List<string>();
        public List<string> directTaxStateList, insideTaxStateList = new List<string>();

        string twelvePercentStates = "MG PR RJ RS SC";
        string sevenPercentStates = "AC AP AM CE DF ES MA MT MS PB PI RN RR AL BA GO PA PE RO SE TO";
        string insideTaxStates = "AL BA GO MG PA PR PE RS RO SC SE TO";     // Difal Por Dentro
        string directTaxStates = "AC AP AM CE DF ES MA MT MS PB PI RJ RN RR";   // Difal Direto

        public Product Product { get; set; }
        public Contributor Contributor { get; set; }


        public InitialParams()
        {
        }

        public InitialParams(Product product, Contributor contributor)
        {
            Product = product;
            Contributor = contributor;
        }

        public double IcmsTax()
        {
            if (Product.Origin == Enum.Parse<Origin>("NonContributor"))
            {
                return 0.04;
            }
            twelvePercentList.AddRange(twelvePercentStates.Split(" "));
            if (twelvePercentList.Contains(Contributor.State))
            {
                return 0.12;
            }
            else
            {
                sevenPercenteList.AddRange(sevenPercentStates.Split(" "));
                if (sevenPercenteList.Contains(Contributor.State))
                {
                    return 0.07;
                }
            }
            return 0;
        }


        public void Calculate(string state, Product product)
        {
            insideTaxStateList.AddRange(insideTaxStates.Split(" "));
            if (insideTaxStateList.Contains(state))
            {
                int a = 1;
            }
            directTaxStateList.AddRange(directTaxStates.Split(" "));
            if (insideTaxStateList.Contains(state))
            {
                int b = 1;
            }
        }
    }
}

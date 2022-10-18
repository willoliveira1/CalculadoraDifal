using System;
using System.Collections.Generic;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using CalculadoraDifal.Entities;
using CalculadoraDifal.Entities.Enums;

namespace CalculadoraDifal
{
    public sealed partial class MainPage : Page
    {
        Product product = new Product();
        Contributor contributor = new Contributor();

        List<string> directTaxStateList = new List<string>();
        List<string> insideTaxStateList = new List<string>();

        string insideTaxStates = "AC AL BA GO MG PA PE PR RO RS SC SE TO";
        string directTaxStates = "AM AP CE DF ES MA MS MT PB PI RJ RN RR";


        public MainPage()
        {
            this.InitializeComponent();
        }

        private void TextBox_ProductValue(object sender, TextChangedEventArgs e)
        {
            
        }

        private void TextBox_InternalRate(object sender, TextChangedEventArgs e)
        {
        }

        private void RadioButton_ContributorType(object sender, RoutedEventArgs e)
        {
        }

        private void RadioButton_Origin(object sender, RoutedEventArgs e)
        {
        }

        private void SelectionChanged_State(object sender, SelectionChangedEventArgs e)
        {
        }

        private void Button_Click_Calculate(object sender, RoutedEventArgs e) 
        {
            insideTaxStateList.AddRange(insideTaxStates.Split(" "));
            directTaxStateList.AddRange(directTaxStates.Split(" "));

            product.ProductValue = double.Parse(valorDoProduto.Text);
            product.InternalRate = double.Parse(aliquotaInterna.Text) / 100;
            
            if ((bool)contrib.IsChecked)
            {
                contributor.ContributorType = Enum.Parse<ContributorType>((string)contrib.Name);
            }
            else
            {
                contributor.ContributorType = Enum.Parse<ContributorType>((string)nonContributor.Name);
            }
            
            if ((bool)National.IsChecked)
            {
                product.Origin = Enum.Parse<Origin>((string)National.Name);
            }
            else
            {
                product.Origin = Enum.Parse<Origin>((string)International.Name);
            }
            contributor.State = (String)estado.SelectionBoxItem;


            // Result
            if (contributor.ContributorType == Enum.Parse<ContributorType>("nonContributor"))
            {
                NonContributorTax nonContributorTax = new NonContributorTax(product, contributor);
                resultado.Text = nonContributorTax.ToString();
                Console.WriteLine();
            }
            else if (insideTaxStateList.Contains(contributor.State))
            {
                InsideTax insideTax = new InsideTax(product, contributor);
                resultado.Text = insideTax.ToString();
            }
            else
            {
                DirectTax directTax = new DirectTax(product, contributor);
                resultado.Text = directTax.ToString();
            }
        }

        private void Button_Click_Reset(object sender, RoutedEventArgs e)
        {
            resultado.Text = String.Empty;
        }

        private void TextChanged_Results(object sender, TextChangedEventArgs e)
        {
        }
    }
}

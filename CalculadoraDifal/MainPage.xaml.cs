using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using CalculadoraDifal.Entities;
using CalculadoraDifal.Entities.Enums;


// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace CalculadoraDifal
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        Product product = new Product();
        Contributor contributor = new Contributor();

        List<string> directTaxStateList = new List<string>();
        List<string> insideTaxStateList = new List<string>();

        string insideTaxStates = "AL BA GO MG PA PR PE RS RO SC SE TO";
        string directTaxStates = "AC AP AM CE DF ES MA MT MS PB PI RJ RN RR";
        

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
            product.InternalRate = int.Parse(aliquotaInterna.Text);
            
            if ((bool)situacaoFiscalRadio1.IsChecked)
            {
                contributor.ContributorType = Enum.Parse<ContributorType>((string)situacaoFiscalRadio1.Content);
            }
            else
            {
                contributor.ContributorType = Enum.Parse<ContributorType>((string)situacaoFiscalRadio2.Content);
            }
            
            if ((bool)origemRadio1.IsChecked)
            {
                product.Origin = Enum.Parse<Origin>((string)origemRadio1.Content);
            }
            else
            {
                product.Origin = Enum.Parse<Origin>((string)origemRadio2.Content);
            }
            contributor.State = (String)estado.SelectionBoxItem;


            // Result
            if (contributor.ContributorType == Enum.Parse<ContributorType>("NãoContribuinte"))
            {
                NonContributorTax nonContributorTax = new NonContributorTax(product, contributor);
                resultado.Text = nonContributorTax.ToString();
            }
            else if (insideTaxStateList.Contains(contributor.State))
            {
                InsideTax insideTax = new InsideTax(product, contributor);
                resultado.Text = insideTax.ToString();
            }
            else if (directTaxStateList.Contains(contributor.State))
            {
                DirectTax directTax = new DirectTax(product, contributor);
                resultado.Text = directTax.ToString();
            }
        }

        private void Button_Click_Reset(object sender, RoutedEventArgs e)
        {
        }

        private void TextChanged_Results(object sender, TextChangedEventArgs e)
        {
        }
    }
}

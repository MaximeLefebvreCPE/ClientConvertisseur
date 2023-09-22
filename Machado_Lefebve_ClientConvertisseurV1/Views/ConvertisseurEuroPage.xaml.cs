using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Machado_Lefebve_ClientConvertisseurV1.Models;
using Machado_Lefebve_ClientConvertisseurV1.Services;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Machado_Lefebve_ClientConvertisseurV1.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ConvertisseurEuroPage : Page
    {
        private WSService service;
        public ConvertisseurEuroPage()
        {
            service = new WSService("https://localhost:7168/api/");
            this.InitializeComponent();
            ActionGetDataAsync();
        }
        private async void ActionGetDataAsync()
        {
            var result = await service.GetDevisesAsync("Devises");
            if(result != null)
            {
                this.cbxDevise.DataContext = new List<Devise>(result);
            }
            else
            {
                Dialogue("API non disponible");
            }
        }
        private async void BtnConvertir_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(MontantAConvertir.Text, out double montant))
            {
                Devise selectedDevise = (Devise)cbxDevise.SelectedItem;
                if (selectedDevise != null)
                {
                    double montantConverti = montant * selectedDevise.Taux;
                    MontantConverti.Text = montantConverti.ToString();
                }
                else
                {
                    Dialogue("Veuillez indiquer une devise de conversion");
                }
            }
            else
            {
                Dialogue("Veuillez indiquer un montant valide");
            }
        }
        public async void Dialogue(string message)
        {
            ContentDialog error = new ContentDialog();
            error.Title = "Erreur";
            error.Content = message;
            error.CloseButtonText = "Ok";
            error.XamlRoot = this.Content.XamlRoot;
            await error.ShowAsync();
        }
    }
}

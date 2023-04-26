using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MongoDB.Bson;
using TP2_14E_A2022.Data.Entites;
using TP2_14E_A2022.Data.Gestions;
using TP2_14E_A2022.Data.GestionsBD;

namespace TP2_14E_A2022.Pages
{
    /// <summary>
    /// Logique d'interaction pour PageDetailsMembre.xaml
    /// </summary>
    public partial class PageDetailsMembre : Page
    {
        public Membre MembreSelectionne { get; set; }
        public string nomCompletGestionnaire;
        private GestionMembre gestionMembre;
        public PageDetailsMembre(ObjectId membre, string nomCompletGestionnaire, GestionMembre gestionMembre)
        {
            try
            {
                InitializeComponent();

                this.DataContext = this;
                this.nomCompletGestionnaire = nomCompletGestionnaire;
                this.gestionMembre = gestionMembre;
                MembreSelectionne = gestionMembre.GetMembreById(membre);
            
                AdresseMessageTxt.Text = gestionMembre.GetAdresseMessage(MembreSelectionne);
                CotisationMessageTxt.Text = gestionMembre.GetCotisationMessage(MembreSelectionne);
                LotMessageTxt.Text = gestionMembre.GetLotMessage(MembreSelectionne);
                UpdateFeeAmount(MembreSelectionne.EstPaye);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de la création de la page: " + ex.Message, "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            

        }

        private void Logo_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            PageMenu pageMenu = new PageMenu(nomCompletGestionnaire);
            this.NavigationService.Navigate(pageMenu);
        }
        
        private void EstPayeCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            UpdateFeeAmount(true);
        }

        public void UpdateFeeAmount(bool estPaye)
        {
            MembreSelectionne.EstPaye = estPaye;
            gestionMembre.UpdateMembreEstPaye(MembreSelectionne.Id, estPaye);

            if (MembreSelectionne.EstPaye)
            {
                MembreSelectionne.Cotisation = 0;
            }
            else
            {
                int feeAmount = gestionMembre.CalculateCotisation(MembreSelectionne.DateInscription);
                MembreSelectionne.Cotisation = feeAmount;
            }

            gestionMembre.UpdateMembreCotisation(MembreSelectionne.Id, MembreSelectionne.Cotisation);
            FeeAmountTextBlock.Text = $"Fees amount: {MembreSelectionne.Cotisation}$";
        }




        private void EstPayeCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            UpdateFeeAmount(false);        
        }
        
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            var pageLireOutils = new PageMenu(nomCompletGestionnaire);
            NavigationService.Navigate(pageLireOutils);
        }
        
        
    }
}

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
        public PageDetailsMembre(Membre membre, string nomCompletGestionnaire, GestionMembre gestionMembre)
        {
            InitializeComponent();
            MembreSelectionne = membre;
            this.DataContext = this;
            this.nomCompletGestionnaire = nomCompletGestionnaire;
            this.gestionMembre = gestionMembre;
            
            AdresseMessageTxt.Text = gestionMembre.GetAdresseMessage(MembreSelectionne);
            CotisationMessageTxt.Text = gestionMembre.GetCotisationMessage(MembreSelectionne);
            LotMessageTxt.Text = gestionMembre.GetLotMessage(MembreSelectionne);
            UpdateFeeAmount();

        }

        private void Logo_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            PageMenu pageMenu = new PageMenu(nomCompletGestionnaire);
            this.NavigationService.Navigate(pageMenu);
        }
        
        private void EstPayeCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            gestionMembre.UpdateMembreEstPaye(MembreSelectionne.Id, true);
            int feeAmount = gestionMembre.CalculateCotisation(MembreSelectionne.DateInscription);
            MembreSelectionne.Cotisation = feeAmount;

            if (MembreSelectionne.EstPaye)
            {
                gestionMembre.UpdateMembreCotisation(MembreSelectionne.Id, 0);
            }
            else
            {
                gestionMembre.UpdateMembreCotisation(MembreSelectionne.Id, MembreSelectionne.Cotisation);
            }

            FeeAmountTextBlock.Text = $"Fees: {feeAmount}$";
        }
        
        public void UpdateFeeAmount()
        {
            int feeAmount = gestionMembre.CalculateCotisation(MembreSelectionne.DateInscription);
            MembreSelectionne.Cotisation = feeAmount;
    
            // Update the estPaye status and cotisation amount in the database
            gestionMembre.UpdateMembreEstPaye(MembreSelectionne.Id, MembreSelectionne.EstPaye);
            new MembreDB().UpdateCotisation(MembreSelectionne.Id, MembreSelectionne.Cotisation);
    
            FeeAmountTextBlock.Text = $"Fees: {feeAmount}$";
        }

        private void EstPayeCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            gestionMembre.UpdateMembreEstPaye(MembreSelectionne.Id, false);
        }
        
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            var pageLireOutils = new PageMenu(nomCompletGestionnaire);
            NavigationService.Navigate(pageLireOutils);
        }
        
        
    }
}

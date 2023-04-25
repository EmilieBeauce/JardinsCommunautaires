using GalaSoft.MvvmLight.Command;
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
    /// Logique d'interaction pour PageMembre.xaml
    /// </summary>
    public partial class PageMembres: Page

    {
        public List<Membre> ListeDesMembres { get; set; }
        public string nomCompletGestionnaire;
        private GestionMembre gestionMembre;
        private MembreDB membreDB = new MembreDB();
        public ICommand DetailsMembre { get; private set; }
        public ICommand ModifierMembre { get; private set; }
        public ICommand SupprimerMembre { get; private set; }
        public PageMembres(string nomCompletGestionnaire, string message = null)
        {
            InitializeComponent();
            DetailsMembre = new RelayCommand<Membre>(AfficherDetailsMembre);
            ModifierMembre = new RelayCommand<Membre>(AfficherModifierMembre);
            SupprimerMembre = new RelayCommand<Membre>(SupprimerMembreListBox);
            gestionMembre = new GestionMembre(membreDB);
            
            this.nomCompletGestionnaire = nomCompletGestionnaire;
            
            nomCompletTextBlock.Text = nomCompletGestionnaire;
            
            if (!string.IsNullOrEmpty(message))
            {
                MessageValidation.Style = (Style)FindResource("SnackbarSuccessStyle");
                MessageValidation.MessageQueue.Enqueue(message);
            }
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            ListeDesMembres = membreDB.GetMembres();
            MembresListBox.ItemsSource = ListeDesMembres;
            this.DataContext = this;
            ShowWarningForUnpaidMembers();
        }
        private void Button_Ajouter_Membre_Click(object sender, RoutedEventArgs e)
        {
            PageAjouterMembre pageAjouterMembre = new PageAjouterMembre(nomCompletGestionnaire);
            this.NavigationService.Navigate(pageAjouterMembre);
        }
        private void BoutonDeconnexion_Click(object sender, RoutedEventArgs e)
        {
            PageConnexion pageConnexion = new PageConnexion();
            this.NavigationService.Navigate(pageConnexion);
        }
        public void AfficherDetailsMembre(Membre membre)
        {
            PageDetailsMembre pageDetailsMembre = new PageDetailsMembre(membre, nomCompletGestionnaire, gestionMembre);
            this.NavigationService.Navigate(pageDetailsMembre);
        }
        public void AfficherModifierMembre(Membre membre)
        {
            PageModifierMembre pageModifierMembre = new PageModifierMembre(membre, nomCompletGestionnaire, gestionMembre);
            this.NavigationService.Navigate(pageModifierMembre);
        }
        public void SupprimerMembreListBox(Membre membre)
        {
            if (membre != null)
            {
                if (membreDB.SupprimerMembre(membre.Id))
                {
                    MessageValidation.Style = (Style)FindResource("SnackbarSuccessStyle");
                    MessageValidation.MessageQueue.Enqueue($"Le membre {membre.Prenom} {membre.Nom} a été supprimé.");
                    ListeDesMembres.Remove(membre);
                    MembresListBox.ItemsSource = null;
                    MembresListBox.ItemsSource = ListeDesMembres;
                }
            }

        }
        private void Logo_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            PageMenu pageMenu = new PageMenu(nomCompletGestionnaire);
            this.NavigationService.Navigate(pageMenu);
        }
        
        private void ShowWarningForUnpaidMembers()
        {
            foreach (var membre in ListeDesMembres)
            {
                if (!membre.EstPaye)
                {
                    // Customize the warning message as needed
                    string warningMessage = $"Le membre {membre.Prenom} {membre.Nom} n'a pas encore payé.";
                    MessageValidation.MessageQueue.Enqueue(warningMessage);
                }
                
            }
        }
        
        
    }
}

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
    /// Logique d'interaction pour PageModifierMembre.xaml
    /// </summary>
    public partial class PageModifierMembre : Page
    {
        public Membre membre;
        private string nomCompletGestionnaire;
        private GestionMembre gestionMembre;
        public PageModifierMembre(Membre membre, string nomCompletGestionnaire, GestionMembre gestionMembre)
        {
            InitializeComponent();
            this.membre = membre;
            this.nomCompletGestionnaire = nomCompletGestionnaire;
            this.gestionMembre = gestionMembre;

            nomCompletTextBlock.Text = nomCompletGestionnaire;
            prenomTextBox.Text = membre.Prenom;
            nomTextBox.Text = membre.Nom;
        }
        private void Image_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            PageMenu pageMenu = new PageMenu(nomCompletGestionnaire);
            this.NavigationService.Navigate(pageMenu);
        }
        private void Button_Modifier_Membre_Click(object sender, RoutedEventArgs e)
        {
            string nouveauPrenom = prenomTextBox.Text;
            string nouveauNom = nomTextBox.Text;

            membre.Prenom = nouveauPrenom;
            membre.Nom = nouveauNom;

            bool modificationReussie = gestionMembre.membreDb.ModifierMembreDB(
                    membre.Id,
                    nouveauPrenom,
                    nouveauNom,
                    membre.IdAdresseCivique,
                    membre.IdLot
                );

            if (modificationReussie)
            {
                PageMembres pageMembres = new PageMembres(nomCompletGestionnaire, "Modification réussie");
                this.NavigationService.Navigate(pageMembres);
            }
            else
            {
                MessageValidation.Style = (Style)FindResource("SnackbarErrorStyle");
                MessageValidation.MessageQueue.Enqueue("Modification échouée");
            }
        }
        private void BoutonDeconnexion_Click(object sender, RoutedEventArgs e)
        {
            PageConnexion pageConnexion = new PageConnexion();
            this.NavigationService.Navigate(pageConnexion);
        }
    }
}

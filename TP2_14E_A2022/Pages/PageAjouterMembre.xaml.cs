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
    /// Logique d'interaction pour PageAjouterMembre.xaml
    /// </summary>
    public partial class PageAjouterMembre : Page
    {

        private MembreDB membreDB = new MembreDB();
        public string nomCompletGestionnaire;
        public PageAjouterMembre(string nomCompletGestionnaire)
        {
            InitializeComponent();
            membreDB = new MembreDB();

            this.nomCompletGestionnaire = nomCompletGestionnaire;

            nomCompletTextBlock.Text = nomCompletGestionnaire;
        }

        private void Button_Ajouter_Membre_Click(object sender, RoutedEventArgs e)
        {
            string nom = nomTextBox.Text;
            string prenom = prenomTextBox.Text;

            // Create an instance of GestionMembre
            MembreDB membreDB = new MembreDB();
            GestionMembre gestionMembre = new GestionMembre(membreDB);

            // Validation variables
            bool isValid = true;

            // Prenom validation
            if (!gestionMembre.PrenomEstValide(prenom))
            {
                prenomErrorTextBlock.Text = "Veuillez entrer le prénom.";
                isValid = false;
            }
            else
            {
                prenomErrorTextBlock.Text = string.Empty;
            }

            // Nom validation
            if (!gestionMembre.NomEstValide(nom))
            {
                nomErrorTextBlock.Text = "Veuillez entrer le nom.";
                isValid = false;
            }
            else
            {
                nomErrorTextBlock.Text = string.Empty;
            }

            if (isValid)
            {
                Membre nouveauMembre = new Membre { Prenom = prenom, Nom = nom };
                bool estCree = membreDB.AjouterMembre(nouveauMembre);

                if (estCree)
                {
                    PageMembres pageMembres = new PageMembres(nomCompletGestionnaire, "Ajout du nouveau membre réussie");
                    this.NavigationService.Navigate(pageMembres);
                }
                else
                {
                    MessageBox.Show("Erreur lors de l'ajout du compte", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void BoutonDeconnexion_Click(object sender, MouseButtonEventArgs e)
        {
            PageConnexion pageConnexion = new PageConnexion();
            this.NavigationService.Navigate(pageConnexion);
        }

        private void Button_Ajouter_Adresse_Click(object sender, object e)
        {

        }

        private void Image_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            PageMenu pageMenu = new PageMenu(nomCompletGestionnaire);
            this.NavigationService.Navigate(pageMenu);
        }
    }
}

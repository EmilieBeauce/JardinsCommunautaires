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
        private GestionMembre gestionMembre;
        public string nomCompletGestionnaire;
        public PageAjouterMembre(string nomCompletGestionnaire)
        {
            InitializeComponent();
            membreDB = new MembreDB();
            this.nomCompletGestionnaire = nomCompletGestionnaire;
        }

        private void Button_Ajouter_Membre_Click(object sender, object e)
        {
            string nom = nomTextBox.Text;
            string prenom = prenomTextBox.Text;
            bool payeCotisation = (bool)payerCotisationCheckBox.IsChecked;

            MembreDB membreDB = new MembreDB();
            bool estCree = membreDB.AjouterMembre(prenom, nom, null, null, null, payeCotisation);

            if (estCree)

            {
                MessageBox.Show("Compte créé avec succès.");
                PageMembre pageMembre = new PageMembre(nomCompletGestionnaire);
                this.NavigationService.Navigate(pageMembre);
            }
            else
            {
                MessageBox.Show("Erreur lors de la création du compte.");
            }
        }

        private void BoutonDeconnexion_Click(object sender, MouseButtonEventArgs e)
        {

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

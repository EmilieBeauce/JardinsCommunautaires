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
using TP2_14E_A2022.Data.GestionsBD;

namespace TP2_14E_A2022.Pages
{
    /// <summary>
    /// Logique d'interaction pour PageCreerCompte.xaml
    /// </summary>
    public partial class PageCreerCompte : Page
    {
        private PageConnexionBD pageConnexionBD = new PageConnexionBD();

        public PageCreerCompte()
        {
            InitializeComponent();
            pageConnexionBD = new PageConnexionBD();

        }

        private void BoutonCreerCompte_Click(object sender, RoutedEventArgs e)
        {
            string nom = nomTextBox.Text;
            string prenom = prenomTextBox.Text;
            string courriel = courrielTextBox.Text;
            string motDePasse = mdpPasswordBox.Password;
            string confirmationMotDePasse = confirmationPasswordBox.Password;

            if (motDePasse == confirmationMotDePasse)
            {
                PageConnexionBD pageConnexionBD = new PageConnexionBD();
                bool estCree = pageConnexionBD.LoginBD(prenom, nom, courriel, motDePasse);

                if (estCree)

                {
                    MessageBox.Show("Compte créé avec succès.");
                    PageConnexion pageConnexion = new PageConnexion();
                    this.NavigationService.Navigate(pageConnexion);
                }
                else
                {
                    MessageBox.Show("Erreur lors de la création du compte.");
                }
            }
            else
            {
                MessageBox.Show("Les mots de passe ne correspondent pas.");
            }
        }
    }
}

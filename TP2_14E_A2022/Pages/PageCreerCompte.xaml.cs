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


            bool nomEstValide = false;
            if (string.IsNullOrWhiteSpace(nom))
            {
                nomErreurTextBlock.Text = "Veuillez entrer votre nom.";
                nomEstValide = false;
            }
            else
            {
                nomEstValide = true;
            }

            bool prenomEstValide = false;
            if (string.IsNullOrWhiteSpace(prenom))
            {
                prenomErreurTextBlock.Text = "Veuillez entrer votre prénom.";
                prenomEstValide = false;
            }
            else
            {
                prenomEstValide = true;
            }

            bool courrielEstValide = false;
            if (string.IsNullOrWhiteSpace(courriel))
            {
                courrielErreurTextBlock.Text = "Veuillez entrer votre adresse courriel.";
                courrielEstValide = false;
            }
            else if (courriel.Contains("@") && courriel.Contains("."))
            {
                courrielEstValide = true;
            }
         
            else if (pageConnexionBD.ValiderSiCourrielExiste(courriel) == true)
            {
                courrielErreurTextBlock.Text = "Cette adresse courriel est déjà utilisée.";
                courrielEstValide = false;
            }
            else
            {
                courrielEstValide = false;
            }

            bool motDePasseEstValide = false;
            if (string.IsNullOrWhiteSpace(motDePasse))
            {
                mdpErreurTextBlock.Text = "Veuillez entrer votre mot de passe.";
                motDePasseEstValide = false;
            }
            else
            {
                motDePasseEstValide = true;
            }

            if (motDePasse == confirmationMotDePasse && nomEstValide && prenomEstValide && courrielEstValide)
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
                confirmationErreurTextBlock.Text = "Les deux mots de passe ne corresponde pas";
            }
        }
    }
}

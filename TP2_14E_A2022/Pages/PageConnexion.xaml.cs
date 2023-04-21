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
using static TP2_14E_A2022.Data.Gestions.GestionConnexion;


namespace TP2_14E_A2022.Pages
{
    /// <summary>
    /// Logique d'interaction pour PageConnexion.xaml
    /// </summary>
    public partial class PageConnexion
    {
        private readonly PageConnexionBD pageConnexionBD;
        public GestionConnexion gestionConnexion;
        public PageConnexion()
        {
            InitializeComponent();
            pageConnexionBD = new PageConnexionBD();
            gestionConnexion = new GestionConnexion(pageConnexionBD);

        }
        private void BoutonConnexion_Click(object sender, RoutedEventArgs e)
        {
            string courriel = courrielTextBox.Text;
            string motDePasse = mdpPasswordBox.Password;
            bool courrielEstValide = false;
            bool mdpEstValide = false;
            

            if (gestionConnexion.CourrielEstVIde(courriel))
            {
                courrielErreurTextBlock.Text = "Veuillez entrer votre adresse courriel.";
                courrielEstValide = false;
            }
            else if (gestionConnexion.CourrielExiste(courriel))
            {
                courrielErreurTextBlock.Text = "L'adresse courriel n'existe pas.";
                courrielEstValide = false;
            }
            else
            {
                courrielErreurTextBlock.Text = "";
                courrielEstValide = true;
            }

            if (gestionConnexion.MotDePasseEstVide(motDePasse))
            {
                mdpErreurTextBlock.Text = "Veuillez entrer votre mot de passe.";
                mdpEstValide = false;
            }
            else if (!gestionConnexion.ValiderSiDonneesConnexionConcordes(courriel, motDePasse) && courrielEstValide)
            {
                mdpErreurTextBlock.Text = "Le mot de passe est incorrect.";
                mdpEstValide = false;
            }
            else
            {
                mdpErreurTextBlock.Text = "";
                mdpEstValide = true;
            }
           

            if (mdpEstValide && courrielEstValide)
            {
                string nomCompletGestionnaire = pageConnexionBD.GetPrenomNomGestionnaire(courriel);
                PageMenu pageMenu = new PageMenu(nomCompletGestionnaire);
                this.NavigationService.Navigate(pageMenu);
            }


        }

        private void BoutonCreerCompte_Click(object sender, RoutedEventArgs e)
        {
            PageCreerCompte pageCreerCompte = new PageCreerCompte();
            this.NavigationService.Navigate(pageCreerCompte);
        }

        private void BoutonSinscrire_Click(object sender, RoutedEventArgs e)
        {
            PageCreerCompte pageCreerCompte = new PageCreerCompte();
            this.NavigationService.Navigate(pageCreerCompte);
        }


    }
}

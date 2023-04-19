﻿using System;
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
    /// Logique d'interaction pour PageConnexion.xaml
    /// </summary>
    public partial class PageConnexion
    {
        private readonly PageConnexionBD pageConnexionBD ;
        public PageConnexion()
        {
            InitializeComponent();
            pageConnexionBD = new PageConnexionBD();

        }
        private void BoutonConnexion_Click(object sender, RoutedEventArgs e)
        {
            string courriel = courrielTextBox.Text;
            string motDePasse = mdpPasswordBox.Password;
          

            bool estConnecte = pageConnexionBD.ValiderSiConnexionFonctionne(courriel, motDePasse);

            if (estConnecte)
            {
                string nomCompletGestionnaire = pageConnexionBD.GetPrenomNomGestionnaire(courriel);
                PageMenu pageMenu = new PageMenu(nomCompletGestionnaire);
                this.NavigationService.Navigate(pageMenu);
            }
            else
            {
                if (string.IsNullOrWhiteSpace(courriel))
                {
                    courrielErreurTextBlock.Text = "Veuillez entrer votre adresse courriel.";
                }
                else
                {
                    courrielErreurTextBlock.Text = "";
                }

                if (string.IsNullOrWhiteSpace(motDePasse))
                {
                    motDePasseErreurTextBlock.Text = "Veuillez entrer votre mot de passe.";
                }
                else
                {
                    motDePasseErreurTextBlock.Text = "";
                }
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

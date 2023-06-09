﻿using MaterialDesignThemes.Wpf;
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
    /// Logique d'interaction pour PageCreerCompte.xaml
    /// </summary>
    public partial class PageCreerCompte : Page
    {
        private PageConnexionBD pageConnexionBD = new PageConnexionBD();
        private GestionConnexion gestionConnexion;

        public PageCreerCompte()
        {
            InitializeComponent();
            pageConnexionBD = new PageConnexionBD();
        }
        private void BoutonCreerCompte_Click(object sender, RoutedEventArgs e)
        {
            gestionConnexion = new GestionConnexion(pageConnexionBD);
            string nom = nomTextBox.Text;
            string prenom = prenomTextBox.Text;
            string courriel = courrielTextBox.Text;
            string motDePasse = mdpPasswordBox.Password;
            string confirmationMotDePasse = confirmationPasswordBox.Password;
            bool prenomEstValide = false;
            bool nomEstValide = false;
            bool courrielEstValide = false;
            bool motDePasseEstValide = false;
            bool confirmationEstValide = false;

            if (!gestionConnexion.NomEstValide(nom))
            {
                nomErreurTextBlock.Text = "Veuillez entrer votre nom.";
                nomEstValide = false;
            }
            else
            {
                nomErreurTextBlock.Text = "";
                nomEstValide = true;
            }

            if (!gestionConnexion.PrenomEstValide(prenom))
            {
                prenomErreurTextBlock.Text = "Veuillez entrer votre prénom.";
                prenomEstValide = false;
            }
            else
            {
                prenomErreurTextBlock.Text = "";
                prenomEstValide = true;
            }

            if (gestionConnexion.CourrielEstVide(courriel))
            {
                courrielErreurTextBlock.Text = "Veuillez entrer votre adresse courriel.";
               courrielEstValide = false;
            }
            else if (!gestionConnexion.CourrielEstConforme(courriel))
            {
                courrielErreurTextBlock.Text = "Cette adresse courriel n'est pas conforme devrait avoir un '@' ou un '.'.";
                courrielEstValide = false;
            }
            else if (gestionConnexion.CourrielExiste(courriel))
            {
                courrielErreurTextBlock.Text = "Veuillez entrer un courriel qui n'est pas utilisé.";
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
                motDePasseEstValide = false;
            }
            else if (!gestionConnexion.MotDePasseEstConforme(motDePasse))
            {
                mdpErreurTextBlock.Text = "Veuillez avoir un mot de passe d'au moins 8 caractères.";
                motDePasseEstValide = false;
            }
            else
            {
                mdpErreurTextBlock.Text = "";
                motDePasseEstValide = true;
            }

            if (gestionConnexion.ConfirmationEstVide(confirmationMotDePasse))
            {
                confirmationErreurTextBlock.Text = "Veuillez confirmer votre mot de passe.";
                confirmationEstValide = false;
            }
            else if (!gestionConnexion.MotDePasseEstEgaleConfirmation(motDePasse, confirmationMotDePasse))
            {
                confirmationErreurTextBlock.Text = "Les deux mots de passe ne correspondent pas";
                confirmationEstValide = false;
            }
            else
            {
                confirmationErreurTextBlock.Text = "";
                confirmationEstValide = true;
            }

            if (confirmationEstValide && motDePasseEstValide && nomEstValide && prenomEstValide && courrielEstValide)
            {
                PageConnexionBD pageConnexionBD = new PageConnexionBD();
                bool estCree = pageConnexionBD.CreateGestionnaireBD(prenom, nom, courriel, motDePasse);
                
                if (estCree)
                {
                    PageConnexion pageConnexion = new PageConnexion("Compte créé avec succès.");
                    this.NavigationService.Navigate(pageConnexion);
                }
            }
            else
            {
                MessageValidation.Style = (Style)FindResource("SnackbarErrorStyle");
                MessageValidation.MessageQueue.Enqueue("Erreur lors de la création du compte.");
            }
        }
        private void Image_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            PageConnexion pageConnexion = new PageConnexion();
            this.NavigationService.Navigate(pageConnexion);
        }
        private void BoutonDeconnexion_Click(object sender, RoutedEventArgs e)
        {
            PageConnexion pageConnexion = new PageConnexion();
            this.NavigationService.Navigate(pageConnexion);
        }
    }
}

using System;
using System.Windows;
using System.Windows.Controls;
using MongoDB.Bson;
using TP2_14E_A2022.Data.Entites;
using TP2_14E_A2022.Data.Gestions;
using TP2_14E_A2022.Data.GestionsBD;

namespace TP2_14E_A2022.Pages;

public partial class OutilCreate : Page
{
    private readonly OutilDB _pageConnexionBd = new OutilDB();
    public GestionOutil gestionOutil;
    

    public OutilCreate(string message = null)
    {
        InitializeComponent();
        gestionOutil = new GestionOutil(_pageConnexionBd);
        
        if (!string.IsNullOrEmpty(message))
        {
            MessageValidation.Style = (Style)FindResource("SnackbarSuccessStyle");
            MessageValidation.MessageQueue.Enqueue(message);
        }
    }

    private void CreateButton_Click(object sender, RoutedEventArgs e)
    {
        NomErreurTextBlock.Text = "";
        DescriptionErreurTextBlock.Text = "";

        var objectId = ObjectId.GenerateNewId();
        string nom = NomTextBox.Text;
        string description = DescriptionTextBox.Text;
        bool estBrise = EstBriseCheckBox.IsChecked ?? false;

        // Validation variables
        bool isValid = true;

        // Nom validation
        if (!gestionOutil.NomEstValide(nom))
        {
            NomErreurTextBlock.Text = "Veuillez entrer le nom.";
            isValid = false;
        }

        // Description validation
        if (!gestionOutil.DescriptionEstValide(description))
        {
            DescriptionErreurTextBlock.Text = "Veuillez entrer la description.";
            isValid = false;
        }

        if (isValid)
        {
           
            Outils outil = new Outils(objectId, nom, description, estBrise);
            _pageConnexionBd.CreerOutil(outil);

            PageLireOutils pageLireOutils = new PageLireOutils("Ajout de l'outil avec succès!");
            NavigationService.Navigate(pageLireOutils);

        }
    }


    private void RetourMainMenuButton_Click(object sender, RoutedEventArgs e)
    {
        PageLireOutils lireOutils = new PageLireOutils();
        this.NavigationService.Navigate(lireOutils);
    }
}
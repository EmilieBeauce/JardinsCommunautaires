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
    

    public OutilCreate()
    {
        InitializeComponent();
        gestionOutil = new GestionOutil(_pageConnexionBd);
    }

    private void CreateButton_Click(object sender, RoutedEventArgs e)
    {
        // Reset error messages
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
            MessageBox.Show("Outil ajouté à la base de données.");
        }
    }


    private void RetourMainMenuButton_Click(object sender, RoutedEventArgs e)
    {
        PageLireOutils lireOutils = new PageLireOutils();
        this.NavigationService.Navigate(lireOutils);
    }
}
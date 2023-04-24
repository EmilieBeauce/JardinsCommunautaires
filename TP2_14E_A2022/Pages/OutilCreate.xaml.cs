using System;
using System.Windows;
using System.Windows.Controls;
using MongoDB.Bson;
using TP2_14E_A2022.Data.Entites;
using TP2_14E_A2022.Data.GestionsBD;

namespace TP2_14E_A2022.Pages;

public partial class OutilCreate : Page
{
    private readonly OutilDB _pageConnexionBd = new OutilDB();
    public string nomCompletGestionnaire;

    public OutilCreate()
    {
        InitializeComponent();
        try
        {
            _pageConnexionBd = new OutilDB();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
    }

    private void CreateButton_Click(object sender, RoutedEventArgs e)
    {
        // Validation variables
        bool isValid = true;
        string errorMsg = string.Empty;

        var objectId = ObjectId.GenerateNewId();
        string nom = NomTextBox.Text;
        string description = DescriptionTextBox.Text;
        bool estBrise = EstBriseCheckBox.IsChecked ?? false;

        // Nom validation
        if (string.IsNullOrWhiteSpace(nom))
        {
            errorMsg += "Veuillez entrer le nom.\n";
            isValid = false;
        }

        // Description validation
        if (string.IsNullOrWhiteSpace(description))
        {
            errorMsg += "Veuillez entrer la description.\n";
            isValid = false;
        }

        if (isValid)
        {
            Outils outil = new Outils(objectId, nom, description, estBrise);
            _pageConnexionBd.CreerOutil(outil);
            MessageBox.Show("Outil ajouté à la base de données.");
        }
        else
        {
            MessageBox.Show(errorMsg);
        }
    }

    private void RetourMainMenuButton_Click(object sender, RoutedEventArgs e)
    {
        PageLireOutils lireOutils = new PageLireOutils();
        this.NavigationService.Navigate(lireOutils);
    }
}
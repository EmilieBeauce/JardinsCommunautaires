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
        //TODO: 
        // Faire les validations pour les champs de create!!!
        
        var objectId = ObjectId.GenerateNewId();
        string nom = NomTextBox.Text;
        string description = DescriptionTextBox.Text;
        bool estBrise = EstBriseCheckBox.IsChecked ?? false;
        
        Outils outil = new Outils(objectId, nom, description, estBrise);
        _pageConnexionBd.CreerOutil(outil);
        MessageBox.Show("Outil ajouté à la base de données.");

    }
}
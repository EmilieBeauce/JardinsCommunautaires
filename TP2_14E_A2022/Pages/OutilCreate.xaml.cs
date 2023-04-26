using System;
using System.Threading.Tasks;
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
    public string nomCompletGestionnaire;

    public OutilCreate(string nomCompletGestionnaire, string message = null)
    {
        InitializeComponent();
        gestionOutil = new GestionOutil(_pageConnexionBd);
        this.nomCompletGestionnaire = nomCompletGestionnaire;
            
        nomCompletTextBlock.Text = nomCompletGestionnaire;
        
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

        bool isValid = true;

        if (!gestionOutil.NomEstValide(nom))
        {
            NomErreurTextBlock.Text = "Veuillez entrer le nom.";
            isValid = false;
        }

        if (!gestionOutil.DescriptionEstValide(description))
        {
            DescriptionErreurTextBlock.Text = "Veuillez entrer la description.";
            isValid = false;
        }

        if (isValid)
        {
           
            Outils outil = new Outils(objectId, nom, description, estBrise);
            _pageConnexionBd.CreerOutil(outil);

            PageLireOutils pageLireOutils = new PageLireOutils(nomCompletGestionnaire, "Outil mis à jour avec succès!");
            
            NavigationService.Navigate(pageLireOutils);

        }
    }

    private void BoutonDeconnexion_Click(object sender, RoutedEventArgs e)
    {
        PageConnexion pageConnexion = new PageConnexion();
        this.NavigationService.Navigate(pageConnexion);
    }

    private void RetourMainMenuButton_Click(object sender, RoutedEventArgs e)
    {
        PageLireOutils lireOutils = new PageLireOutils(nomCompletGestionnaire);
        this.NavigationService.Navigate(lireOutils);
    }
}
using System.Windows;
using System.Windows.Controls;
using TP2_14E_A2022.Data.Entites;

namespace TP2_14E_A2022.Pages;

public partial class PageLireUnOutil : Page
{
    public string nomCompletGestionnaire;

    public PageLireUnOutil(string nomCompletGestionnaire, Outils outil)
    {
        InitializeComponent();
        this.nomCompletGestionnaire = nomCompletGestionnaire;
            
        nomCompletTextBlock.Text = nomCompletGestionnaire;
        DataContext = outil;
        
    }
    
    private void BackButton_Click(object sender, RoutedEventArgs e)
    {
        var pageLireOutils = new PageLireOutils(nomCompletGestionnaire);
        NavigationService.Navigate(pageLireOutils);
    }

    private void BoutonDeconnexion_Click(object sender, RoutedEventArgs e)
    {
        PageConnexion pageConnexion = new PageConnexion();
        this.NavigationService.Navigate(pageConnexion);
    }
}
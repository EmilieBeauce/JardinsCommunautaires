using System.Windows;
using System.Windows.Controls;
using TP2_14E_A2022.Data.Entites;

namespace TP2_14E_A2022.Pages;

public partial class PageLireUnOutil : Page
{
    public PageLireUnOutil(Outils outil)
    {
        InitializeComponent();
        DataContext = outil;
    }
    
    private void BackButton_Click(object sender, RoutedEventArgs e)
    {
        var pageLireOutils = new PageLireOutils();
        NavigationService.Navigate(pageLireOutils);
    }
}
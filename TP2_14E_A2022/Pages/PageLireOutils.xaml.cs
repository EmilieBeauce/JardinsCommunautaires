using System;
using System.Windows;
using System.Windows.Controls;
using TP2_14E_A2022.Data.Entites;
using TP2_14E_A2022.Data.Gestions;
using TP2_14E_A2022.Data.GestionsBD;

namespace TP2_14E_A2022.Pages;

public partial class PageLireOutils : Page
{
    private readonly OutilDB _pageConnexionBd = new OutilDB();
    private GestionOutil _gestionOutil;
    
    public PageLireOutils()
    {
        InitializeComponent();
        try
        {
            _pageConnexionBd = new OutilDB();
            _gestionOutil = new GestionOutil(_pageConnexionBd);
            LoadOutils();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
    }
    
    private void LoadOutils()
    {
        OutilsDataGrid.ItemsSource = _gestionOutil.LireTousLesOutils();
    }

    private void DeleteButton_Click(object sender, RoutedEventArgs e)
    {
        var selectedOutil = (Outils)OutilsDataGrid.SelectedItem;
        if (selectedOutil != null && selectedOutil.Id.HasValue)
        {
            MessageBoxResult result = MessageBox.Show("Es-tu sûre?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
        
            if (result == MessageBoxResult.Yes)
            {
                _gestionOutil.SupprimerOutil(selectedOutil.Id.Value);
                LoadOutils();
            }
        }
    }

    private void ModifyButton_Click(object sender, RoutedEventArgs e)
    {
        var selectedOutil = (Outils)OutilsDataGrid.SelectedItem;
        if (selectedOutil != null)
        {
            var modifierOutilPage = new PageModifierOutil(_gestionOutil, selectedOutil);
            NavigationService.Navigate(modifierOutilPage);
        }
    }
}
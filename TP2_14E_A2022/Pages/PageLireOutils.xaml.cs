using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using GalaSoft.MvvmLight.CommandWpf;
using MaterialDesignThemes.Wpf;
using TP2_14E_A2022.Data.Entites;
using TP2_14E_A2022.Data.Gestions;
using TP2_14E_A2022.Data.GestionsBD;

namespace TP2_14E_A2022.Pages;

public partial class PageLireOutils : Page
{
    private readonly OutilDB _pageConnexionBd = new OutilDB();
    private GestionOutil _gestionOutil;
    private string nomCompletGestionnaire;

    public PageLireOutils(string message = null)
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
        
        if (!string.IsNullOrEmpty(message))
        {
            MessageValidation.Style = (Style)FindResource("SnackbarSuccessStyle");
            MessageValidation.MessageQueue.Enqueue(message);
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
                MessageValidation.Style = (Style)FindResource("SnackbarSuccessStyle");
                MessageValidation.MessageQueue.Enqueue($"Le membre {selectedOutil.Nom} a été supprimé.");
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

    private void Retour_Click(object sender, RoutedEventArgs e)
    {
        PageMenu mainPage = new PageMenu(nomCompletGestionnaire);
        this.NavigationService.Navigate(mainPage);
    }

    private void Ajouter_Click(object sender, RoutedEventArgs e)
    {
        OutilCreate pageCreate = new OutilCreate();
        this.NavigationService.Navigate(pageCreate);
    }
    
    private void ViewButton_Click(object sender, RoutedEventArgs e)
    {
        var selectedOutil = (Outils)OutilsDataGrid.SelectedItem;
        if (selectedOutil != null)
        {
            var viewOutilPage = new PageLireUnOutil(selectedOutil);
            NavigationService.Navigate(viewOutilPage);
        }
    }


}
using System.Windows;
using System.Windows.Controls;
using TP2_14E_A2022.Data.Entites;
using TP2_14E_A2022.Data.Gestions;

namespace TP2_14E_A2022.Pages;

public partial class PageModifierOutil : Page
{
    private readonly IGestionOutil _gestionOutil;
    private readonly Outils _selectedOutil;

    public PageModifierOutil(IGestionOutil gestionOutil, Outils selectedOutil)
    {
        InitializeComponent();
        _gestionOutil = gestionOutil;
        _selectedOutil = selectedOutil;

        // Populate the form with the selected outil's data
        NomTextBox.Text = _selectedOutil.Nom;
        DescriptionTextBox.Text = _selectedOutil.Description;
        EstBriseCheckBox.IsChecked = _selectedOutil.EstBrise;
    }

    private void UpdateButton_Click(object sender, RoutedEventArgs e)
    {
        _selectedOutil.Nom = NomTextBox.Text;
        _selectedOutil.Description = DescriptionTextBox.Text;
        _selectedOutil.EstBrise = EstBriseCheckBox.IsChecked.GetValueOrDefault();

        _gestionOutil.ModifierOutil(_selectedOutil);
        NavigationService.GoBack();
    }

    private void CancelButton_Click(object sender, RoutedEventArgs e)
    {
        NavigationService.GoBack();
    }
}
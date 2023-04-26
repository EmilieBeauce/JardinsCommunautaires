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
        bool isNomValid = _gestionOutil.NomEstValide(NomTextBox.Text);
        bool isDescriptionValid = _gestionOutil.DescriptionEstValide(DescriptionTextBox.Text);

        if (isNomValid)
        {
            NomError.Visibility = Visibility.Collapsed;
        }
        else
        {
            NomError.Text = "Nom invalide.";
            NomError.Visibility = Visibility.Visible;
        }

        if (isDescriptionValid)
        {
            DescriptionError.Visibility = Visibility.Collapsed;
        }
        else
        {
            DescriptionError.Text = "Description invalide.";
            DescriptionError.Visibility = Visibility.Visible;
        }

        if (isNomValid && isDescriptionValid)
        {
            _selectedOutil.Nom = NomTextBox.Text;
            _selectedOutil.Description = DescriptionTextBox.Text;
            _selectedOutil.EstBrise = EstBriseCheckBox.IsChecked.GetValueOrDefault();

            _gestionOutil.ModifierOutil(_selectedOutil);
            NavigationService.GoBack();
        }
    }


    private void CancelButton_Click(object sender, RoutedEventArgs e)
    {
        NavigationService.GoBack();
    }

    private void RetourMainMenuButton_Click(object sender, RoutedEventArgs e)
    {
        var listeoutils = new PageLireOutils();
        NavigationService.Navigate(listeoutils);
    }
}
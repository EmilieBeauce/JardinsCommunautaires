using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TP2_14E_A2022.Data.Entites;
using TP2_14E_A2022.Data.Gestions;
using TP2_14E_A2022.Data.GestionsBD;

namespace TP2_14E_A2022.Pages
{
    /// <summary>
    /// Logique d'interaction pour PageMembre.xaml
    /// </summary>
    public partial class PageMembre : Page
    {
        public List<Membre> ListeDesMembres { get; set; }
        public ICommand DetailsMembre { get; private set; }
        public PageMembre()
        {
            InitializeComponent();
            DetailsMembre = new RelayCommand<Membre>(AfficherDetailsMembre);
        }

        private void MembresListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Ajouter_Membre_Click(object sender, RoutedEventArgs e)
        {
            PageAjouterMembre pageAjouterMembre = new PageAjouterMembre();
            this.NavigationService.Navigate(pageAjouterMembre);
        }
        private void BoutonDeconnexion_Click(object sender, RoutedEventArgs e)
        {

        }

        public void AfficherDetailsMembre(Membre membre)
        {
            PageDetailsMembre pageDetailsMembre = new PageDetailsMembre(membre);
            this.NavigationService.Navigate(pageDetailsMembre);
        }
       


        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            MembreDB membreDB = new MembreDB();
            ListeDesMembres = membreDB.GetMembres();
            MembresListBox.ItemsSource = ListeDesMembres;
            this.DataContext = this;
        }
    }
}

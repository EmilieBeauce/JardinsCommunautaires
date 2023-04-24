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

namespace TP2_14E_A2022.Pages
{
    /// <summary>
    /// Logique d'interaction pour PageDetailsMembre.xaml
    /// </summary>
    public partial class PageDetailsMembre : Page
    {
        public Membre MembreSelectionne { get; set; }
        public string nomCompletGestionnaire;
        private GestionMembre gestionMembre;
        public PageDetailsMembre(Membre membre, string nomCompletGestionnaire, GestionMembre gestionMembre)
        {
            InitializeComponent();
            MembreSelectionne = membre;
            
            this.DataContext = this;
            this.nomCompletGestionnaire = nomCompletGestionnaire;
            this.gestionMembre = gestionMembre;
            
            AdresseMessageTxt.Text = gestionMembre.GetAdresseMessage(MembreSelectionne);
            CotisationMessageTxt.Text = gestionMembre.GetCotisationMessage(MembreSelectionne);
            LotMessageTxt.Text = gestionMembre.GetLotMessage(MembreSelectionne);
        }

        private void Logo_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            PageMenu pageMenu = new PageMenu(nomCompletGestionnaire);
            this.NavigationService.Navigate(pageMenu);
        }
    }
}

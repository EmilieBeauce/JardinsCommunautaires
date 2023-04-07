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
using TP2_14E_A2022.Data.Gestions;
using TP2_14E_A2022.Data.GestionsBD;


namespace TP2_14E_A2022.Pages
{
    /// <summary>
    /// Logique d'interaction pour PageConnexion.xaml
    /// </summary>
    public partial class PageConnexion
    {
        private PageConnexionBD pageConnexionBD;
        public PageConnexion()
        {
            //DAL dal = new DAL()
            InitializeComponent();
            pageConnexionBD = new PageConnexionBD();

        }
        private void BoutonConnexion_Click(object sender, RoutedEventArgs e)
        {
            string courriel = courrielTextBox.Text;
            string motDePasse = mdpPasswordBox.Password;

            // Vérifier les informations de connexion
            bool estConnecte = pageConnexionBD.SeConnecter(courriel, motDePasse);

            if (estConnecte)
            {
                // Rediriger l'utilisateur vers la page de menu
                PageMenu pageMenu = new PageMenu();
                this.NavigationService.Navigate(pageMenu);
            }
            else
            {
                MessageBox.Show("Nom d'utilisateur ou mot de passe incorrect.");
            }
        }

    }
}

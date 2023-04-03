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
using TP214E.Data;

namespace TP2_14E_A2022.Pages
{
    /// <summary>
    /// Logique d'interaction pour PageConnexion.xaml
    /// </summary>
    public partial class PageConnexion : Page
    {
        private DAL dal;
        public PageConnexion()
        {
            //DAL dal = new DAL()
            InitializeComponent();
            dal = new DAL();

        }
        private void BoutonConnexion_Click(object sender, RoutedEventArgs e)
        {
            PageMenu pageMenu = new PageMenu();

            this.NavigationService.Navigate(pageMenu);

        }

    }
}

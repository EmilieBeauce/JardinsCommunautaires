﻿using System;
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


namespace TP2_14E_A2022.Pages
{
    /// <summary>
    /// Logique d'interaction pour PageMenu.xaml
    /// </summary>
    public partial class PageMenu : Page
    {
        public string nomCompletGestionnaire;
        public PageMenu(string nomCompletGestionnaire)
        {
            InitializeComponent();
            this.nomCompletGestionnaire = nomCompletGestionnaire; 
            nomCompletTextBlock.Text = nomCompletGestionnaire;
        }

        private void BoutonDeconnexion_Click(object sender, MouseButtonEventArgs e)
        {
            PageConnexion pageConnexion = new PageConnexion();

            this.NavigationService.Navigate(pageConnexion);
        }

       



       
    }
}

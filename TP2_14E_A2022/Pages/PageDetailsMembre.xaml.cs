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
using TP2_14E_A2022.Data.Entites;

namespace TP2_14E_A2022.Pages
{
    /// <summary>
    /// Logique d'interaction pour PageDetailsMembre.xaml
    /// </summary>
    public partial class PageDetailsMembre : Page
    {
        public Membre MembreSelectionne { get; set; }
        public PageDetailsMembre(Membre membre)
        {
            InitializeComponent();
            MembreSelectionne = membre;
            this.DataContext = this;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
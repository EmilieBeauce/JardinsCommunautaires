﻿#pragma checksum "..\..\..\..\Pages\PageMembre.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5845DEB148241F3A5A97683B7E7685C35841ADB4"
//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.42000
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

using MaterialDesignThemes.MahApps;
using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;
using TP2_14E_A2022.Pages;


namespace TP2_14E_A2022.Pages {
    
    
    /// <summary>
    /// PageMembre
    /// </summary>
    public partial class PageMembre : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 27 "..\..\..\..\Pages\PageMembre.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image Logo;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\..\Pages\PageMembre.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock nomCompletTextBlock;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\..\..\Pages\PageMembre.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox MembresListBox;
        
        #line default
        #line hidden
        
        
        #line 119 "..\..\..\..\Pages\PageMembre.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Ajouter_un_Membre;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.2.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/TP2_14E_A2022;V1.0.0.0;component/pages/pagemembre.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Pages\PageMembre.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.2.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 12 "..\..\..\..\Pages\PageMembre.xaml"
            ((TP2_14E_A2022.Pages.PageMembre)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Page_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.Logo = ((System.Windows.Controls.Image)(target));
            
            #line 27 "..\..\..\..\Pages\PageMembre.xaml"
            this.Logo.MouseLeftButtonUp += new System.Windows.Input.MouseButtonEventHandler(this.Logo_MouseLeftButtonUp);
            
            #line default
            #line hidden
            return;
            case 3:
            this.nomCompletTextBlock = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 4:
            
            #line 34 "..\..\..\..\Pages\PageMembre.xaml"
            ((System.Windows.Controls.TextBlock)(target)).MouseLeftButtonUp += new System.Windows.Input.MouseButtonEventHandler(this.BoutonDeconnexion_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.MembresListBox = ((System.Windows.Controls.ListBox)(target));
            
            #line 47 "..\..\..\..\Pages\PageMembre.xaml"
            this.MembresListBox.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.MembresListBox_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 6:
            this.Ajouter_un_Membre = ((System.Windows.Controls.Button)(target));
            
            #line 119 "..\..\..\..\Pages\PageMembre.xaml"
            this.Ajouter_un_Membre.Click += new System.Windows.RoutedEventHandler(this.Button_Ajouter_Membre_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}


﻿#pragma checksum "..\..\..\..\Pages\PageCreationOutil.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5814733E9C906798722EFDD1E8DAD59A0ECC9217"
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
    /// OutilCreate
    /// </summary>
    public partial class OutilCreate : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 36 "..\..\..\..\Pages\PageCreationOutil.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MaterialDesignThemes.Wpf.Snackbar MessageValidation;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\..\..\Pages\PageCreationOutil.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock nomCompletTextBlock;
        
        #line default
        #line hidden
        
        
        #line 59 "..\..\..\..\Pages\PageCreationOutil.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox NomTextBox;
        
        #line default
        #line hidden
        
        
        #line 60 "..\..\..\..\Pages\PageCreationOutil.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock NomErreurTextBlock;
        
        #line default
        #line hidden
        
        
        #line 63 "..\..\..\..\Pages\PageCreationOutil.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox DescriptionTextBox;
        
        #line default
        #line hidden
        
        
        #line 64 "..\..\..\..\Pages\PageCreationOutil.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock DescriptionErreurTextBlock;
        
        #line default
        #line hidden
        
        
        #line 66 "..\..\..\..\Pages\PageCreationOutil.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox EstBriseCheckBox;
        
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
            System.Uri resourceLocater = new System.Uri("/TP2_14E_A2022;V1.0.0.0;component/pages/pagecreationoutil.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Pages\PageCreationOutil.xaml"
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
            this.MessageValidation = ((MaterialDesignThemes.Wpf.Snackbar)(target));
            return;
            case 2:
            this.nomCompletTextBlock = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            
            #line 47 "..\..\..\..\Pages\PageCreationOutil.xaml"
            ((System.Windows.Controls.TextBlock)(target)).MouseLeftButtonUp += new System.Windows.Input.MouseButtonEventHandler(this.BoutonDeconnexion_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 50 "..\..\..\..\Pages\PageCreationOutil.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.RetourMainMenuButton_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.NomTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.NomErreurTextBlock = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 7:
            this.DescriptionTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.DescriptionErreurTextBlock = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 9:
            this.EstBriseCheckBox = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 10:
            
            #line 69 "..\..\..\..\Pages\PageCreationOutil.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.CreateButton_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}


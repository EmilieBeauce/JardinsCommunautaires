﻿#pragma checksum "..\..\..\..\Pages\PageDetailsMembre.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9B8C9A967F716484245AF9E65D5BEEA5EF5E3585"
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
    /// PageDetailsMembre
    /// </summary>
    public partial class PageDetailsMembre : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 44 "..\..\..\..\Pages\PageDetailsMembre.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock nomCompletTextBlock;
        
        #line default
        #line hidden
        
        
        #line 59 "..\..\..\..\Pages\PageDetailsMembre.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock AdresseMessageTxt;
        
        #line default
        #line hidden
        
        
        #line 67 "..\..\..\..\Pages\PageDetailsMembre.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox EstPayeCheckBox;
        
        #line default
        #line hidden
        
        
        #line 68 "..\..\..\..\Pages\PageDetailsMembre.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock FeeAmountTextBlock;
        
        #line default
        #line hidden
        
        
        #line 71 "..\..\..\..\Pages\PageDetailsMembre.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock LotMessageTxt;
        
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
            System.Uri resourceLocater = new System.Uri("/TP2_14E_A2022;component/pages/pagedetailsmembre.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Pages\PageDetailsMembre.xaml"
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
            
            #line 36 "..\..\..\..\Pages\PageDetailsMembre.xaml"
            ((System.Windows.Controls.Image)(target)).MouseLeftButtonUp += new System.Windows.Input.MouseButtonEventHandler(this.Logo_MouseLeftButtonUp);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 39 "..\..\..\..\Pages\PageDetailsMembre.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.BackButton_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.nomCompletTextBlock = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 4:
            
            #line 46 "..\..\..\..\Pages\PageDetailsMembre.xaml"
            ((System.Windows.Controls.TextBlock)(target)).MouseLeftButtonUp += new System.Windows.Input.MouseButtonEventHandler(this.BoutonDeconnexion_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.AdresseMessageTxt = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 6:
            this.EstPayeCheckBox = ((System.Windows.Controls.CheckBox)(target));
            
            #line 67 "..\..\..\..\Pages\PageDetailsMembre.xaml"
            this.EstPayeCheckBox.Checked += new System.Windows.RoutedEventHandler(this.EstPayeCheckBox_Checked);
            
            #line default
            #line hidden
            
            #line 67 "..\..\..\..\Pages\PageDetailsMembre.xaml"
            this.EstPayeCheckBox.Unchecked += new System.Windows.RoutedEventHandler(this.EstPayeCheckBox_Unchecked);
            
            #line default
            #line hidden
            return;
            case 7:
            this.FeeAmountTextBlock = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 8:
            this.LotMessageTxt = ((System.Windows.Controls.TextBlock)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}


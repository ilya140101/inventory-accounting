﻿#pragma checksum "..\..\SalesReport.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "887E2930BB00FBBB8BAED2BCA690CD6663D9C3E240F2DF459C87F7C68B8E6908"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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
using inventory_accounting;


namespace inventory_accounting {
    
    
    /// <summary>
    /// SalesReport
    /// </summary>
    public partial class SalesReport : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 14 "..\..\SalesReport.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid table;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\SalesReport.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGridTextColumn dgCode;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\SalesReport.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGridTextColumn dgName;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\SalesReport.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGridTextColumn dgQuantity;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\SalesReport.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGridTextColumn dgPurchasePrice;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\SalesReport.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGridTextColumn dgSalePrice;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\SalesReport.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox find_code;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\SalesReport.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox find_name;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\SalesReport.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox find_quantity;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\SalesReport.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox find_salePrice;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\SalesReport.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox find_purchasePrice;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/inventory accounting;component/salesreport.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\SalesReport.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.table = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 2:
            this.dgCode = ((System.Windows.Controls.DataGridTextColumn)(target));
            return;
            case 3:
            this.dgName = ((System.Windows.Controls.DataGridTextColumn)(target));
            return;
            case 4:
            this.dgQuantity = ((System.Windows.Controls.DataGridTextColumn)(target));
            return;
            case 5:
            this.dgPurchasePrice = ((System.Windows.Controls.DataGridTextColumn)(target));
            return;
            case 6:
            this.dgSalePrice = ((System.Windows.Controls.DataGridTextColumn)(target));
            return;
            case 7:
            this.find_code = ((System.Windows.Controls.TextBox)(target));
            
            #line 39 "..\..\SalesReport.xaml"
            this.find_code.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.Find_code_TextChanged);
            
            #line default
            #line hidden
            
            #line 39 "..\..\SalesReport.xaml"
            this.find_code.GotFocus += new System.Windows.RoutedEventHandler(this.Find_GotFocus);
            
            #line default
            #line hidden
            
            #line 39 "..\..\SalesReport.xaml"
            this.find_code.LostFocus += new System.Windows.RoutedEventHandler(this.Find_LostFocus);
            
            #line default
            #line hidden
            return;
            case 8:
            this.find_name = ((System.Windows.Controls.TextBox)(target));
            
            #line 40 "..\..\SalesReport.xaml"
            this.find_name.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.Find_name_TextChanged);
            
            #line default
            #line hidden
            
            #line 40 "..\..\SalesReport.xaml"
            this.find_name.GotFocus += new System.Windows.RoutedEventHandler(this.Find_GotFocus);
            
            #line default
            #line hidden
            
            #line 40 "..\..\SalesReport.xaml"
            this.find_name.LostFocus += new System.Windows.RoutedEventHandler(this.Find_LostFocus);
            
            #line default
            #line hidden
            return;
            case 9:
            this.find_quantity = ((System.Windows.Controls.TextBox)(target));
            
            #line 41 "..\..\SalesReport.xaml"
            this.find_quantity.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.Find_quantity_TextChanged);
            
            #line default
            #line hidden
            
            #line 41 "..\..\SalesReport.xaml"
            this.find_quantity.GotFocus += new System.Windows.RoutedEventHandler(this.Find_GotFocus);
            
            #line default
            #line hidden
            
            #line 41 "..\..\SalesReport.xaml"
            this.find_quantity.LostFocus += new System.Windows.RoutedEventHandler(this.Find_LostFocus);
            
            #line default
            #line hidden
            return;
            case 10:
            this.find_salePrice = ((System.Windows.Controls.TextBox)(target));
            
            #line 42 "..\..\SalesReport.xaml"
            this.find_salePrice.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.Find_purchasePrice_TextChanged);
            
            #line default
            #line hidden
            
            #line 42 "..\..\SalesReport.xaml"
            this.find_salePrice.GotFocus += new System.Windows.RoutedEventHandler(this.Find_GotFocus);
            
            #line default
            #line hidden
            
            #line 42 "..\..\SalesReport.xaml"
            this.find_salePrice.LostFocus += new System.Windows.RoutedEventHandler(this.Find_LostFocus);
            
            #line default
            #line hidden
            return;
            case 11:
            this.find_purchasePrice = ((System.Windows.Controls.TextBox)(target));
            
            #line 43 "..\..\SalesReport.xaml"
            this.find_purchasePrice.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.Find_salePrice_TextChanged);
            
            #line default
            #line hidden
            
            #line 43 "..\..\SalesReport.xaml"
            this.find_purchasePrice.GotFocus += new System.Windows.RoutedEventHandler(this.Find_GotFocus);
            
            #line default
            #line hidden
            
            #line 43 "..\..\SalesReport.xaml"
            this.find_purchasePrice.LostFocus += new System.Windows.RoutedEventHandler(this.Find_LostFocus);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}


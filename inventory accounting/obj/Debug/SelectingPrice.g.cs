#pragma checksum "..\..\SelectingPrice.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "7F0746651E2218F9CFFBCE6AFAF10C3CA5673DCADA6132B883C64E84FAC41285"
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
    /// SelectingPrice
    /// </summary>
    public partial class SelectingPrice : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 15 "..\..\SelectingPrice.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Count;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\SelectingPrice.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Purchase;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\SelectingPrice.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Sale;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\SelectingPrice.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Profit;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\SelectingPrice.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button OK;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\SelectingPrice.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock Name;
        
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
            System.Uri resourceLocater = new System.Uri("/inventory accounting;component/selectingprice.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\SelectingPrice.xaml"
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
            
            #line 8 "..\..\SelectingPrice.xaml"
            ((inventory_accounting.SelectingPrice)(target)).KeyDown += new System.Windows.Input.KeyEventHandler(this.Window_KeyDown);
            
            #line default
            #line hidden
            return;
            case 2:
            this.Count = ((System.Windows.Controls.TextBox)(target));
            
            #line 15 "..\..\SelectingPrice.xaml"
            this.Count.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.NumberValidationTextBox);
            
            #line default
            #line hidden
            
            #line 15 "..\..\SelectingPrice.xaml"
            this.Count.LostFocus += new System.Windows.RoutedEventHandler(this.NewLostFocus);
            
            #line default
            #line hidden
            return;
            case 3:
            this.Purchase = ((System.Windows.Controls.TextBox)(target));
            
            #line 16 "..\..\SelectingPrice.xaml"
            this.Purchase.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.NumberValidationTextBox);
            
            #line default
            #line hidden
            
            #line 16 "..\..\SelectingPrice.xaml"
            this.Purchase.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.Purchase_TextChanged);
            
            #line default
            #line hidden
            
            #line 16 "..\..\SelectingPrice.xaml"
            this.Purchase.LostFocus += new System.Windows.RoutedEventHandler(this.NewLostFocus);
            
            #line default
            #line hidden
            return;
            case 4:
            this.Sale = ((System.Windows.Controls.TextBox)(target));
            
            #line 17 "..\..\SelectingPrice.xaml"
            this.Sale.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.NumberValidationTextBox);
            
            #line default
            #line hidden
            
            #line 17 "..\..\SelectingPrice.xaml"
            this.Sale.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.Sale_TextChanged);
            
            #line default
            #line hidden
            
            #line 17 "..\..\SelectingPrice.xaml"
            this.Sale.LostFocus += new System.Windows.RoutedEventHandler(this.NewLostFocus);
            
            #line default
            #line hidden
            return;
            case 5:
            this.Profit = ((System.Windows.Controls.TextBox)(target));
            
            #line 18 "..\..\SelectingPrice.xaml"
            this.Profit.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.NumberValidationTextBox);
            
            #line default
            #line hidden
            
            #line 18 "..\..\SelectingPrice.xaml"
            this.Profit.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.Profit_TextChanged);
            
            #line default
            #line hidden
            
            #line 18 "..\..\SelectingPrice.xaml"
            this.Profit.LostFocus += new System.Windows.RoutedEventHandler(this.NewLostFocus);
            
            #line default
            #line hidden
            return;
            case 6:
            this.OK = ((System.Windows.Controls.Button)(target));
            
            #line 22 "..\..\SelectingPrice.xaml"
            this.OK.Click += new System.Windows.RoutedEventHandler(this.OK_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            
            #line 23 "..\..\SelectingPrice.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.Name = ((System.Windows.Controls.TextBlock)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}


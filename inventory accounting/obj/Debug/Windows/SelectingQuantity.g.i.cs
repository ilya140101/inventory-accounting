#pragma checksum "..\..\..\Windows\SelectingQuantity.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "420FE8222A572C42745BFB039F35023B98E8AA770808A53D7F3331061E0A0B14"
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
    /// SelectingQuantity
    /// </summary>
    public partial class SelectingQuantity : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 16 "..\..\..\Windows\SelectingQuantity.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock SalePrice;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\Windows\SelectingQuantity.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Count;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\Windows\SelectingQuantity.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Discount;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\Windows\SelectingQuantity.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Summ;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\Windows\SelectingQuantity.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button OK;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\Windows\SelectingQuantity.xaml"
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
            System.Uri resourceLocater = new System.Uri("/inventory accounting;component/windows/selectingquantity.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Windows\SelectingQuantity.xaml"
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
            
            #line 8 "..\..\..\Windows\SelectingQuantity.xaml"
            ((inventory_accounting.SelectingQuantity)(target)).KeyDown += new System.Windows.Input.KeyEventHandler(this.Window_KeyDown);
            
            #line default
            #line hidden
            return;
            case 2:
            this.SalePrice = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            this.Count = ((System.Windows.Controls.TextBox)(target));
            
            #line 17 "..\..\..\Windows\SelectingQuantity.xaml"
            this.Count.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.NumberValidationTextBox);
            
            #line default
            #line hidden
            
            #line 17 "..\..\..\Windows\SelectingQuantity.xaml"
            this.Count.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.Count_TextChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.Discount = ((System.Windows.Controls.TextBox)(target));
            
            #line 18 "..\..\..\Windows\SelectingQuantity.xaml"
            this.Discount.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.NumberValidationTextBox);
            
            #line default
            #line hidden
            
            #line 18 "..\..\..\Windows\SelectingQuantity.xaml"
            this.Discount.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.Discount_TextChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.Summ = ((System.Windows.Controls.TextBox)(target));
            
            #line 19 "..\..\..\Windows\SelectingQuantity.xaml"
            this.Summ.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.NumberValidationTextBox);
            
            #line default
            #line hidden
            
            #line 19 "..\..\..\Windows\SelectingQuantity.xaml"
            this.Summ.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.Summ_TextChanged);
            
            #line default
            #line hidden
            return;
            case 6:
            this.OK = ((System.Windows.Controls.Button)(target));
            
            #line 23 "..\..\..\Windows\SelectingQuantity.xaml"
            this.OK.Click += new System.Windows.RoutedEventHandler(this.OK_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            
            #line 24 "..\..\..\Windows\SelectingQuantity.xaml"
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


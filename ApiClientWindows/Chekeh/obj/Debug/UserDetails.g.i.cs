﻿#pragma checksum "..\..\UserDetails.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "AF2DA84E71C74A2B1D1F0F7E9033C4BB"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Chekeh;
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


namespace Chekeh {
    
    
    /// <summary>
    /// UserDetails
    /// </summary>
    public partial class UserDetails : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\UserDetails.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button button_Chat;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\UserDetails.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label label_Username;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\UserDetails.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label label_FirstName;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\UserDetails.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label label_LastName;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\UserDetails.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label label_NationalCode;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\UserDetails.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label label_PostalCode;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\UserDetails.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label label_PhoneNumber;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\UserDetails.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label label_Address;
        
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
            System.Uri resourceLocater = new System.Uri("/Chekeh;component/userdetails.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\UserDetails.xaml"
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
            
            #line 8 "..\..\UserDetails.xaml"
            ((Chekeh.UserDetails)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.button_Chat = ((System.Windows.Controls.Button)(target));
            
            #line 10 "..\..\UserDetails.xaml"
            this.button_Chat.Click += new System.Windows.RoutedEventHandler(this.button_Chat_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.label_Username = ((System.Windows.Controls.Label)(target));
            return;
            case 4:
            this.label_FirstName = ((System.Windows.Controls.Label)(target));
            return;
            case 5:
            this.label_LastName = ((System.Windows.Controls.Label)(target));
            return;
            case 6:
            this.label_NationalCode = ((System.Windows.Controls.Label)(target));
            return;
            case 7:
            this.label_PostalCode = ((System.Windows.Controls.Label)(target));
            return;
            case 8:
            this.label_PhoneNumber = ((System.Windows.Controls.Label)(target));
            return;
            case 9:
            this.label_Address = ((System.Windows.Controls.Label)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}


﻿#pragma checksum "..\..\TrayPopup.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1EBE68C69B8B3C6C772850ACEB24AF8DF1DC9D54"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
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


namespace Calendar {
    
    
    /// <summary>
    /// TrayPopup
    /// </summary>
    public partial class TrayPopup : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 14 "..\..\TrayPopup.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button CalendarButton;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\TrayPopup.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button QuitButton;
        
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
            System.Uri resourceLocater = new System.Uri("/Calendar;component/traypopup.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\TrayPopup.xaml"
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
            this.CalendarButton = ((System.Windows.Controls.Button)(target));
            
            #line 18 "..\..\TrayPopup.xaml"
            this.CalendarButton.Click += new System.Windows.RoutedEventHandler(this.CalendarButton_OnClick);
            
            #line default
            #line hidden
            
            #line 19 "..\..\TrayPopup.xaml"
            this.CalendarButton.MouseEnter += new System.Windows.Input.MouseEventHandler(this.Button_OnMouseEnter);
            
            #line default
            #line hidden
            
            #line 20 "..\..\TrayPopup.xaml"
            this.CalendarButton.MouseLeave += new System.Windows.Input.MouseEventHandler(this.Button_OnMouseLeave);
            
            #line default
            #line hidden
            return;
            case 2:
            this.QuitButton = ((System.Windows.Controls.Button)(target));
            
            #line 25 "..\..\TrayPopup.xaml"
            this.QuitButton.Click += new System.Windows.RoutedEventHandler(this.QuitButton_OnClick);
            
            #line default
            #line hidden
            
            #line 26 "..\..\TrayPopup.xaml"
            this.QuitButton.MouseEnter += new System.Windows.Input.MouseEventHandler(this.Button_OnMouseEnter);
            
            #line default
            #line hidden
            
            #line 27 "..\..\TrayPopup.xaml"
            this.QuitButton.MouseLeave += new System.Windows.Input.MouseEventHandler(this.Button_OnMouseLeave);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}


﻿#pragma checksum "..\..\..\..\Monatsuebersicht.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "36FD1E612170F2E22E6EE9A94C517A196CA63DFA"
//------------------------------------------------------------------------------
// <auto-generated>
//     Dieser Code wurde von einem Tool generiert.
//     Laufzeitversion:4.0.30319.42000
//
//     Änderungen an dieser Datei können falsches Verhalten verursachen und gehen verloren, wenn
//     der Code erneut generiert wird.
// </auto-generated>
//------------------------------------------------------------------------------

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
using Zeiterfassung_WPF;


namespace Zeiterfassung_WPF {
    
    
    /// <summary>
    /// Monatsuebersicht
    /// </summary>
    public partial class Monatsuebersicht : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 1 "..\..\..\..\Monatsuebersicht.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Zeiterfassung_WPF.Monatsuebersicht monthSummary;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\..\Monatsuebersicht.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label status;
        
        #line default
        #line hidden
        
        
        #line 50 "..\..\..\..\Monatsuebersicht.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label actualMonth;
        
        #line default
        #line hidden
        
        
        #line 58 "..\..\..\..\Monatsuebersicht.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label summary;
        
        #line default
        #line hidden
        
        
        #line 67 "..\..\..\..\Monatsuebersicht.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label SummaryHourMonth;
        
        #line default
        #line hidden
        
        
        #line 84 "..\..\..\..\Monatsuebersicht.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid calendar;
        
        #line default
        #line hidden
        
        
        #line 86 "..\..\..\..\Monatsuebersicht.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ItemsControl icCalendar;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.3.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Zeiterfassung_WPF;component/monatsuebersicht.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Monatsuebersicht.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.3.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.monthSummary = ((Zeiterfassung_WPF.Monatsuebersicht)(target));
            return;
            case 2:
            this.status = ((System.Windows.Controls.Label)(target));
            return;
            case 3:
            this.actualMonth = ((System.Windows.Controls.Label)(target));
            return;
            case 4:
            this.summary = ((System.Windows.Controls.Label)(target));
            return;
            case 5:
            this.SummaryHourMonth = ((System.Windows.Controls.Label)(target));
            return;
            case 6:
            this.calendar = ((System.Windows.Controls.Grid)(target));
            return;
            case 7:
            this.icCalendar = ((System.Windows.Controls.ItemsControl)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}


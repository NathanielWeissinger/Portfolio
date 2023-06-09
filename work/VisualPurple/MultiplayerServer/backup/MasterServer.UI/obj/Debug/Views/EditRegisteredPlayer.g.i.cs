﻿#pragma checksum "..\..\..\Views\EditRegisteredPlayer.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "AE594076AFEAA24838C1F407D7A1C24F274A110405DF705F24E229C1E20942D7"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using MahApps.Metro;
using MahApps.Metro.Accessibility;
using MahApps.Metro.Actions;
using MahApps.Metro.Automation.Peers;
using MahApps.Metro.Behaviors;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using MahApps.Metro.Converters;
using MahApps.Metro.Markup;
using MahApps.Metro.Theming;
using MahApps.Metro.ValueBoxes;
using MasterServer.UI.Converters;
using MasterServer.UI.ViewModels;
using MasterServer.UI.Views;
using MvvmDialogs;
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


namespace MasterServer.UI.Views {
    
    
    /// <summary>
    /// EditRegisteredPlayer
    /// </summary>
    public partial class EditRegisteredPlayer : MahApps.Metro.Controls.MetroWindow, System.Windows.Markup.IComponentConnector {
        
        
        #line 18 "..\..\..\Views\EditRegisteredPlayer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MasterServer.UI.Views.EditRegisteredPlayer EditPlayerWindow;
        
        #line default
        #line hidden
        
        
        #line 68 "..\..\..\Views\EditRegisteredPlayer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox NameEntry;
        
        #line default
        #line hidden
        
        
        #line 88 "..\..\..\Views\EditRegisteredPlayer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock PlayerIDEntry;
        
        #line default
        #line hidden
        
        
        #line 100 "..\..\..\Views\EditRegisteredPlayer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button logsBtn;
        
        #line default
        #line hidden
        
        
        #line 116 "..\..\..\Views\EditRegisteredPlayer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox GenderEntry;
        
        #line default
        #line hidden
        
        
        #line 129 "..\..\..\Views\EditRegisteredPlayer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox SSNEntry;
        
        #line default
        #line hidden
        
        
        #line 142 "..\..\..\Views\EditRegisteredPlayer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox PasswordEntry;
        
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
            System.Uri resourceLocater = new System.Uri("/MasterServer.UI;component/views/editregisteredplayer.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Views\EditRegisteredPlayer.xaml"
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
            this.EditPlayerWindow = ((MasterServer.UI.Views.EditRegisteredPlayer)(target));
            
            #line 16 "..\..\..\Views\EditRegisteredPlayer.xaml"
            this.EditPlayerWindow.Loaded += new System.Windows.RoutedEventHandler(this.EditPlayerWindow_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.NameEntry = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.PlayerIDEntry = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 4:
            this.logsBtn = ((System.Windows.Controls.Button)(target));
            return;
            case 5:
            this.GenderEntry = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.SSNEntry = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.PasswordEntry = ((System.Windows.Controls.TextBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}


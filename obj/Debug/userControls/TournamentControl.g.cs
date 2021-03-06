#pragma checksum "..\..\..\userControls\TournamentControl.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "80DC3745D39005AF50DB04A4C021DC41B54515EE612DF8C30F1F033F7167EE9B"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using ChessBase.Models;
using ChessBase.pages;
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


namespace ChessBase.pages {
    
    
    /// <summary>
    /// TournamentControl
    /// </summary>
    public partial class TournamentControl : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 27 "..\..\..\userControls\TournamentControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid tournamentDataGrid;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\userControls\TournamentControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGridTextColumn nameColumn;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\userControls\TournamentControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGridTextColumn locationColumn;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\userControls\TournamentControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGridTextColumn startColumn;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\userControls\TournamentControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGridTextColumn endColumn;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\userControls\TournamentControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid playersDataGrid;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\..\userControls\TournamentControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGridTextColumn PlayerNameColumn;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\..\userControls\TournamentControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGridTextColumn PlayerRatingColumn;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\..\userControls\TournamentControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGridTextColumn PlayerBirthYearColumn;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\..\userControls\TournamentControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGridTextColumn PlayerCountryColumn;
        
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
            System.Uri resourceLocater = new System.Uri("/ChessBase;component/usercontrols/tournamentcontrol.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\userControls\TournamentControl.xaml"
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
            
            #line 9 "..\..\..\userControls\TournamentControl.xaml"
            ((ChessBase.pages.TournamentControl)(target)).Loaded += new System.Windows.RoutedEventHandler(this.UserControl_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.tournamentDataGrid = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 3:
            this.nameColumn = ((System.Windows.Controls.DataGridTextColumn)(target));
            return;
            case 4:
            this.locationColumn = ((System.Windows.Controls.DataGridTextColumn)(target));
            return;
            case 5:
            this.startColumn = ((System.Windows.Controls.DataGridTextColumn)(target));
            return;
            case 6:
            this.endColumn = ((System.Windows.Controls.DataGridTextColumn)(target));
            return;
            case 7:
            this.playersDataGrid = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 8:
            this.PlayerNameColumn = ((System.Windows.Controls.DataGridTextColumn)(target));
            return;
            case 9:
            this.PlayerRatingColumn = ((System.Windows.Controls.DataGridTextColumn)(target));
            return;
            case 10:
            this.PlayerBirthYearColumn = ((System.Windows.Controls.DataGridTextColumn)(target));
            return;
            case 11:
            this.PlayerCountryColumn = ((System.Windows.Controls.DataGridTextColumn)(target));
            return;
            case 12:
            
            #line 45 "..\..\..\userControls\TournamentControl.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Add_Tournament);
            
            #line default
            #line hidden
            return;
            case 13:
            
            #line 72 "..\..\..\userControls\TournamentControl.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Delete_Tournament);
            
            #line default
            #line hidden
            return;
            case 14:
            
            #line 100 "..\..\..\userControls\TournamentControl.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Add_Player_To_Tournament);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}


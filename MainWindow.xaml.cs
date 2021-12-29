using ChessBase.DAL;
using ChessBase.pages;
using ChessBase.userControls;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ChessBase
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static readonly ChessBaseContext context = new ChessBaseContext();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            context.Players.Load();
            contentControl.Content = new TournamentControl();
        }
        private void Employee_Click(object sneder, RoutedEventArgs e)
        {
            contentControl.Content = new EmployeeControl();
        }

        private void Tournement_Click(object sender, RoutedEventArgs e)
        {
            contentControl.Content = new TournamentControl(); ;
        }

        private void Player_Click(object sender, RoutedEventArgs e)
        {
            contentControl.Content = new PlayerControl();
        }
    }

    public delegate void RefreshListDelegate(); // delegate blueprint

}

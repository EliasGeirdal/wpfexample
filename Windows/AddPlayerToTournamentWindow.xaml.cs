using ChessBase.DAL;
using ChessBase.Models;
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
using System.Windows.Shapes;

namespace ChessBase.Windows
{
    /// <summary>
    /// Interaction logic for AddPlayerToTournamentWindow.xaml
    /// </summary>
    public partial class AddPlayerToTournamentWindow : Window
    {
        public Tournament SelectedTournament { get; set; }
        public AddPlayerToTournamentWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            System.Windows.Data.CollectionViewSource playerViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("playerViewSource")));
            MainWindow.context.Players.Load();
            playerViewSource.Source = MainWindow.context.Players.Local;
        }

        private void Exit_Window(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Add_Player(object sender, RoutedEventArgs e)
        {
            String playerName = PlayerName.Text.Trim();
            // select tournament from database
            var t = (from tournament in MainWindow.context.Tournaments
                     where tournament.ID == SelectedTournament.ID
                     select tournament).ToList();

            // select player from database
            var p = (from player in MainWindow.context.Players
                     where player.Name == playerName
                     select player).ToList();

            // if both tournament and player exist, add player to list of players on tournament
            if (t.Count > 0 && t.Count > 0)
            {
                //t[0].Players.Add(p[0]);
                MainWindow.context.Tournaments.Find(t[0].ID).Players.Add(p[0]);

                MainWindow.context.SaveChanges();
            }

            this.Close();
        }

        private void Find_Player(object sender, RoutedEventArgs e)
        {
            String playerName = SearchPlayer.Text.Trim();

            var p = (from player in MainWindow.context.Players
                     where player.Name == playerName
                     select player).ToList();

            if (p.Count < 1)
            {
                MessageBox.Show("No player with given name.", "Error");
            }
            else
            {
                PlayerName.Text = p[0].Name;
            }
        }
    }
}

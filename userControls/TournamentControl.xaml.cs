using ChessBase.DAL;
using ChessBase.Models;
using ChessBase.Windows;
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

namespace ChessBase.pages
{
    /// <summary>
    /// Interaction logic for TournamentControl.xaml
    /// </summary>
    public partial class TournamentControl : UserControl
    {
        System.Windows.Data.CollectionViewSource tournamentViewSource;

        public TournamentControl()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            if (!System.ComponentModel.DesignerProperties.GetIsInDesignMode(this))
            {
                //Load your data here and assign the result to the CollectionViewSource.
                tournamentViewSource = (System.Windows.Data.CollectionViewSource)this.Resources["tournamentViewSource"];

                MainWindow.context.Tournaments.Load();
                tournamentViewSource.Source = MainWindow.context.Tournaments.Local;
            }
        }

        private void RefreshTournamentList()
        {
            MainWindow.context.Tournaments.Load();
            tournamentViewSource.Source = MainWindow.context.Tournaments.Local;
        }

        private void Add_Tournament(object sender, RoutedEventArgs e)
        {
            CreateTournamentWindow popup = new CreateTournamentWindow(RefreshTournamentList);
            popup.ShowDialog();
        }

        private void Delete_Tournament(object sender, RoutedEventArgs e)
        {
            // get the selected tournament from list.
            if (tournamentDataGrid.SelectedItem is Tournament selectedTournament)
            {
                // find tournament in database with matching id.
                var t = (from tournament in MainWindow.context.Tournaments
                         where tournament.ID == selectedTournament.ID
                         select tournament).ToList();
                // if there is a match (should very well be) remove it.
                if (t.Count > 0)
                {
                    MainWindow.context.Tournaments.Remove(t[0]);
                    MainWindow.context.SaveChanges();
                }
            }
            tournamentDataGrid.SelectedItem = null;
        }

        private void Add_Player_To_Tournament(object sender, RoutedEventArgs e)
        {
            if (tournamentDataGrid.SelectedItem is Tournament selectedTournament)
            {
                AddPlayerToTournamentWindow popup = new AddPlayerToTournamentWindow();

                // pass selected tournament to new window.
                popup.SelectedTournament = selectedTournament;
                popup.ShowDialog();
            }
        }
    }
}

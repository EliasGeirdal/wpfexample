using ChessBase.DAL;
using ChessBase.Extensions;
using ChessBase.Models;
using ChessBase.Windows;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace ChessBase.userControls
{
    /// <summary>
    /// Interaction logic for PlayerControl.xaml
    /// </summary>
    public partial class PlayerControl : UserControl
    {
        public PlayerControl()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            if (!System.ComponentModel.DesignerProperties.GetIsInDesignMode(this))
            {
                System.Windows.Data.CollectionViewSource playerViewSource = (System.Windows.Data.CollectionViewSource)this.Resources["playerViewSource"];

                MainWindow.context.Players.Load();
                playerViewSource.Source = MainWindow.context.Players.Local;

                System.Windows.Data.CollectionViewSource tournamentViewSource = (System.Windows.Data.CollectionViewSource)this.Resources["tournamentViewSource"];
                MainWindow.context.Tournaments.Load();
                tournamentViewSource.Source = MainWindow.context.Tournaments.Local;
            }
        }

        private void RefreshPlayerList()
        {
            System.Windows.Data.CollectionViewSource playerViewSource = (System.Windows.Data.CollectionViewSource)this.Resources["playerViewSource"];

            MainWindow.context.Players.Load();
            playerViewSource.Source = MainWindow.context.Players.Local;
        }

        private void Add_Player(object sender, RoutedEventArgs e)
        {
            CreatePlayerWindow popup = new CreatePlayerWindow(RefreshPlayerList);
            popup.ShowDialog();
        }

        private void Delete_Player(object sender, RoutedEventArgs e)
        {
            // get the selected player from list.
            if (playerDataGrid.SelectedItem is Player selectedPlayer)
            {
                // only delete it if a player has been selected. Otherwise ignore.
                // find player in database with matching id.
                var p = (from player in MainWindow.context.Players
                         where player.ID == selectedPlayer.ID
                         select player).ToList();
                // if there is a match (should very well be) remove it.
                if (p.Count > 0)
                {
                    MainWindow.context.Players.Remove(p[0]);
                    MainWindow.context.SaveChanges();
                }
            }
            // unselect auto selected item.
            playerDataGrid.SelectedItem = null;
        }

        private void Filter(object sender, RoutedEventArgs e)
        {
            // check for errors
            if (errorCheck())
            {
                // assign valuables from text elements for readability.
                int rating = int.Parse(RatingFilter.Text.Trim());
                int age = int.Parse(AgeFilter.Text.Trim());
                String country = CountryFilter.Text.Trim();

                // calculate birth year from age. Implemented as an extension function.
                int birthyear = age.toBirthyear();

                // create query, but delay execution.
                var query = from player in MainWindow.context.Players
                            where player.BirthYear <= birthyear
                            && player.Rating >= rating
                            select player;

                // if country has been specified, add it to the query.
                if (country != "")
                {
                    query = query.Where(p => p.Country.Equals(country));
                }

                // filter players by which tournaments they play in, if it is specified by the checkbox.
                if ((bool)checkBoxTournament.IsChecked)
                {
                    if (tournamentComboBox.SelectedItem is Tournament selectedTournament)
                    {
                        query = query.Where(p => p.Tournaments.Any(t => t.ID == selectedTournament.ID));
                    }
                }

                // now execute the query and update listview.
                var playerList = query.ToList();

                resultPlayerList.ItemsSource = playerList;
            }
        }

        private bool errorCheck()
        {
            // if the input field is empty, return to default: 0
            if (RatingFilter.Text.isEmpty())
            {
                RatingFilter.Text = "0";
            }
            // if input field is empty, return to default: 0
            if (AgeFilter.Text.isEmpty())
            {
                AgeFilter.Text = "0";
            }

            // if it isnt empty check if the input is an integer.
            string strRegex = @"(^[0-9]+$)";
            Regex re = new Regex(strRegex);

            if (!re.IsMatch(RatingFilter.Text))
            {
                MessageBox.Show("Rating must be an integer.", "Error");
                return false;
            }
            if (!re.IsMatch(AgeFilter.Text))
            {
                MessageBox.Show("Age must be an integer.", "Error");
                return false;
            }
            return true;
        }

    }
}

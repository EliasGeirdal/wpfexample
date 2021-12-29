using ChessBase.DAL;
using ChessBase.Extensions;
using ChessBase.Models;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for CreatePlayerWindow.xaml
    /// </summary>
    public partial class CreatePlayerWindow : Window
    {
        private readonly RefreshListDelegate refresh;
        public CreatePlayerWindow(RefreshListDelegate refresh)
        {
            InitializeComponent();
            this.refresh = refresh;
        }

        private void Create_Player(object sender, RoutedEventArgs e)
        {
            // error check
            if (errorCheck())
            {
                // implement logic
                string name = CreatePlayerName.Text.Trim();
                string rating = CreatePlayerRating.Text.Trim();
                string country = CreatePlayerCountry.Text.Trim();
                string birthyear = CreatePlayerBirthyear.Text.Trim();

                // construct player object
                Player player = new Player(name, int.Parse(rating), country, int.Parse(birthyear));
                MainWindow.context.Players.Add(player);

                MainWindow.context.SaveChanges();

                // refresh list of players to include this.
                refresh();

                this.Close();
            }
        }

        private bool errorCheck()
        {
            if (CreatePlayerName.Text.isEmpty() || CreatePlayerRating.Text.isEmpty() || CreatePlayerCountry.Text.isEmpty() || CreatePlayerBirthyear.Text.isEmpty())
            {
                MessageBox.Show("Empty fields not allowed.", "Error");
                return false;
            }
            return true;
        }

        private void Exit_Window(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

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
    /// Interaction logic for CreateTournamentWindow.xaml
    /// </summary>
    public partial class CreateTournamentWindow : Window
    {
        private readonly RefreshListDelegate refresh;

        public CreateTournamentWindow(RefreshListDelegate refresh)
        {
            InitializeComponent();
            this.refresh = refresh;
        }

        private void Create_Tournament(object sender, RoutedEventArgs e)
        {
            // error check
            if (errorCheck())
            {
                // implement logic
                String name = CreateTournamentName.Text.Trim();
                String location = CreateTournamentLocation.Text.Trim();
                DateTime start = (DateTime)CreateTournamentStateDate.SelectedDate;
                DateTime end = (DateTime)CreateTournamentEndDate.SelectedDate;

                // construct tournament object
                Tournament tournament = new Tournament(name, location, start, end);
                MainWindow.context.Tournaments.Add(tournament);

                MainWindow.context.SaveChanges();

                // refresh list of tournaments to include this.
                refresh();

                this.Close();
            }
        }

        private bool errorCheck()
        {
            if (CreateTournamentName.Text.isEmpty() || CreateTournamentLocation.Text.isEmpty() || CreateTournamentStateDate.SelectedDate == null || CreateTournamentEndDate.SelectedDate == null)
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

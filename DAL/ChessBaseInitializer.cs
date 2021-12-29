using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChessBase.Models;

namespace ChessBase.DAL
{
    public class ChessBaseInitializer :
    DropCreateDatabaseAlways<ChessBaseContext>
    //CreateDatabaseIfNotExists<ChessBaseContext>
    {
        protected override void Seed(ChessBaseContext context)
        {
            // Players
            List<Player> players = new List<Player>();
            players.Add(new Player("Magnus Carlsen", 2855, "NOR", 1990));
            players.Add(new Player("Fabiano Caruana", 2800, "USA", 1992));
            players.Add(new Player("Ding liren", 2799, "CHN", 1992));
            players.Add(new Player("Ian Nepomniachtchi", 2792, "RUS", 1990));
            players.Add(new Player("Levon Aronian", 2782, "ARM", 1982));
            players.Add(new Player("Wesley So", 2778, "USA", 1993));
            players.Add(new Player("Anish Giri", 2777, "NED", 1994));
            players.Add(new Player("Alexander Grischuk", 2775, "RUS", 1983));
            players.Add(new Player("Maxime Vachier-Lagrave", 2763, "FRA", 1990));
            players.Add(new Player("Teimour Radjabov", 2763, "AZE", 1987));

            players.ForEach(player => context.Players.Add(player));

            List<Tournament> tournies = new List<Tournament>();

            // tournaments
            Tournament worldCup = new Tournament("Chess World Cup 2019", "Khanty-Mansiysk, Russia", new DateTime(2019, 9, 9), new DateTime(2019, 10, 4));
            worldCup.Players.Add(players.ElementAt(1)); // Ding
            worldCup.Players.Add(players.ElementAt(3)); // Nepo
            worldCup.Players.Add(players.ElementAt(4)); // Levon
            worldCup.Players.Add(players.ElementAt(5)); // Wesly
            worldCup.Players.Add(players.ElementAt(6)); // Anish
            worldCup.Players.Add(players.ElementAt(7)); // Alexander
            worldCup.Players.Add(players.ElementAt(8)); // Maxime
            worldCup.Players.Add(players.ElementAt(9)); // Teimour
            tournies.Add(worldCup);

            Tournament cand = new Tournament("Candidates Tournament 2020", "Yekaterinburg, Russia", new DateTime(2020, 3, 15), new DateTime(2020, 4, 27));
            cand.Players.Add(players.ElementAt(1)); // fab
            cand.Players.Add(players.ElementAt(2)); // ding
            cand.Players.Add(players.ElementAt(3)); // nepo
            cand.Players.Add(players.ElementAt(3)); // nepo
            cand.Players.Add(players.ElementAt(4)); // levon
            cand.Players.Add(players.ElementAt(5)); // wesley
            cand.Players.Add(players.ElementAt(6)); // anish
            cand.Players.Add(players.ElementAt(7)); // alexander
            cand.Players.Add(players.ElementAt(8)); // Lagrave
            tournies.Add(cand);

            Tournament champ = new Tournament("World Chess Championship 2021", "Dubai, United Arab Emirates", new DateTime(2021, 11, 24), new DateTime(2021, 12, 16));
            champ.Players.Add(players.ElementAt(0)); // carlsen
            champ.Players.Add(players.ElementAt(3)); // nepo
            tournies.Add(champ);

            tournies.ForEach(tourn => context.Tournaments.Add(tourn));

            context.SaveChanges();

            // employees
            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee("Sam Height", 150));
            employees.Add(new Employee("Henreth the fourth", 155));

            employees.ForEach(emp => context.Employees.Add(emp));

            context.SaveChanges();
        }
    }
}

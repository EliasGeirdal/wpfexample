using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessBase.Models
{
    public class Player
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Rating { get; set; }
        public string Country { get; set; }
        public int BirthYear { get; set; }
        public virtual ObservableCollection<Tournament> Tournaments { get; set; }
        public Player() { }

        public Player(string name, int rating, string country, int birthYear)
        {
            Name = name;
            Rating = rating;
            Country = country;
            BirthYear = birthYear;
            Tournaments = new ObservableCollection<Tournament>();
        }

        public override string ToString()
        {
            return $"{Name}, Rating: {Rating}, {BirthYear}, {Country}";
        }
    }
}

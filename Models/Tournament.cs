using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessBase.Models
{
    public class Tournament
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }

        // association
        public virtual ObservableCollection<Player> Players { get; set; }

        public Tournament() { }
        public Tournament(string name, string location, DateTime start, DateTime end)
        {
            Name = name;
            Location = location;
            Start = start;
            End = end;
            Players = new ObservableCollection<Player>();
        }
    }
}

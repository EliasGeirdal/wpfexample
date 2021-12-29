using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using ChessBase.Models;

namespace ChessBase.DAL
{
    public class ChessBaseContext : DbContext
    {
        public ChessBaseContext() : base("ChessBaseContext")
        {
        }
        public DbSet<Player> Players { get; set; }
        public DbSet<Tournament> Tournaments { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }
}

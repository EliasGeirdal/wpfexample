using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessBase.Extensions
{
    public static class intExtension
    {
        /// <summary>
        /// Simple method to calculate birthyear from age.
        /// </summary>
        public static int toBirthyear(this int age)
        {
            return DateTime.Today.Year - age;
        }
    }
}

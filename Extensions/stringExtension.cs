using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessBase.Extensions
{
    public static class stringExtension
    {
        /// <summary>
        /// Check if string is empty.
        /// </summary>
        public static bool isEmpty(this string content)
        {
            return content.Equals("");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MethodEg
{
     class Movie
    {
        string moviename;
        internal Movie(string moviename)
        {
            this.moviename = moviename;
        }
    }
    class Theater : Movie
    {
        string theatername;
        internal Theater(string moviename, string theatername):base(moviename)
        {
            this.theatername = theatername;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}

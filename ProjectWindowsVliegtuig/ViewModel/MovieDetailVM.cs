using ProjectWindowsVliegtuig.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectWindowsVliegtuig.ViewModel
{
    public class MovieDetailVM
    {
        public Movie Movie { get; set; }

        public MovieDetailVM(Movie m)
        {
            Movie = m;
        }

    }
}

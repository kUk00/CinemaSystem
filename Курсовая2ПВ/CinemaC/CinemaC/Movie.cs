using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaC
{
    internal class Movie
    {
        public string NameMovie { get; set; }
        public string Country { get; set; }
        public int YearOfIssue { get; set; }
        public string Genre { get; set; }
        public int Duration { get; set; }

        public Movie(string namemovie, string country, int yearofissue, string genre, int duration)
        {
            this.NameMovie = namemovie;
            this.Country = country;
            this.YearOfIssue = yearofissue;
            this.Genre = genre;
            this.Duration = duration;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaC
{
    internal class Ticket
    {
        public DateTime Date { get; set; }
        public TimeSpan Time { get; set; }
        public int Hall { get; set; }
        public int Row { get; set; }
        public int Place { get; set; }
        public bool Sold { get; set; }

        public Ticket(DateTime date, TimeSpan time, int hall, int row, int place, bool sold)
        {
            this.Date = date;
            this.Time = time;
            this.Hall = hall;
            this.Row = row;
            this.Place = place;
            this.Sold = sold;
        }
    }
}

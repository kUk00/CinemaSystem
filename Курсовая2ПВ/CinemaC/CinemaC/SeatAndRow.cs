using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaC
{
    internal class SeatAndRow
    {
        public int Hall { get; set; }
        public int Row { get; set; }
        public int Place { get; set; }
        public int Category { get; set; }

        public SeatAndRow(int hall, int row, int place, int category)
        {
            this.Hall = hall;
            this.Row = row;
            this.Place = place;
            this.Category = category;
        }
    }
}

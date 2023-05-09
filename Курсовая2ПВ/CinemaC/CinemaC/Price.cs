using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaC
{
    internal class Price
    {
        public DateTime Date { get; set; }
        public TimeSpan Time { get; set; }
        public int Category { get; set; }
        public decimal Money { get; set; }

        public Price(DateTime date, TimeSpan time, int category, decimal money)
        {
            this.Date = date;
            this.Time = time;
            this.Category = category;
            this.Money = money;
        }
    }
}

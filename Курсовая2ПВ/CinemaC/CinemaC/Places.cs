using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaC
{
    internal class Places
    {
        public int place { get; set; }
        public bool sold { get; set; }

        public Places(int pl, bool sd)
        {
            this.place = pl;
            this.sold = sd;
        }
    }
}

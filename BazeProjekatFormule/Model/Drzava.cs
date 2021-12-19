using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazeProjekatFormule.Model
{
    class Drzava
    {
        public int idd { get; set; }
        public string nazivd { get; set; }

        public Drzava(int idd, string nazivd)
        {
            this.idd = idd;
            this.nazivd = nazivd;
        }

        public Drzava()
        {

        }
    }
}

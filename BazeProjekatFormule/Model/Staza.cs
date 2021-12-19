using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazeProjekatFormule.Model
{
    class Staza
    {

        public int ids { get; set; }
        public string nazivs { get; set; }
        public int brojkrug { get; set; }
        public int drzs { get; set; }
        
        public Staza(int ids, string nazivs, int brojkrug, int drzs)
        {
            this.ids = ids;
            this.nazivs = nazivs;
            this.brojkrug = brojkrug;
            this.drzs = drzs;
        }

        public Staza()
        {

        }
    }
}

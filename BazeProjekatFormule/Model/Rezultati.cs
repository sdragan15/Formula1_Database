using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazeProjekatFormule.Model
{
    class Rezultati
    {

        public string idr { get; set; }
        public int idv { get; set; }
        public int ids { get; set; }
        public int sezona { get; set;}
        public int plasman { get; set; }
        public int bodovi { get; set; }
        public double maksbrzina { get; set; }

        public Rezultati(string idr, int idv, int ids, int sezona, int plasman, int bodovi, double maksbrzina)
        {
            this.idr = idr;
            this.idv = idv;
            this.ids = ids;
            this.sezona = sezona;
            this.plasman = plasman;
            this.bodovi = bodovi;
            this.maksbrzina = maksbrzina;
        }

        public Rezultati()
        {

        }

        public override string ToString()
        {
            return string.Format("{0,-5} {1,-5} {2,-5} {3,8} {4,10} {5, 10} {6,15}", idr, idv, ids, sezona, plasman, bodovi, maksbrzina);
        }

        public static string GetFormattedHeader()
        {
            return string.Format("{0,-5} {1,-5} {2,-5} {3,8} {4,10} {5, 10} {6,15}", "IDR", "IDV", "IDS", "SEZONA", "PLASMAN", "BODOVI","MAKSBRZINA");
        }
    }
}

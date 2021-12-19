using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazeProjekatFormule.Model
{
    class Vozac
    {
        public int idv { get; set; }
        public string imev { get; set; }
        public string prezv { get; set; }
        public int godrodj { get; set; }
        public int brojtit { get; set; }
        public int drzv { get; set; }

        public Vozac(int idv, string imev, string prezv, int godrodj, int brojtit, int drzv)
        {
            this.idv = idv;
            this.imev = imev;
            this.prezv = prezv;
            this.godrodj = godrodj;
            this.brojtit = brojtit;
            this.drzv = drzv;
        }

        public Vozac()
        {

        }


        public string IspisiVozaceSaDrzavom(string drzava)
        {
            return string.Format("{0,-3} {1,-15}{2,-15}{3,20}{4,15}{5, 20}", idv, imev, prezv, godrodj, brojtit, drzava);
        }

        public override string ToString()
        {
            return string.Format("{0,-3} {1,-15}{2,-15}{3,20}{4,15}{5, 20}", idv, imev, prezv, godrodj, brojtit,drzv);
        }

        public static string GetFormattedHeader()
        {
            return string.Format("{0,-3} {1,-15}{2,-15}{3,20}{4,15}{5, 20}", "ID", "Ime", "Prezime", "Godina Rodjenja", "Broj Titula", "Drzava");
        }

    }
}

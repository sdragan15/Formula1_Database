using BazeProjekatFormule.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazeProjekatFormule.DTO
{
    class VozaciIRezultatiDTO
    {
        public Vozac vozac = new Vozac();
        public List<Rezultati> rezultati = new List<Rezultati>();
        public string drzava;
        public int ukupanBrojRezultata;

        public VozaciIRezultatiDTO(Vozac vozac, List<Rezultati> rezultati, string drzava, int ukupanBrojRezultata)
        {
            this.vozac = vozac;
            this.rezultati = rezultati;
            this.drzava = drzava;
            this.ukupanBrojRezultata = ukupanBrojRezultata;
        }

        public VozaciIRezultatiDTO()
        {

        }
    }
}

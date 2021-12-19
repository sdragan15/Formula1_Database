using BazeProjekatFormule.DAO;
using BazeProjekatFormule.DAO.Implementation;
using BazeProjekatFormule.DTO;
using BazeProjekatFormule.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazeProjekatFormule.Service
{
    class KompleksniUpiti
    {
        private readonly static IVozacDAO vozacDAO = new VozacDAOImpl();
        private readonly static IRezultatiDAO rezultatiDAO = new RezultatiDAOImpl();
        private readonly static IDrzavaDAO drzavaDAO = new DrzavaDAOImpl();

        public List<Vozac> PrikazeSveVozace()
        {
            //vozacDAO.DeleteById(1);
            //vozacDAO.DeleteAll();
            //if (vozacDAO.ExistsById(1)) Console.WriteLine("Postoji");
            /*foreach(Vozac v in vozacDAO.FindAllById(new List<int> { 1,5,7 }))
            {
                Console.WriteLine(v);
            }*/

            /*Vozac voz = new Vozac(3, "Savo", "Lingard", 1975, 2, 4);
            vozacDAO.Save(voz);*/

            List<Vozac> vozaci = new List<Vozac>();
            foreach(Vozac v in vozacDAO.FindAll())
            {
                vozaci.Add(v);
            }

            Console.Write("Broj vozaca: ");
            Console.WriteLine(vozacDAO.Count());

            return vozaci;
        }

        public List<Rezultati> SviRezultatiSaJedneStaze(int idStaze)
        {
            List<Rezultati> rezultati = new List<Rezultati>();
            foreach(Rezultati rez in rezultatiDAO.FindByIDStaze(idStaze))
            {
                rezultati.Add(rez);
            }
            return rezultati;
        }

        public List<VozaciIRezultatiDTO> InfoVozacaIPrvoplasiraniRezultati()
        {
            List<VozaciIRezultatiDTO> info = new List<VozaciIRezultatiDTO>();

            foreach(Vozac vozac in vozacDAO.FindAll())
            {
                VozaciIRezultatiDTO vr = new VozaciIRezultatiDTO();
                vr.vozac = vozac;
                vr.drzava = drzavaDAO.FindById(vozac.drzv).nazivd;
                
                foreach(Rezultati rez in rezultatiDAO.SviRezultatiVozacaSaPlasmanomN(vozac.idv, 1))
                {
                    vr.rezultati.Add(rez);
                }
                vr.ukupanBrojRezultata = rezultatiDAO.CountByIDVozaca(vozac.idv);

                info.Add(vr);
            }

            return info;
        }

        public VozaciIRezultatiDTO IzbrisatiRezultat(string idRez)
        {
            VozaciIRezultatiDTO vr = new VozaciIRezultatiDTO();

            if (rezultatiDAO.ExistsById(idRez))
            {
                vr.rezultati.Add(rezultatiDAO.FindById(idRez));
                vr.vozac = vozacDAO.FindById(vr.rezultati[0].idv);
                if (vr.rezultati[0].plasman == 1)
                {
                    vr.vozac.brojtit--;
                    vozacDAO.Save(vr.vozac);
                }
                else
                {
                    vr.vozac = null;
                }
                rezultatiDAO.DeleteById(vr.rezultati[0].idr);
                return vr;
            }
            else
            {
                return null;
            }
            

            
        }

    }
}

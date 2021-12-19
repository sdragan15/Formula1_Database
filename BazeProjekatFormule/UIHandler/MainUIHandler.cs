using BazeProjekatFormule.DTO;
using BazeProjekatFormule.Model;
using BazeProjekatFormule.Service;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazeProjekatFormule.UIHandler
{
    public class MainUIHandler
    {
        private readonly static KompleksniUpiti kompleksniUpiti = new KompleksniUpiti();

        public void MainUIMenu()
        {
            int unos = 0;
            while (true)
            {
                do
                {
                    Console.Clear();
                    Console.WriteLine("Odaberite neke od opcija:");
                    Console.WriteLine("1. Ispisati sve vozace");
                    Console.WriteLine("2. Rezultati jedne staze");
                    Console.WriteLine("3. Info. o vozacu i rezultati na kojima je bio prvoplasirani");
                    Console.WriteLine("4. Izbrisati rezultat na osnovu id-a (IDR, u formatu \"R01\")");
                    Console.WriteLine("5. Izadji iz programa");
                    try
                    {
                        unos = Int32.Parse(Console.ReadLine());
                    }
                    catch(Exception e)
                    {
                        Console.WriteLine(e.Message);
                        Console.ReadKey();
                        return;
                    }
                    Console.Clear();
                } while (unos < 1 || unos > 5);

                switch (unos)
                {
                    case 1:
                        IspisatiSveVozace();
                        break;
                    case 2:
                        IspisatiRezultateStaze();
                        break;
                    case 3:
                        InfoVozacaIPrvoplasiraniRezultati();
                        break;
                    case 4:
                        IzbrisatiRezultat();
                        break;
                    case 5:
                        return;
                    default:
                        break;
                }
            }
            
        }

        public void IspisatiSveVozace()
        {
            try
            {
                Console.WriteLine(Vozac.GetFormattedHeader());
                Console.WriteLine("##################################################################################");
                foreach (Vozac v in kompleksniUpiti.PrikazeSveVozace())
                {
                    Console.WriteLine(v);
                }
                Console.ReadKey();
            }
            catch(DbException e)
            {
                Console.WriteLine(e.Message);
            }
            
        }

        public void IspisatiRezultateStaze()
        {
            try
            {
                Console.WriteLine("Unesite ID staze:");
                string i = Console.ReadLine();
                int unos;
                Console.WriteLine();
                bool broj = int.TryParse(i, out unos);

                if (broj)
                {
                    List<Rezultati> rezultati = kompleksniUpiti.SviRezultatiSaJedneStaze(unos);

                    double bodovi = 0;
                    double br = 0;
                    Console.WriteLine(Rezultati.GetFormattedHeader());
                    Console.WriteLine("##################################################################");
                    foreach (Rezultati rez in rezultati)
                    {
                        Console.WriteLine(rez);
                        Console.WriteLine("----------------------------------------------------------------------");
                        bodovi += rez.bodovi;
                        br++;
                    }
                    if (br > 0)
                    {
                        Console.Write("Prosecan broj bodova na stazi ");
                        Console.Write(unos);
                        Console.Write(" je: ");
                        Console.WriteLine(bodovi / br);
                    }
                    else
                    {
                        Console.WriteLine("Ne postoje rezultati za stazu " + unos);
                    }
                }
                else
                {
                    Console.WriteLine("Format Id-a je pogresan.");
                }

                Console.ReadKey();

            }
            catch(DbException e)
            {
                Console.WriteLine(e.Message);
            }
            
        }

        public void InfoVozacaIPrvoplasiraniRezultati()
        {
            try
            {
                List<VozaciIRezultatiDTO> result = kompleksniUpiti.InfoVozacaIPrvoplasiraniRezultati();
                int brojPrvoplasiranihRez = 0;

                Console.WriteLine(Vozac.GetFormattedHeader());
                Console.WriteLine("##################################################################################################");
                foreach(VozaciIRezultatiDTO rez in result)
                {
                    Console.WriteLine(rez.vozac.IspisiVozaceSaDrzavom(rez.drzava));

                    if (rez.rezultati.Count().Equals(0))
                    {
                        Console.WriteLine("                Vozac nije bio prvoplasirani.");
                    }
                    else
                    {
                        Console.Write("    1. mesto:   ");
                        Console.WriteLine(Rezultati.GetFormattedHeader());
                        Console.Write("                ");
                        Console.WriteLine("#######################################################################");
                        foreach (Rezultati rezutat in rez.rezultati)
                        {
                            Console.Write("                ");
                            Console.WriteLine(rezutat);
                            brojPrvoplasiranihRez++;
                        }
                    }
                    string broj = (rez.ukupanBrojRezultata - brojPrvoplasiranihRez).ToString();
                    brojPrvoplasiranihRez = 0;
                    Console.WriteLine("Vozac je " + broj + " puta ucestvovao a da nije bio prvi.");
                    Console.WriteLine("\n-------------------------------------------------------------------------------------------");

                }
                Console.ReadKey();
            }
            catch(DbException e)
            {
                Console.WriteLine(e.Message);
            }
        }


        public void IzbrisatiRezultat()
        {
            Console.Write("Unesite id rezultata koji zelite obrisati: ");
            string unos = Console.ReadLine();
            Console.Clear();
            try
            {
                VozaciIRezultatiDTO vr = kompleksniUpiti.IzbrisatiRezultat(unos);
                if (vr != null)
                {
                    Console.WriteLine("Izbrisan je rezultat:");
                    Console.WriteLine(Rezultati.GetFormattedHeader());
                    Console.WriteLine(vr.rezultati[0]);
                    Console.WriteLine();
                    if (vr.vozac != null)
                    {
                        Console.WriteLine("Vozacu je smanjen broj titula:");
                        Console.WriteLine(Vozac.GetFormattedHeader());
                        Console.WriteLine(vr.vozac);
                    }

                }
                else
                {
                    Console.WriteLine("Rezultat sa id-om " + unos + " ne postoji");
                }
                Console.ReadKey();
            }
            catch(DbException e)
            {
                Console.WriteLine(e.Message);
            }
        }


    }
}

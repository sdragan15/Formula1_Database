using BazeProjekatFormule.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazeProjekatFormule.DAO
{
    interface IRezultatiDAO : ICRUDDAO<Rezultati, string>
    {
        List<Rezultati> FindByIDStaze(int id);

        List<Rezultati> SviRezultatiVozacaSaPlasmanomN(int idVozac, int plasman);
        int CountByIDVozaca(int idv);
    }
}

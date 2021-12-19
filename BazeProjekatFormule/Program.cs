using BazeProjekatFormule.UIHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazeProjekatFormule
{
    class Program
    {
        private readonly static MainUIHandler mainUIHandler = new MainUIHandler();

        static void Main(string[] args)
        {
            mainUIHandler.MainUIMenu();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eletjatek
{
    class Program
    {
        static void Main(string[] args)
        {
            EletjatekSzimulator szimulator = new EletjatekSzimulator(25, 25);
            while (!Console.KeyAvailable)
            {
                szimulator.Run();
            }
            Console.ReadKey();
        }
    }
}

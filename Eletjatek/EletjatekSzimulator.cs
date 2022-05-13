using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Text;
using System.Threading.Tasks;

namespace Eletjatek
{
    class EletjatekSzimulator
    {
        private int[,] Matrix { get; set; }
        private int OszlopokSzama { get; set; }
        private int SorokSzama { get; set; }
        public EletjatekSzimulator(int oszlopok, int sorok)
        {
            OszlopokSzama = oszlopok+2;
            SorokSzama = sorok+2;
            Matrix = new int[SorokSzama, OszlopokSzama];
            Matrix = FillMatrix();
        }


        private int[,] FillMatrix()
        {
            int[,] tomb = Matrix;
            Random randomizer = new Random();
            for (int i = 0; i < SorokSzama; i++)
            {
                for (int g = 0; g < OszlopokSzama; g++)
                {
                    if (i == 0 || g == 0 || i == SorokSzama-1 || g == OszlopokSzama-1) 
                        tomb[i, g] = 0;
                    else
                        tomb[i, g] = randomizer.Next(0, 2);
                }
            }
            return tomb;
        }
        private void KovetkezoAllapot()
        {
            int[,] tomb = Matrix;
            for (int i = 1; i < SorokSzama-1; i++)
            {
                for (int g = 1; g < OszlopokSzama-1; g++)
                {
                    tomb[i, g] = CheckFor(g, i, Matrix);
                }
            }
        }
        private int CheckFor(int o, int s,int[,] t)
        {
            int cells = 0;
            for (int i = -1; i <=1; i++)
            {
                for (int g =-1; g <=1; g++)
                {
                    if (t[s+i, o+g] == 1) cells++;
                }
            }
            if (t[s, o] == 0)
                return cells == 3 ? 1 : 0;
            cells--;
            return (cells < 4 && cells > 1) ? 1 : 0;
        }
        private void Megjelenit()
        {
            for (int i = 0; i < SorokSzama; i++)
            {
                for (int g = 0; g < OszlopokSzama; g++)
                {
                    if (g == 0 || i == 0 || i == SorokSzama - 1 || g == OszlopokSzama - 1)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.Write("X");
                        Console.ResetColor();
                    }
                    else if (Matrix[i, g] == 1)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.BackgroundColor = ConsoleColor.Yellow;
                        Console.Write("S");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }
        }
        public void Run()
        {
            KovetkezoAllapot();
            Console.Clear();
            Megjelenit();
            Thread.Sleep(500);
        }
    }
}

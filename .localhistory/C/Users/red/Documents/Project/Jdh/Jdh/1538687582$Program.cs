using System;
using System.Diagnostics;
using Corale.Colore.Core;
using Corale.Colore.Razer.Keyboard;
using ColoreColor = Corale.Colore.Core.Color;

namespace Jdh
{
    class Program
    {


        Corale.Colore.Razer.Keyboard.Key [] j = { Key.A, Key.Z, Key.E, Key.S, Key.W , Key.A};

        static void Main(string[] args)
        {
            Chroma.Instance.SetAll(ColoreColor.Blue);
            Chroma.Instance.Keyboard.SetKey(Key.F1, ColoreColor.White);


            float cpuload;
            float ramusage;
            int cpu;
            int ram;
            int gpu;


            while (true)
            {



                //On attends 500ms
                System.Threading.Thread.Sleep(500);

            }
        }
    }
}

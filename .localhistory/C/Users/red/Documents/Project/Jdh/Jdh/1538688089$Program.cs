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

            System.Diagnostics.Debug.WriteLine(Chroma.Instance.Initialized);
            Chroma.Instance.SetAll(ColoreColor.Blue);
        

            Chroma.Instance.Keyboard.SetKey(Key.F1, ColoreColor.White);

            // Create the custom Grid
            var customGrid = MousepadCustom.Create();
            // Set LED 0 (top right) and LED 14 (top left) to red
            customGrid[0] = ColoreColor.Red;
            customGrid[14] = ColoreColor.Red;
            // Apply the Grid to the Keyboard
            Chroma.Instance.Mousepad.SetCustom(customGrid);

            while (true)
            {


                //On attends 500ms
                System.Threading.Thread.Sleep(500);

            }
        }
    }
}

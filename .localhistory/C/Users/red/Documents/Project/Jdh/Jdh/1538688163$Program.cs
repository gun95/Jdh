using System;
using System.Diagnostics;
using Corale.Colore.Core;
using Corale.Colore.Razer.Keyboard;
using ColoreColor = Corale.Colore.Core.Color;
using MousepadCustom = Corale.Colore.Razer.Mousepad.Effects.Custom;
using KeyboardCustom = Corale.Colore.Razer.Keyboard.Effects.Custom;
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

         // Create a custom for the Keyboard
            var keyboardGrid = KeyboardCustom.Create();
            // Set the whole Grid to Green
            keyboardGrid.Set(ColoreColor.Green);
            // Set the A Key to Red
            keyboardGrid[Key.A] = ColoreColor.Red;
            // Set the Key in the second row and the fifth column to Red
            keyboardGrid[1, 4] = ColoreColor.Red;
            // Apply the grid to the Keyboard
            Chroma.Instance.Keyboard.SetCustom(keyboardGrid);

            while (true)
            {


                //On attends 500ms
                System.Threading.Thread.Sleep(500);

            }
        }
    }
}

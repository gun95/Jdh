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


       static Corale.Colore.Razer.Keyboard.Key [] KeyJ = { Key.A, Key.Z, Key.E, Key.S, Key.W , Key.A};
       static Corale.Colore.Razer.Keyboard.Key[] KeyD = { Key.T, Key.Y, Key.U, Key.G, Key.J, Key.V, Key.B, Key.N};
        static Corale.Colore.Razer.Keyboard.Key[] KeyH = { Key.O, Key.L, Key.M};

        static KeyboardCustom keyboardGrid = KeyboardCustom.Create();
        static void MakeJ()
        {
            // Create a custom for the Keyboard
           
            // Set the A Key to Red
            int i = 0;
            while (i < KeyJ.Length)
            {
                keyboardGrid[KeyJ[i]] = ColoreColor.Red;
                i++;
            }
            keyboardGrid[4, 2] = ColoreColor.Red;
        }

        static void MakeD()
        {
            // Create a custom for the Keyboard
            // Set the A Key to Red
            int i = 0;
            while (i < KeyD.Length)
            {
                keyboardGrid[KeyD[i]] = ColoreColor.Blue;
                i++;
            }
        }

        static void MakeH()
        {
            // Create a custom for the Keyboard
            // Set the A Key to Red
            int i = 0;
            while (i < KeyH.Length)
            {
                keyboardGrid[KeyH[i]] = ColoreColor.Green;
                i++;
            }
            keyboardGrid[2, 12] = ColoreColor.Green;
            keyboardGrid[3, 12] = ColoreColor.Green;
            keyboardGrid[4, 10] = ColoreColor.Green;
            keyboardGrid[4, 12] = ColoreColor.Green;


        }

        static void PrintJDH()
        {
            MakeJ();
            MakeD();
            MakeH();
            Chroma.Instance.Keyboard.SetCustom(keyboardGrid);
        }

        static void Wave(Key keyUp, Key keyDown)
        {
            if (keyUp != Key.Invalid)
                Chroma.Instance.Keyboard.SetKey(keyUp, ColoreColor.Red);

            if (keyDown != Key.Invalid)
                Chroma.Instance.Keyboard.SetKey(keyDown, ColoreColor.Black);

            System.Threading.Thread.Sleep(100);
        }

            static void Wave(int rowKeyUp, int columnKeyUp, int rowKeyDown, int ColumKeyDown)
        {
           

            System.Threading.Thread.Sleep(100);
        }
        static void Main(string[] args)
        {

            System.Diagnostics.Debug.WriteLine(Chroma.Instance.Initialized);
          

            while (true)
            {
                PrintJDH();
                System.Threading.Thread.Sleep(500);

               /* Wave(Key.A, Key.Invalid);
                Wave(Key.Z, Key.Invalid);
                Wave(Key.E, Key.Invalid);
                Wave(Key.R, Key.A);
                Wave(Key.Invalid, Key.Z);
                Wave(Key.Invalid, Key.E);
                Wave(Key.Invalid, Key.R);
                */
                //On attends 500ms
                System.Threading.Thread.Sleep(500);
                
            }


       }
   

    }
}

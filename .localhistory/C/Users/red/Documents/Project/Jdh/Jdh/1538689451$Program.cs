﻿using System;
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
        static Corale.Colore.Razer.Keyboard.Key[] KeyD = { Key.A, Key.Z, Key.E, Key.S, Key.W, Key.A };


        static void MakeJ()
        {
            // Create a custom for the Keyboard
            var keyboardGrid = KeyboardCustom.Create();
            // Set the A Key to Red
            int i = 0;
            while (i < j.Length)
            {
                keyboardGrid[j[i]] = ColoreColor.Red;
                i++;
            }
            keyboardGrid[4, 2] = ColoreColor.Red;
            // Set the Key in the second row and the fifth column to Red
            Chroma.Instance.Keyboard.SetCustom(keyboardGrid);
        }

        static void MakeD()
        {

        }

        static void Main(string[] args)
        {

            System.Diagnostics.Debug.WriteLine(Chroma.Instance.Initialized);
            Chroma.Instance.SetAll(ColoreColor.Blue);
        

            Chroma.Instance.Keyboard.SetKey(Key.F1, ColoreColor.White);


            while (true)
            {

                MakeJ();

                //On attends 500ms
                System.Threading.Thread.Sleep(500);
                
            }


       }
   

    }
}

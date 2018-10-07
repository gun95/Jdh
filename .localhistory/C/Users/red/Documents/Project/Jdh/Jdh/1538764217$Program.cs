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


        static Corale.Colore.Razer.Keyboard.Key[] KeyJ = { Key.A, Key.Z, Key.E, Key.S, Key.W, Key.A };
        static Corale.Colore.Razer.Keyboard.Key[] KeyD = { Key.T, Key.Y, Key.U, Key.G, Key.J, Key.V, Key.B, Key.N };
        static Corale.Colore.Razer.Keyboard.Key[] KeyH = { Key.O, Key.L };

        static KeyboardCustom keyboardGrid = KeyboardCustom.Create();
        static void MakeJ(ColoreColor color)
        {
            // Create a custom for the Keyboard

            // Set the A Key to Red
            int i = 0;
            while (i < KeyJ.Length)
            {
                keyboardGrid[KeyJ[i]] = color;
                i++;
            }
            keyboardGrid[4, 2] = color;
        }

        static void MakeD(ColoreColor color)
        {
            // Create a custom for the Keyboard
            // Set the A Key to Red
            int i = 0;
            while (i < KeyD.Length)
            {
                keyboardGrid[KeyD[i]] = color;
                i++;
            }
        }

        static void MakeH(ColoreColor color)
        {
            // Create a custom for the Keyboard
            // Set the A Key to Red
            int i = 0;
            while (i < KeyH.Length)
            {
                keyboardGrid[KeyH[i]] = color;
                i++;
            }
            keyboardGrid[2, 12] = color;
            keyboardGrid[3, 12] = color;
            keyboardGrid[3, 11] = color;

            keyboardGrid[4, 10] = color;
            keyboardGrid[4, 12] = color;

        }

        static void PrintJDH()
        {
            // Chroma.Instance.SetAll(ColoreColor.HotPink);

            MakeJ(ColoreColor.Red);
            MakeD(ColoreColor.Black);
            MakeH(ColoreColor.Green);
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

        static void Wave(int rowKeyUp, int columKeyUp, int rowKeyDown, int ColumKeyDown)
        {
            if (rowKeyUp != -1 && rowKeyUp != -1)
                Chroma.Instance.Keyboard.SetPosition(rowKeyUp, rowKeyUp, ColoreColor.Red);

            if (rowKeyDown != -1 && ColumKeyDown != -1)
                Chroma.Instance.Keyboard.SetPosition(rowKeyDown, ColumKeyDown, ColoreColor.Red);
            System.Threading.Thread.Sleep(100);
        }

        static void WaveJdh()
        {
            MakeJ(ColoreColor.Red);
            Chroma.Instance.Keyboard.SetCustom(keyboardGrid);
            System.Threading.Thread.Sleep(500);

            MakeD(ColoreColor.Blue);
            Chroma.Instance.Keyboard.SetCustom(keyboardGrid);
            System.Threading.Thread.Sleep(500);

            MakeH(ColoreColor.Green);
            Chroma.Instance.Keyboard.SetCustom(keyboardGrid);
            System.Threading.Thread.Sleep(500);


            MakeJ(ColoreColor.Black);
            Chroma.Instance.Keyboard.SetCustom(keyboardGrid);
            System.Threading.Thread.Sleep(500);

            MakeD(ColoreColor.Black);
            Chroma.Instance.Keyboard.SetCustom(keyboardGrid);
            System.Threading.Thread.Sleep(500);

            MakeH(ColoreColor.Black);
            Chroma.Instance.Keyboard.SetCustom(keyboardGrid);
            System.Threading.Thread.Sleep(500);
        }

        static void MakeWave(int rowStartWave, int columStartWave)
        {
               Wave(rowStartWave, columStartWave, -1, -1);
               Wave(Key.Z, Key.Invalid);
               Wave(Key.E, Key.Invalid);
               Wave(Key.R, Key.A);
               Wave(Key.Invalid, Key.Z);
               Wave(Key.Invalid, Key.E);
               Wave(Key.Invalid, Key.R);
      }

      static void Main(string[] args)
      {

          System.Diagnostics.Debug.WriteLine(Chroma.Instance.Initialized);
          System.Threading.Thread.Sleep(1000);


          while (true)
          {
              Random rnd = new Random();
              int rowStartWave = rnd.Next(0, 4); // creates a number between 0 and 5
              int columStartWave = rnd.Next(0, 21); // creates a number between 1 and 12

              if (columStartWave < 18)
              {
                  MakeWave(rowStartWave, columStartWave);
              }


              // PrintJDH();
              //System.Threading.Thread.Sleep(500);

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

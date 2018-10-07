using System;
using System.Diagnostics;
using Corale.Colore.Core;
using Corale.Colore.Razer.Keyboard;
using ColoreColor = Corale.Colore.Core.Color;
using MousepadCustom = Corale.Colore.Razer.Mousepad.Effects.Custom;
using KeyboardCustom = Corale.Colore.Razer.Keyboard.Effects.Custom;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using Corale.Colore.Razer.Keyboard.Effects;

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
            if (rowKeyUp != -1 && columKeyUp != -1 && Chroma.Instance.Keyboard[rowKeyUp, columKeyUp] == ColoreColor.Black)
                Chroma.Instance.Keyboard.SetPosition(rowKeyUp, columKeyUp, ColoreColor.Red);

            if (rowKeyDown != -1 && ColumKeyDown != -1 && Chroma.Instance.Keyboard[rowKeyDown, ColumKeyDown] == ColoreColor.Red)
                Chroma.Instance.Keyboard.SetPosition(rowKeyDown, ColumKeyDown, ColoreColor.Black);
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
            Wave(rowStartWave, columStartWave + 1, -1, -1);
            Wave(rowStartWave, columStartWave + 2, -1, -1);

            Wave(rowStartWave, columStartWave + 3, rowStartWave, columStartWave);

            Wave(-1, -1, rowStartWave, columStartWave + 1);
            Wave(-1, -1, rowStartWave, columStartWave + 2);
            Wave(-1, -1, rowStartWave, columStartWave + 3);

        }

        static void ThreadWave()
        {
            while (true)
            {
                MakeWave(4, 4);
            }
            /* Random rnd = new Random();
             int rowStartWave = rnd.Next(0, 4); // creates a number between 0 and 5
             int columStartWave = rnd.Next(0, 21); // creates a number between 1 and 12



             while (true)
             {
                 rowStartWave = rnd.Next(0, 4);
                 columStartWave = rnd.Next(0, 21);
                 System.Diagnostics.Debug.WriteLine("row : " + rowStartWave + " col : " + columStartWave);
                 if (columStartWave < 17 && Chroma.Instance.Keyboard[rowStartWave,columStartWave] == Color.Black)
                     MakeWave(rowStartWave, columStartWave);
                 System.Threading.Thread.Sleep(1000);

             }*/

        }


        static void Main(string[] args)
        {

            System.Diagnostics.Debug.WriteLine(Chroma.Instance.Initialized);
            System.Threading.Thread.Sleep(1000);


            Semaphore semaphoreObject = new Semaphore(initialCount: 1, maximumCount: 1, name: "PrinterApp");
            Printer printerObject = new Printer();
            List<int> array = new List<int>();

            int i = 0;

            Task.Factory.StartNew(() =>
                {
                    int k = 0;
                    while (k < 10)
                    {
                        int tmp = i;
                        int y = 0;
                        semaphoreObject.WaitOne();

                        while (y < array.Count)
                        {
                            if (tmp == array[y])
                            {
                                System.Diagnostics.Debug.WriteLine("find1 : " + tmp);
                                System.Threading.Thread.Sleep(500);
                                y = 0;
                            }
                            y++;
                        }
                        System.Diagnostics.Debug.WriteLine("add1 : " + tmp);
                        array.Add(tmp);
                        semaphoreObject.Release();

                        System.Threading.Thread.Sleep(2000);

                        semaphoreObject.WaitOne();

                        System.Diagnostics.Debug.WriteLine("remove1 : " + tmp);

                        array.Remove(tmp);
                        semaphoreObject.Release();
                    }

                });
            System.Threading.Thread.Sleep(100);

            Task.Factory.StartNew(() =>
            {
                int k = 0;
                while (k < 10)
                {


                    int tmp = i;
                    int y = 0;
                    semaphoreObject.WaitOne();

                    while (y < array.Count)
                    {
                        if (tmp == array[y])
                        {
                            System.Diagnostics.Debug.WriteLine("find : " + tmp);
                            System.Threading.Thread.Sleep(500);
                            y = 0;
                        }
                        y++;
                    }
                    System.Diagnostics.Debug.WriteLine("add : " + tmp);
                    array.Add(tmp);
                    semaphoreObject.Release();

                    System.Threading.Thread.Sleep(2000);
                    semaphoreObject.WaitOne();
                    System.Diagnostics.Debug.WriteLine("remove : " + tmp);

                    array.Remove(tmp);
                    semaphoreObject.Release();
                }
            });

           Random rnd = new Random();
            while (true)
            {
                i = rnd.Next(0, 4);
                System.Threading.Thread.Sleep(2000);


            }
            Console.ReadLine();




          /* System.Threading.Thread myThread;
           myThread = new System.Threading.Thread(new System.Threading.ThreadStart(ThreadWave));
           myThread.Start();

        //   System.Threading.Thread.Sleep(200);
           myThread = new System.Threading.Thread(new System.Threading.ThreadStart(ThreadWave));
           myThread.Start();*/


            /* while (true)
             {



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
            /* System.Threading.Thread.Sleep(500);

         }*/

        }
    }
    class Printer
    {
        public void Print(int documentToPrint)
        {
            Console.WriteLine("Printing document: " + documentToPrint);
            //code to print document
            Thread.Sleep(TimeSpan.FromSeconds(5));
        }
    }
}

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
using System.Runtime.InteropServices;
using System.IO;
using static System.Net.Mime.MediaTypeNames;

namespace Jdh
{
    class Program
    {


        static Corale.Colore.Razer.Keyboard.Key[] KeyJ = { Key.A, Key.Z, Key.E, Key.S, Key.W, Key.A };
        static Corale.Colore.Razer.Keyboard.Key[] KeyD = { Key.T, Key.Y, Key.U, Key.G, Key.J, Key.V, Key.B, Key.N };
        static Corale.Colore.Razer.Keyboard.Key[] KeyH = { Key.O, Key.L };

        static KeyboardCustom keyboardGrid = KeyboardCustom.Create();

        // Create a custom for the Keyboard
        // Set the A Key to color
        static void MakeJ(ColoreColor color)
        {
            int i = 0;
            while (i < KeyJ.Length)
            {
                keyboardGrid[KeyJ[i]] = color;
                i++;
            }
            keyboardGrid[4, 2] = color;
        }

        // Create a custom for the Keyboard
        // Set the D to color
        static void MakeD(ColoreColor color)
        {
            
            int i = 0;
            while (i < KeyD.Length)
            {
                keyboardGrid[KeyD[i]] = color;
                i++;
            }
        }

        // Create a custom for the Keyboard
        // Set the H Key to color
        static void MakeH(ColoreColor color)
        {
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

        static void PrintJDH(ColoreColor color)
        {
            MakeJ(color);
            MakeD(color);
            MakeH(color);
            Chroma.Instance.Keyboard.SetCustom(keyboardGrid);
        }

        static void Wave(Key keyUp, Key keyDown, ColoreColor color)
        {
            if (keyUp != Key.Invalid)
                Chroma.Instance.Keyboard.SetKey(keyUp, color);

            if (keyDown != Key.Invalid)
                Chroma.Instance.Keyboard.SetKey(keyDown, ColoreColor.Black);

            System.Threading.Thread.Sleep(100);
        }

        static void Wave(int rowKeyUp, int columKeyUp, int rowKeyDown, int ColumKeyDown, Semaphore semaphoreObject, ColoreColor color)
        {
            if (rowKeyUp != -1 && columKeyUp != -1 && Chroma.Instance.Keyboard[rowKeyUp, columKeyUp] == ColoreColor.Black)
            {
                semaphoreObject.WaitOne();
                Chroma.Instance.Keyboard.SetPosition(rowKeyUp, columKeyUp, color);
                semaphoreObject.Release();
            }

            if (rowKeyDown != -1 && ColumKeyDown != -1 && Chroma.Instance.Keyboard[rowKeyDown, ColumKeyDown] == color)
            {
                semaphoreObject.WaitOne();
                Chroma.Instance.Keyboard.SetPosition(rowKeyDown, ColumKeyDown, ColoreColor.Black);
                semaphoreObject.Release();
            }
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

        static void MakeWaveRight(int rowStartWave, int columStartWave, Semaphore semaphoreObject, ColoreColor color)
        {
            Wave(rowStartWave, columStartWave, -1, -1, semaphoreObject, color);
            Wave(rowStartWave, columStartWave + 1, -1, -1, semaphoreObject, color);
            Wave(rowStartWave, columStartWave + 2, -1, -1, semaphoreObject, color);

            Wave(rowStartWave, columStartWave + 3, rowStartWave, columStartWave, semaphoreObject, color);

            Wave(-1, -1, rowStartWave, columStartWave + 1, semaphoreObject, color);
            Wave(-1, -1, rowStartWave, columStartWave + 2, semaphoreObject, color);
            Wave(-1, -1, rowStartWave, columStartWave + 3, semaphoreObject, color);
        }

        static void MakeWaveLeft(int rowStartWave, int columStartWave, Semaphore semaphoreObject, ColoreColor color)
        {
            Wave(rowStartWave, columStartWave, -1, -1, semaphoreObject, color);
            Wave(rowStartWave, columStartWave - 1, -1, -1, semaphoreObject, color);
            Wave(rowStartWave, columStartWave - 2, -1, -1, semaphoreObject, color);

            Wave(rowStartWave, columStartWave - 3, rowStartWave, columStartWave, semaphoreObject, color);

            Wave(-1, -1, rowStartWave, columStartWave - 1, semaphoreObject, color);
            Wave(-1, -1, rowStartWave, columStartWave - 2, semaphoreObject, color);
            Wave(-1, -1, rowStartWave, columStartWave - 3, semaphoreObject, color);
        }


        static void Main(string[] args)
        {
            Semaphore semaphoreObject = new Semaphore(initialCount: 1, maximumCount: 1, name: "Jdf");
            List<Dictionary<int, int>> mapLock = new List<Dictionary<int, int>>();

            System.Diagnostics.Debug.WriteLine(Chroma.Instance.Initialized);
            System.Threading.Thread.Sleep(1000);


       

            int p = 6;
            while (p < 5)
            {
                Task.Factory.StartNew(() =>
                    {
                        System.Diagnostics.Debug.WriteLine("tread create : " + p);
                        Random rnd = new Random();
                        int rowStartWave = rnd.Next(0, 6); // creates a number between 0 and 5
                        int columStartWave = rnd.Next(0, 22); // creates a number between 1 and 12

                        // Dictionary<int, int> dic = new Dictionary<int, int>();


                        while (true)
                        {

                            rowStartWave = rnd.Next(0, 6);
                            columStartWave = rnd.Next(0, 22);

                            semaphoreObject.WaitOne();

                            int i = 0;
                            while (i < mapLock.Count)
                            {
                                if (mapLock[i].ContainsKey(rowStartWave) && mapLock[i].ContainsValue(columStartWave))
                                {
                                    System.Diagnostics.Debug.WriteLine("find");
                                    rowStartWave = rnd.Next(0, 6);
                                    columStartWave = rnd.Next(0, 22);
                                    i = 0;
                                }
                                i++;
                            }
                            Dictionary<int, int> dic = new Dictionary<int, int>();
                            dic.Add(rowStartWave, columStartWave);
                            mapLock.Add(dic);
                            System.Diagnostics.Debug.WriteLine("add row : " + rowStartWave + " add col : " + columStartWave);
                            semaphoreObject.Release();

                            int leftOrRight = rnd.Next(0, 2);
                            if (columStartWave <= 10 && columStartWave >= 0 && Chroma.Instance.Keyboard[rowStartWave, columStartWave] == Color.Black && leftOrRight == 0)
                                MakeWaveRight(rowStartWave, columStartWave, semaphoreObject, ColoreColor.Green);
                            else if (columStartWave >= 11 && columStartWave <= 21 && Chroma.Instance.Keyboard[rowStartWave, columStartWave] == Color.Black && leftOrRight == 1)
                                MakeWaveLeft(rowStartWave, columStartWave, semaphoreObject, ColoreColor.Green);


                            semaphoreObject.WaitOne();
                            i = 0;
                            while (i < mapLock.Count)
                            {
                                if (mapLock[i].ContainsKey(rowStartWave) && mapLock[i].ContainsValue(columStartWave))
                                {
                                    System.Diagnostics.Debug.WriteLine("remove row : " + rowStartWave + " add col : " + columStartWave);
                                    mapLock.RemoveAt(i);
                                    i = mapLock.Count + 1;
                                }
                                i++;
                            }
                            semaphoreObject.Release();


                            System.Threading.Thread.Sleep(500);

                        }
                    });
                p++;
                System.Threading.Thread.Sleep(100);
            }

            while (true)
            {


                int i = 0;
                while (i < 10)
                {
                    PrintJDH(ColoreColor.White);
                    System.Threading.Thread.Sleep(500);
                    PrintJDH(ColoreColor.Black);

                    System.Threading.Thread.Sleep(1000);
                    i++;
                }
                i = 0;
                // PrintJDH(ColoreColor.White);
                //System.Threading.Thread.Sleep(500);
                //PrintJDH(ColoreColor.Black);

                System.Threading.Thread.Sleep(1000);
            }
        }
    }
}

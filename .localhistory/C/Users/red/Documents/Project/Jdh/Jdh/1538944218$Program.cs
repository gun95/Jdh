﻿using System;
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

            System.Diagnostics.Debug.WriteLine(Chroma.Instance.Initialized);
            System.Threading.Thread.Sleep(1000);


            Semaphore semaphoreObject = new Semaphore(initialCount: 1, maximumCount: 1, name: "PrinterApp");
            List<int> arrayRow = new List<int>();
            List<int> arrayColum = new List<int>();

            List<Dictionary<int, int>> mapLock = new List<Dictionary<int, int>>();
          
            

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
                           
                            int t = 0;
                            while (t < mapLock.Count)
                            {
                                if (mapLock[t].ContainsKey(rowStartWave) && mapLock[t].ContainsValue(columStartWave))
                                {
                                    System.Diagnostics.Debug.WriteLine("find");
                                    rowStartWave = rnd.Next(0, 6);
                                    columStartWave = rnd.Next(0, 22);
                                    t = 0;
                                }
                                t++;
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
                            t = 0;
                            while (t < mapLock.Count)
                            {
                                if (mapLock[t].ContainsKey(rowStartWave) && mapLock[t].ContainsValue(columStartWave))
                                {
                                    System.Diagnostics.Debug.WriteLine("remove row : " + rowStartWave + " add col : " + columStartWave);
                                    mapLock.RemoveAt(t);
                                    t = mapLock.Count + 1;
                                }
                                t++;
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
               // PrintJDH(ColoreColor.White);
                //System.Threading.Thread.Sleep(500);
                //PrintJDH(ColoreColor.Black);


                System.Threading.Thread.Sleep(1000);
            }
            






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


        private const int WH_KEYBOARD_LL = 13;
        private const int WM_KEYDOWN = 0x0100;
        private static LowLevelKeyboardProc _proc = HookCallback;
        private static IntPtr _hookID = IntPtr.Zero;



        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int idHook,
     LowLevelKeyboardProc lpfn, IntPtr hMod, uint dwThreadId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode,
            IntPtr wParam, IntPtr lParam);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string lpModuleName);

        // The two dll imports below will handle the window hiding.

        [DllImport("kernel32.dll")]
        static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        const int SW_HIDE = 0;




        private delegate IntPtr LowLevelKeyboardProc(
        int nCode, IntPtr wParam, IntPtr lParam);

        private static IntPtr HookCallback(
            int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0 && wParam == (IntPtr)WM_KEYDOWN)
            {
                int vkCode = Marshal.ReadInt32(lParam);
                Console.WriteLine(vkCode);
                
            }
            return CallNextHookEx(_hookID, nCode, wParam, lParam);
        }


    }
 
}

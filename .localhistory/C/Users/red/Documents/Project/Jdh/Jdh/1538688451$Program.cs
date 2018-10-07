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


            while (true)
            {
               
                Chroma.Instance.Keyboard.SetKey(Key.F2, ColoreColor.White);


                //On attends 500ms
                System.Threading.Thread.Sleep(500);

            }
        }
    }
}

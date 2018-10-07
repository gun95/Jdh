using Corale.Colore.Core;
using Corale.Colore.Razer.Keyboard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ColoreColor = Corale.Colore.Core.Color;

namespace Jdh
{
    class Program
    {


        Corale.Colore.Razer.Keyboard.Key [] j = { Key.A, Key.Z, Key.E, Key.S, Key.W , Key.A};

        static void Main(string[] args)
        {

            Chroma.Instance.SetAll(ColoreColor.Red);
            Chroma.Instance.Keyboard.SetKey(Key.A, ColoreColor.Red);

            
        }
    }
}

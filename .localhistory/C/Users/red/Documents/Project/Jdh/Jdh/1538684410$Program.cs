﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ColoreColor = Corale.Colore.Core;

namespace Jdh
{
    class Program
    {
        static void Main(string[] args)
        {
            var chroma = await ColoreProvider.CreateNativeAsync();
            await chroma.SetAllAsync(ColoreColor.Red);
        }
    }
}
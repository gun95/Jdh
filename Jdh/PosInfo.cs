using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ColoreColor = Corale.Colore.Core.Color;

namespace Jdh
{
    class PosInfo
    {
        public int Row { get; set; }
        public int Colum { get; set; }
        public ColoreColor color { get; set; }

        public PosInfo(int row, int colum, ColoreColor color)
        {
            this.Row = row;
            this.Colum = colum;
            this.color = color;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VCArcade.VCBreakout.Objects
{
    class Obstacle : PictureBox
    {
        public int MaxHits { get; set; }

        public int Hits { get; set; }

        public int PointValue { get; set; }

        private Color Color { get; set; }
    }
}

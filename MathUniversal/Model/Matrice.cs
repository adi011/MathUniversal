using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathUniversal.ViewModel
{
    class Matrice
    {
        public int WidthSize
        {
            get;
            set;
        } 

        public int HeightSize
        {
            get;
            set;
        }

        public Matrice(int width, int height)
        {
            WidthSize = width;
            HeightSize = height;
        }

    }
}

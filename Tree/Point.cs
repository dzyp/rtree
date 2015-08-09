using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tree
{
    public class Point
    {
        public Point(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public int X
        {
            get;
            internal set;
        }

        public int Y
        {
            get;
            internal set;
        }
    }
}

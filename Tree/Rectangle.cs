using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tree
{
    public class Rectangle
    {
        public Rectangle(Point lowerLeft, Point upperRight)
        {
            this.LowerLeft = lowerLeft;
            this.UpperRight = upperRight;
            this.ID = System.Guid.NewGuid().ToString();
        }

        public Rectangle(int lowerLeftX, int lowerLeftY, int upperRightX, int upperRightY) 
            : this(new Point(lowerLeftX, lowerLeftY), new Point(upperRightX, upperRightY))
        { }

        public Point LowerLeft
        {
            get;
            internal set;
        }

        public Point UpperRight
        {
            get;
            internal set;
        }

        public string ID
        {
            get;
            private set;
        }

        public byte[] Payload
        {
            get;
            set;
        }
    }
}

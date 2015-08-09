using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTree
{
    public class Node
    {
        public int ID { get; set; }
        public string Key { get; set; }
        public Rectangle MinimumBoundedRectangle { get; private set; }

        public Node()
        {

        }

        // override object.Equals
        public override bool Equals(object obj)
        {
            //       
            // See the full list of guidelines at
            //   http://go.microsoft.com/fwlink/?LinkID=85237  
            // and also the guidance for operator== at
            //   http://go.microsoft.com/fwlink/?LinkId=85238
            //

            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            // TODO: write your implementation of Equals() here
            var other = obj as Node;
            return other.Key == this.Key;
        }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            return this.ID;
        }
    }
}

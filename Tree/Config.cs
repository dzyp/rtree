using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tree
{
    public class Config
    {
        public Config(int queueDepth = 1024, int nodeWidth = 1024)
        {
            this.QueueDepth = queueDepth;
            this.NodeWidth = nodeWidth;
        }

        public Config(Config other) : this(other.QueueDepth, other.NodeWidth) { }

        public int QueueDepth
        {
            get;
            set;
        }

        public int NodeWidth
        {
            get;
            set;
        }

        public Config Copy()
        {
            return new Config(this);
        }
    }
}

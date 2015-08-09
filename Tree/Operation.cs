using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Tree
{
    enum OperationType : byte {Add = 0, Remove, Read}

    class Operation
    {
        public Operation()
        {
            this.Sync = new object();
        }

        public Operation(OperationType operationType) : this()
        {
            this.OperationType = operationType;
        }

        public object Sync
        {
            get;
            private set;
        }

        public OperationType OperationType
        {
            get;
            private set;
        }

        public Rectangle[] Rects
        {
            get;
            internal set;
        }
    }
}

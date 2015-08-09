using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTree.Serializer
{
    public interface ISerializer<T>
    {
        byte[] Marshal(T item);
        T Unmarshal(byte[] payload);
    }
}

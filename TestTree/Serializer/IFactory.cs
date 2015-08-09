using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTree.Serializer
{
    public interface IFactory
    {
        ISerializer<T> Register<T>();
    }
}

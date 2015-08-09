using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTree.Persister
{
    public interface IPersister
    {
        void Persist(string key, byte[] payload);
        byte[] Load(string key);
    }
}

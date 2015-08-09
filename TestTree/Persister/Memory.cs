using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTree.Persister
{
    public class Memory : IPersister
    {
        private Dictionary<string, byte[]> map;

        public Memory()
        {
            this.map = new Dictionary<string, byte[]>(100); // why not give a hint?
        }

        public void Persist(string key, byte[] payload)
        {
            this.map[key] = payload;
        }

        public byte[] Load(string key)
        {
            return this.map[key];
        }
    }
}

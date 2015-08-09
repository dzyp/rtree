using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MsgPack.Serialization;
using System.IO;

namespace TestTree.Serializer
{
    public class MsgPackSerializer<T>: ISerializer<T>
    {
        private MessagePackSerializer<T> serializer;

        public MsgPackSerializer()
        {
            this.serializer = MessagePackSerializer.Get<T>();
        }

        public byte[] Marshal(T item)
        {
            var buffer = new MemoryStream();
            this.serializer.Pack(buffer, item);
            return buffer.ToArray();
        }

        public T Unmarshal(byte[] payload)
        {
            var buffer = new MemoryStream(payload);
            return this.serializer.Unpack(buffer);
        }
    }
}

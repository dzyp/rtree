using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Concurrent;
using System.Threading;

namespace TestTree
{
    public class RTree : IDisposable
    {
        private Node root;
        private ConcurrentQueue<Operation> queue;
        private Config config;
        private volatile bool disposed;
        private Thread thread;

        public RTree(Config config)
        {
            this.config = config.Copy();
            this.queue = new ConcurrentQueue<Operation>();
            this.thread = new Thread(new ThreadStart(this.Worker));
            this.thread.IsBackground = true;
            try
            {
                thread.Start();
            } 
            catch (ThreadStartException e)
            {
                throw new InitializationException("Unable to initialize RTree worker thread.", e);
            }
        }

        private void mutate(OperationType operationType, Rectangle[] rects)
        {
            var operation = new Operation(OperationType.Add);
            operation.Rects = rects;
            lock (operation.Sync)
            {
                this.queue.Enqueue(operation);
                Monitor.Wait(operation.Sync);
            }
        }

        public void Add(params Rectangle[] rects)
        {
            mutate(OperationType.Add, rects);
        }

        public void Remove(params Rectangle[] rects)
        {
            mutate(OperationType.Remove, rects);
        }

        public ICollection<Rectangle> Query(Rectangle rect)
        {
            return null;
        }

        private void Worker()
        {
            var reads = new List<Rectangle>();
            var adds = new List<Rectangle>();
            var removes = new List<Rectangle>();
            try
            {
                while (true)
                {
                    var operation = new Operation();
                    if (!this.queue.TryDequeue(out operation))
                    {
                        continue;
                    }

                    switch (operation.OperationType)
                    {
                        case OperationType.Add:

                            break;
                        case OperationType.Read:
                            break;
                        case OperationType.Remove:
                            break;
                        default:
                            throw new NotImplementedException();
                    }

                    lock (operation.Sync)
                    {
                        Monitor.Pulse(operation.Sync);
                    }
                }
            }
            catch (ThreadAbortException e) 
            {
               
            }
        }

        public void Dispose()
        {
            if (this.disposed)
            {
                return;
            }

            this.disposed = true;
            this.thread.Abort();
        }
    }
}

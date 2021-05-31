using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSTUTU_Gráfok
{

    public abstract class Graph<T>
    {
        public delegate void CounterHandler(string from, string to, int count);
        protected class El
        {
            public T hova;
            public double suly;
        }
        public delegate void GraphEventHandler<T>(object source, GraphEventArgs<T> geargs);
        public abstract void AddNode(T node);
        public abstract void AddEdge(T honnan, T hova, GraphEventHandler<T> _metodus, double suly = 1, bool iranyitott = false);
        public abstract bool HasEdge(T from, T to);
        protected abstract List<T> Neighbors(T node);


        public delegate void ExternalProcessor(string item);

        public abstract void BFS(T honnan, T hova, CounterHandler _method);
        public abstract void BFS(T honnan, ExternalProcessor _method);

        public void DFS(T start, ExternalProcessor _metodus)
        {
            List<T> F = new List<T>();
            DFS(start, F, _metodus);
        }

        private void DFS(T k, List<T> f, ExternalProcessor _metodus)
        {
            ExternalProcessor metodus = _metodus;
            f.Add(k);
            metodus?.Invoke(k.ToString());
            foreach (T item in Neighbors(k))
            {
                if (!f.Contains(item))
                {
                    DFS(item, f, _metodus);
                }
            }
        }
        
        
    }
}

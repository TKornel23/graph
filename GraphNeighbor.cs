using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSTUTU_Gráfok
{
    public class GraphNeighbor<T> : Graph<T>
    {
        List<T> tartalmak = new List<T>();
        List<List<T>> szomszedok = new List<List<T>>();
        public override void AddNode(T tartalom)
        {
            tartalmak.Add(tartalom);
            szomszedok.Add(new List<T>());
        }

        public override void AddEdge(T honnan, T hova, GraphEventHandler<T> _metodus, double suly = 1, bool iranyitott = false)
        {
            GraphEventHandler<T> metodus = _metodus;
            int index = tartalmak.IndexOf(honnan);
            metodus?.Invoke(this, new GraphEventArgs<T>(honnan, hova));
            int indexHova = tartalmak.IndexOf(hova);
            int indexHonnan = tartalmak.IndexOf(honnan);
            szomszedok[indexHova].Add(tartalmak[indexHonnan]);
            szomszedok[indexHonnan].Add(tartalmak[indexHova]);
        }

        protected override List<T> Neighbors(T peek)
        {
            int index = tartalmak.IndexOf(peek);
            return szomszedok[index];
        }

        public override bool HasEdge(T from, T to)
        {
            int indexFrom = tartalmak.IndexOf(from);
            int indexTo = tartalmak.IndexOf(to);

            return szomszedok[indexFrom].Contains(tartalmak[indexTo]);
        }

        public override void BFS(T from, ExternalProcessor _metodus)
        {
            Queue<T> S = new Queue<T>();
            List<T> F = new List<T>();
            ExternalProcessor metodus = _metodus;
            S.Enqueue(from);
            F.Add(from);
            while (S.Count != 0)
            {
                T k = S.Dequeue();
                metodus?.Invoke(k.ToString());
                foreach (T x in Neighbors(k))
                {
                    if (!F.Contains(x))
                    {
                        S.Enqueue(x);
                        F.Add(x);
                    }
                }
            }
        }

        public override void BFS(T honnan, T hova, CounterHandler _metodus)
        {
            CounterHandler metodus = _metodus;
            Queue<T> S = new Queue<T>();
            List<T> F = new List<T>();
            List<int> d = new List<int>();

            S.Enqueue(honnan);
            F.Add(honnan);
            d.Add(0);

            while (S.Count != 0)
            {
                T k = S.Dequeue();
                int i = F.IndexOf(k);
                foreach (T x in Neighbors(k))
                {
                    if (!F.Contains(x))
                    {
                        S.Enqueue(x);
                        F.Add(x);
                        d.Add(d[i] + 1);
                    }
                }
            }

            int index = F.IndexOf(hova);
            
            metodus?.Invoke(honnan.ToString(), hova.ToString(), d[index]);
        }
    }
}

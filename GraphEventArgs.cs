using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSTUTU_Gráfok
{
    public class GraphEventArgs<T>
    {
        public T honnan;
        public T hova;

        public GraphEventArgs(T honnan, T hova)
        {
            this.honnan = honnan;
            this.hova = hova;
        }

    }
}

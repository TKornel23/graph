using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSTUTU_Gráfok
{
    class Program
    {
        public static void EdgeAdded(object source, GraphEventArgs<Person> geargs)
        {
            Console.WriteLine("A new edge has been added between " + geargs.honnan.ToString() + " and " + geargs.hova.ToString() + ".");
        }

        public static void Kiir(string item)
        {
            Console.WriteLine(item);
        }

        public static void Szamolo(string from, string to, int counter)
        {
            Console.WriteLine($"There are {counter} levels between {from} and {to}");
        }

        static void Main(string[] args)
        {
            Person Stew = new Person("Stew");
            Person Joseph = new Person("Joseph");
            Person Marge = new Person("Marge");
            Person Gerald = new Person("Gerald");
            Person Zack = new Person("Zack");
            Person Peter = new Person("Peter");
            Person Janet = new Person("Janet");

            Graph<Person> g = new GraphNeighbor<Person>();

            g.AddNode(Stew);
            g.AddNode(Joseph);
            g.AddNode(Marge);
            g.AddNode(Gerald);
            g.AddNode(Zack);
            g.AddNode(Peter);
            g.AddNode(Janet);

            g.AddEdge(Stew, Marge, EdgeAdded);
            g.AddEdge(Stew, Joseph, EdgeAdded);
            g.AddEdge(Marge, Joseph, EdgeAdded);
            g.AddEdge(Joseph, Gerald, EdgeAdded);
            g.AddEdge(Joseph, Zack, EdgeAdded);
            g.AddEdge(Gerald, Zack, EdgeAdded);
            g.AddEdge(Zack, Peter, EdgeAdded);
            g.AddEdge(Peter, Janet, EdgeAdded);

            
            Console.WriteLine();
            Console.WriteLine("BFS: ");
            Console.WriteLine();
            g.BFS(Stew, Kiir);
            Console.WriteLine();
            Console.WriteLine();
            g.BFS(Stew,Janet , Szamolo);

            Console.WriteLine();
            Console.WriteLine("DFS:");
            Console.WriteLine();
            g.DFS(Zack, Kiir);

            Console.WriteLine();
        }
    }
}

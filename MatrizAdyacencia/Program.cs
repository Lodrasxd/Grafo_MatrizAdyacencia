using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrizAdyacencia
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Grafo grafo = new Grafo(5,true,true);

            grafo.AddNodo(new Nodo('A'));
            grafo.AddNodo(new Nodo('B'));
            grafo.AddNodo(new Nodo('C'));
            grafo.AddNodo(new Nodo('D'));
            grafo.AddNodo(new Nodo('E'));

            grafo.AddArista(0, 1);
            grafo.AddArista(1, 2);
            grafo.AddArista(1, 4); 
            grafo.AddArista(2, 3);
            grafo.AddArista(2, 4);
            grafo.AddArista(4, 0);
            grafo.AddArista(4, 2);

            grafo.Print();
            Console.WriteLine(" //// ");
            grafo.BFS(0);
            Console.WriteLine("\n //// ");
            grafo.DFS(0);
            Console.WriteLine("\n //// ");
            grafo.Dijkstra(0);
        }
    }
}

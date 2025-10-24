using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrizAdyacencia
{
    public class Grafo
    {
        private List<Nodo> nodos;
        private int[,] matriz;
        private bool dirigido;
        private bool ponderado;
        public Grafo(int size,bool dirigido, bool ponderado)
        {
            nodos = new List<Nodo>();
            matriz = new int[size, size];
            this.dirigido = dirigido;
            this.ponderado = ponderado;
        }

        public void AddNodo(Nodo nodo)
        {
            nodos.Add(nodo);
        }

        public void AddArista(int src, int dst, int w = 1)
        {
            if (!ponderado) w = 1;
            matriz[src, dst] = w;
            if (!dirigido)
            {
                matriz[dst, src] = w;
            }
        }

        public bool CheckArista(int src, int dst)
        {
            return matriz[src, dst] == 1;
        }

        public void Print()
        {
            Console.Write("  ");
            foreach (var node in nodos)
            {
                Console.Write(node.Data + " ");
            }
            Console.WriteLine();

            for (int i = 0; i < matriz.GetLength(0); i++)
            {
                Console.Write(nodos[i].Data + " ");
                for (int j = 0; j < matriz.GetLength(1); j++)
                {
                    Console.Write(matriz[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
        public void BFS(int start)
        {
            bool[] visitado = new bool[nodos.Count];
            Queue<int> cola = new Queue<int>();

            visitado[start] = true;
            cola.Enqueue(start);

            while (cola.Count > 0)
            {
                int actual = cola.Dequeue();
                Console.Write(nodos[actual].Data + " ");

                for (int i = 0; i < nodos.Count; i++)
                {
                    if (matriz[actual, i] != 0 && !visitado[i])
                    {
                        visitado[i] = true;
                        cola.Enqueue(i);
                    }
                }
            }
        }

        public void DFS(int start)
        {
            bool[] visitado = new bool[nodos.Count];
            DFSRecursivo(start, visitado);
        }

        private void DFSRecursivo(int v, bool[] visitado)
        {
            visitado[v] = true;
            Console.Write(nodos[v].Data + " ");

            for (int i = 0; i < nodos.Count; i++)
            {
                if (matriz[v, i] != 0 && !visitado[i])
                {
                    DFSRecursivo(i, visitado);
                }
            }
        }

        public void Dijkstra(int start)
        {
            int n = nodos.Count;
            int[] distancia = new int[n];
            bool[] visitado = new bool[n];

            for (int i = 0; i < n; i++)
                distancia[i] = int.MaxValue;

            distancia[start] = 0;

            for (int count = 0; count < n - 1; count++)
            {
                int u = MinDistancia(distancia, visitado);
                visitado[u] = true;

                for (int v = 0; v < n; v++)
                {
                    if (!visitado[v] && matriz[u, v] != 0 && distancia[u] != int.MaxValue &&
                        distancia[u] + matriz[u, v] < distancia[v])
                    {
                        distancia[v] = distancia[u] + matriz[u, v];
                    }
                }
            }

            Console.WriteLine("\nDistancias mínimas desde " + nodos[start].Data + ":");
            for (int i = 0; i < n; i++)
                Console.WriteLine($"{nodos[start].Data} → {nodos[i].Data}: {distancia[i]}");
        }

        private int MinDistancia(int[] dist, bool[] visitado)
        {
            int min = int.MaxValue, minIndex = -1;
            for (int v = 0; v < dist.Length; v++)
            {
                if (!visitado[v] && dist[v] <= min)
                {
                    min = dist[v];
                    minIndex = v;
                }
            }
            return minIndex;
        }
    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
        public Grafo(bool dirigido, bool ponderado)
        {
            nodos = new List<Nodo>();
            matriz = new int[0, 0];
            this.dirigido = dirigido;
            this.ponderado = ponderado;
        }

        public void AddNodo(Nodo nodo)
        {
            bool existe = nodos.Any(n => n.Data == nodo.Data);

            if (existe)
            {
                Console.WriteLine($"Error: ya existe un vértice con el identificador '{nodo.Data}'.");
                return;
            }
            nodos.Add(nodo);
            int nuevoTam = nodos.Count;
            int[,] nuevaMatriz = new int[nuevoTam, nuevoTam];

            // Copiar los valores anteriores
            for (int i = 0; i < nuevoTam - 1; i++)
            {
                for (int j = 0; j < nuevoTam - 1; j++)
                {
                    nuevaMatriz[i, j] = matriz[i, j];
                }
            }

            matriz = nuevaMatriz; // Reemplaza la matriz anterior
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
        public void AddArista(char src, char dst, int w = 1)
        {
            int i = ObtenerIndice(src);
            int j = ObtenerIndice(dst);
            if (i == -1 || j == -1)
            {
                Console.WriteLine($"Error: alguno de los vértices '{src}' o '{dst}' no existe.");
                return;
            }
            matriz[i, j] = w;
            if (!dirigido)
                matriz[j, i] = w;
            Console.WriteLine("Arista añadida");
        }

        public bool CheckArista(int src, int dst)
        {
            return matriz[src, dst] != 0;
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
        public void BFS(char start)
        {
            int s = ObtenerIndice(start);
            if (s == -1)
            {
                Console.WriteLine($"Error: el vértice '{s}' no existe.");
                return;
            }
            bool[] visitado = new bool[nodos.Count];
            Queue<int> cola = new Queue<int>();

            visitado[s] = true;
            cola.Enqueue(s);

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

        public void DFS(char start)
        {
            int s = ObtenerIndice(start);
            if (s == -1)
            {
                Console.WriteLine($"Error: el vértice '{s}' no existe.");
                return;
            }
            bool[] visitado = new bool[nodos.Count];
            DFSRecursivo(s, visitado);
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
        public void EliminarArista(int src, int dst)
        {
            matriz[src, dst] = 0;
            if (!dirigido) matriz[dst, src] = 0;
        }
        public void EliminarArista(char src, char dst)
        {
            int i = ObtenerIndice(src);
            int j = ObtenerIndice(dst);
            if (i == -1 || j == -1)
            {
                Console.WriteLine($"Error: alguno de los vértices '{src}' o '{dst}' no existe.");
                return;
            }
            matriz[i, j] = 0;
            if (!dirigido) matriz[j, i] = 0;
            Console.WriteLine("Arista eliminada");
        }
        public void RemoveNodo(int index)
        {
            if (index < 0 || index >= nodos.Count)
            {
                Console.WriteLine("Índice inválido");
                return;
            }

            // Eliminar el nodo de la lista
            nodos.RemoveAt(index);

            int size = matriz.GetLength(0);
            int[,] nuevaMatriz = new int[size - 1, size - 1];

            // Copiar todas las filas y columnas excepto la que se elimina
            int filaNueva = 0;
            for (int i = 0; i < size; i++)
            {
                if (i == index) continue; // saltar la fila eliminada
                int colNueva = 0;
                for (int j = 0; j < size; j++)
                {
                    if (j == index) continue; // saltar la columna eliminada
                    nuevaMatriz[filaNueva, colNueva] = matriz[i, j];
                    colNueva++;
                }
                filaNueva++;
            }

            // Reemplazar la matriz antigua
            matriz = nuevaMatriz;
        }
        private int ObtenerIndice(char id)
        {
            for (int i = 0; i < nodos.Count; i++)
            {
                if (nodos[i].Data == id) return i;
            }
            return -1;
        }
    }
}


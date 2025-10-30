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
            Grafo grafo = new Grafo(true,true);
            Console.WriteLine("Que operacion desea realizar?");
            bool ciclo=true;
            int opcion=0;
            char a, b;
            while (ciclo == true)
            {
                Console.WriteLine("1.-Añadir vertice \n2.-Añadir arista\n3.-Eliminar arista\n4.-Imprimir matriz de adyacencia\n5.-Realizar busqueda por amplitud (BFS)\n6.-Reealizar Busqueda en profundidad (DFS)\n7.-Salir");
                opcion = int.Parse(Console.ReadLine());
                switch (opcion) 
                {
                    case 1: Console.WriteLine("con que caracter identificara al nuevo vertice?");
                        grafo.AddNodo(new Nodo(Console.ReadKey().KeyChar));
                        Console.WriteLine("\nVertice añadido");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 2: Console.WriteLine("Escribe el caracter asignado del vertice origen");
                        a = Console.ReadKey().KeyChar;
                        Console.WriteLine("\nEscribe el caracter asignado del vertice destino");
                        b = Console.ReadKey().KeyChar;
                        grafo.AddArista(a, b);
                        
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 3: Console.WriteLine();
                        Console.WriteLine("Escribe el caracter asignado del vertice origen");
                        a = Console.ReadKey().KeyChar;
                        Console.WriteLine("\nEscribe el caracter asignado del vertice destino");
                        b = Console.ReadKey().KeyChar;
                        grafo.EliminarArista(a, b);
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 4: Console.WriteLine("Matriz de Adyacencia:\n");
                        grafo.Print();
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 5: Console.WriteLine("Escribe el caracter asignado del vertice de inicio");
                        grafo.BFS(Console.ReadKey().KeyChar);
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 6: Console.WriteLine("Escribe el caracter asignado del vertice de inicio");
                        grafo.DFS(Console.ReadKey().KeyChar);
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 7: ciclo = false;
                        Console.WriteLine("Saliendo...");
                        Console.ReadKey();

                        break;
                    default: Console.WriteLine("Opcion invalida");
                        Console.ReadKey(); 
                        break;
                }
            }
            
            
        }
    }
}

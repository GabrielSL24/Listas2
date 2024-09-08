using System;
using System.Reflection.Metadata.Ecma335;

namespace ExtraclaseConsole2
{
    public class Program
    {
        static void Main(string[] args)
        {
            Invertir();
            CombinedList();
            ValueMiddle();
        }

        public static void Invertir()
        {
            int[] values = { 1, 8, 4, 20, 55, 15 };
            ListaDoble lista = Convert(values);
            
            Console.WriteLine("Lista original: ");
            Node? current = lista.Head;
            while (current != null)
            {
                Console.Write(current.value + " ");
                current = current.next;
            }
            Console.WriteLine();

            lista.Invert(lista);
            Console.WriteLine("Lista Invertida: ");
            current = lista.Head;
            while (current != null)
            {
                Console.Write(current.value + " ");
                current = current.next;
            }
            Console.WriteLine();
        }

        public static ListaDoble Convert(int[] array)
        {
            ListaDoble lista = new ListaDoble();
            foreach (int value in array)
            {
                lista.Insert(value);
            }
            return lista;
        }

        public static void CombinedList()
        {
            ListaDoble listaA = new ListaDoble();
            ListaDoble listaB = new ListaDoble();

            int[] listA = { 1, 5, 6, 8, 15, 22, 23 };
            int[] listB = { 2, 7, 9, 20, 30 };

            foreach (int value in listA)
            {
                listaA.InsertInOrder(value);
            }
            foreach (int value in listB)
            {
                listaB.InsertInOrder(value);
            }

            ListaDoble combined = new ListaDoble();
            combined.MergeSorted(listaA, listaB, SortDirection.Desc);

            Console.WriteLine("Lista combinada y ordenada: ");
            Node current = combined.Head;
            while (current != null)
            {
                Console.Write(current.value + " ");
                current = current.next;
            }
            Console.WriteLine();
        }

        public static void ValueMiddle()
        {
            ListaDoble list = new ListaDoble();
            int[] lista = { 1, 2, 5 };
            foreach ( int value in lista)
            {
                list.Insert(value);
            }
            int middle = list.GetMiddle();
            Console.WriteLine("El elemento central es: " + middle);

        }
    }
}

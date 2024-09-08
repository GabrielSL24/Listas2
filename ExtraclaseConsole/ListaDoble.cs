using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtraclaseConsole2
{
    public class ListaDoble : Ilist
    {
        private Node? head;
        private Node? last;
        public Node? Head
        {
            get { return head; } 
        }
        private int size;

        public int DeleteFirst()
        {
            if (this.head == null)
            {
                throw new InvalidOperationException("la lista está vacía");
            }
            int valuehead = this.head.value;
            this.head = this.head.next;
            if (this.head != null)
            {
                this.head.prev = null;
            }
            else
            {
                this.last = null;
            }
            return valuehead;
            
        }

        public int DeleteLast()
        {
            if (this.last == null)
            {
                throw new InvalidOperationException("la lista esta vacía");
            }
            int valuelast = this.last.value;
            this.last = this.last.prev;
            if (this.last != null)
            {
                this.last.next = null;
            }
            else
            {
                this.head = null;
            }

            return valuelast;
        }

        public bool DeleteValue(int value)
        {
            if (this.head == null)
            {
                return false;
            }
            
            if(this.head.value == value)
            {
                this.head = this.head.next;
                if (this.head != null)
                {
                    this.head.prev = null;
                }
                return true;
            }

            Node current = this.head;
            while (current.next != null)
            {
                if (current.next.value == value)
                {
                    current.next = current.next.next;
                    if (current.next != null)
                    {
                        current.next.prev = current;
                    }
                    return true;
                }
                current = current.next;
            }
            return false;
        }

        public int GetMiddle()
        {
            if (this.head == null)
            {
                throw new InvalidOperationException("La lista esta vacia");
            } 
            
            Node current = this.head;
            int size = 0;

            while (current != null)
            {
                size++;
                current = current.next;
            }
            
            current = this.head;

            for (int i = 0; i < size / 2; i++)
            {
                current = current.next;
            }
            return current.value;
        }

        public void Invert(ListaDoble list)
        {
            if (list.head == null || list.head.next == null)
            {
                return;
            }
            Node? left = list.head;
            Node? right = list.last;
            
            while (left != right && left.prev != right)
            {
                int temp = left.value;
                left.value = right.value;
                right.value = temp;

                left = left.next;
                right = right.prev;
            }

            
        }

        public void Insert(int value)
        {
            Node newNode = new Node(value);

            if (this.head == null)
            {
                this.head = newNode;
                this.last = newNode;
            }
            else
            {
                this.last.next = newNode;
                newNode.prev = this.last;
                this.last = newNode;
            }

        }

        public void InsertInOrder(int value)
        {
            Node newNode = new Node(value);

            if (this.head == null)
            {
                this.head = newNode;
                this.last = newNode;
            }
            else if (this.head.value >= value)
            {
                newNode.next = this.head;
                this.head.prev = newNode;
                this.head = newNode;
            }
            else
            {
                Node current = this.head;
                while (current.next != null && current.next.value < value)
                {
                    current = current.next;
                }

                newNode.next = current.next;
                if (current.next != null)
                {
                    current.next.prev = newNode;
                }
                else
                {
                    this.last = newNode;
                }
                current.next = newNode;
                newNode.prev = current;
            }
        }

        public List<int> GetAllValues()
        {
            List<int> values = new List<int>();
            Node? current = this.head;

            while (current != null)
            {
                values.Add(current.value);
                current = current.next;
            }
            return values;
        }

        public void MergeSorted(Ilist listaA, Ilist listaB, SortDirection direction)
        {
            List<int> valuesA = ((ListaDoble)listaA).GetAllValues();
            List<int> valuesB = ((ListaDoble)listaB).GetAllValues();

            foreach (int value in valuesA)
            {
                this.InsertInOrder(value);
            }
            foreach (int value in valuesB)
            {
                this.InsertInOrder(value);
            }

            if (direction == SortDirection.Desc)
            {
                Invert(this);
            }
        }
    }
}

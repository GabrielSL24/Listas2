using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtraclaseConsole2
{
    public enum SortDirection { Asc, Desc};
    public interface Ilist
    {
        void InsertInOrder(int value);
        int DeleteFirst();
        int DeleteLast();
        bool DeleteValue(int value);
        int GetMiddle();
        void MergeSorted(Ilist listaA, Ilist listaB, SortDirection direction);
    }
}

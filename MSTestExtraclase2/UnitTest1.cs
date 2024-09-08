using ExtraclaseConsole2;

namespace MSTestExtraclase2
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestInvert()
        {
            int[] list = { 1, 8, 4, 20, 55, 15 };
            ListaDoble lista = new ListaDoble();

            foreach (int value in list)
            {
                lista.Insert(value);
            }
            lista.Invert(lista);
            List<int> result = lista.GetAllValues();
            int[] expectedList = { 15, 55, 20, 4, 8, 1 };
            CollectionAssert.AreEqual(expectedList, result);
        }

        [TestMethod]
        public void TestMergeSorted()
        {
            ListaDoble listaA = new ListaDoble();
            ListaDoble listaB = new ListaDoble();

            int[] listA = { 1, 6, 8, 15, 25 };
            int[] listB = { 5, 7, 9, 12, 30 };

            foreach (int value in listA)
            {
                listaA.InsertInOrder(value);
            }

            foreach (int value in listB)
            {
                listaB.InsertInOrder(value);
            }
            ListaDoble combined = new ListaDoble();
            combined.MergeSorted(listaA, listaB, SortDirection.Asc);

            int[] expectedList = { 1, 5, 6, 7, 8, 9, 12, 15, 25, 30 };
            Node current = combined.Head;
            int index = 0;
            while (current != null)
            {
                Assert.AreEqual(expectedList[index], current.value);
                current = current.next;
                index++;
            }
            Assert.AreEqual(expectedList.Length, index);
        }

        [TestMethod]
        public void TestGedMiddle()
        {
            ListaDoble list = new ListaDoble();
            int[] lista = { 1, 2, 5 };

            foreach (int value in lista)
            {
                list.InsertInOrder(value);
            }

            int middleValue = list.GetMiddle();
            Assert.AreEqual(2, middleValue);
        }
    }
}
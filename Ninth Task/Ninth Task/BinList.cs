using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ninth_Task
{
    class BinList//Класс для двунаправленных списков
    {

        private int data;//иформационное поле элемента списка (строка)
        public BinList next;//адресное поле элемента списка (указывает на следующий элемент)
        public BinList prev;//адресное поле элемента списка (указывает на предыдущий элемент)
        public int Data
        {
            get { return data; }
        }
        public BinList Next
        {
            get { return next; }
            set { next = value; }
        }
        public BinList Prev
        {
            get { return prev; }
            set { prev = value; }
        }
        public BinList()
        {
            data = 0;
            next = null;
            prev = null;
        }//Создание пустого элемента  списка
        public BinList(int d)
        {
            data = d;
            next = null;
            prev = null;
        }//Создание элемента списка       

        public static BinList Add(int size)
        {

            int info = 1;
            BinList beg = new BinList(info);

            BinList temp = beg;
            for (int i = 1; i < size; i++)
            {
                info++;
                BinList NewElem = new BinList(info);
                temp.Next = NewElem;
                NewElem.Prev = temp;
                temp = NewElem;
            }
            return beg;
        }//Создание списка добавлением элементов в конец списка  
        public static BinList Ydalenie(BinList beg, int number)
        {
            if (beg == null)
            {
                Console.WriteLine("Список пуст");
                return null;
            }
            if (number == 1)
            {
                beg = beg.next;
                return beg;
            }
            BinList p = beg;
            for (int i = 1; i < number - 1 && p != null; i++)
                p = p.next;
            if (p == null)
            {
                Console.WriteLine("Размер списка меньше введённого числа");
                return beg;
            }
            p.next = p.next.next;
            p.next.next.prev = p;
            return beg;
        }//Удаление элемента списка с указанным номером
        public static void ShowList(BinList beg)
        {
            if (beg == null)
            {
                Console.WriteLine("Список пуст");
                return;
            }
            BinList p = beg;
            while (p != null)
            {
                Console.Write(p + " ");
                p = p.next;

            }
            Console.WriteLine();
        }//Показать список
        public override string ToString()
        {
            return data + " ";
        }
    }
}

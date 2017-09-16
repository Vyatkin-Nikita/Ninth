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
        private BinList next;//адресное поле элемента списка (указывает на следующий элемент)
        private BinList prev;//адресное поле элемента списка (указывает на предыдущий элемент)

        public int Data
        {
            get { return data; }
        }//Свойство информационного поля
        public BinList Next
        {
            get { return next; }
            set { next = value; }
        }//свойство next
        public BinList Prev
        {
            get { return prev; }
            set { prev = value; }
        }//свойство prev

        public BinList()//Создание пустого элемента  списка
        {
            data = 0;
            next = null;
            prev = null;
        }
        public BinList(int d)//Создание элемента списка  
        {
            data = d;
            next = null;
            prev = null;
        }

        public static BinList Create(int size)//Создание списка добавлением элементов в конец списка  
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
        }
        public BinList Remove(int number)//Удаление элемента списка с указанным информационным полем
        {

            BinList temp = this;
            do
            {
                if (temp.Data == number)
                {
                    if (temp.Prev == null && temp.Next == null) { return null; }
                    if (temp.Prev == null) { temp = temp.next; temp.Prev = null; return temp; }
                    if (temp.Next == null) { temp.Prev.Next = null; return this; }
                    temp.Prev.Next = temp.Next; temp.Next.Prev = temp.Prev; return this;
                }
                temp = temp.Next;
            }
            while (temp != null);

            Console.WriteLine("В списке нет элементов с таким информационным полем");
            return this;
        }
        public void Search(int number)//Поиск элемента списка с указанным информационным полем
        {
            int count = 1;
            BinList temp = this;
            do
            {
                if (temp.Data == number)
                {
                    Console.WriteLine("Информационнон поле {0} имеет элемент номер {1}", number, count); return;
                }
                temp = temp.Next;
                count++;
            }
            while (temp != null);

            Console.WriteLine("В списке нет элементов с таким информационным полем");
        }
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
        }//Перегрузка ToString()
    }
}

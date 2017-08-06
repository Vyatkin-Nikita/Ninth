using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ninth_Task
{
    /*Создание двунаправленного списка, в информационные поля элементов которого последовательно заносятся номера с 1 до N (N водится с клавиатуры).
      Первый включенный в список элемент, имеющий номер 1, оказывается в голове списка (первым).
      Имеются методы поиска и удаления элементов списка.
      Сторонние библиотеки не использовались.
      Все перечисленные выше методы описаны в классе BinList 
    */
    class Program
    {
        static BinList Beg;//Первый элемент двунаправленного списка
        static int N;//Число N

        static int VvodProverka(int mogr = 0, int bogr = 0)//Проверка вводимых с клавиатуры чисел, mogr и bogr - минимально и максимально возможные значения числа
        {
            bool ok;
            int n;
            do
            {
                ok = int.TryParse(Console.ReadLine(), out n);
                if (!ok) { Console.WriteLine("Ошибка. Неверный формат данных. Повторите ввод."); continue; }
                if ((n < mogr) && (bogr < mogr)) { Console.WriteLine("Ошибка. Число должно быть больше или равно {0} . Повторите ввод.", mogr); ok = false; continue; }              
                if ((n < mogr) && (mogr != 0) || ((n > bogr) && (bogr != 0))) { Console.WriteLine("Ошибка. Число должно находится в пределах от {0} до {1} . Повторите ввод.", mogr, bogr); ok = false; }

            } while (!ok);
            Console.WriteLine();
            return n; 
        }
        static void Menu()//Меню задачи
        {

            Console.WriteLine("Выберите действие:\n1. Создать новый двунаправленный список\n2. Найти элемент списка\n3. Удалить элемент списка\n4. Выход из программы");
            int i = VvodProverka(1, 4);
            switch (i)
            {
                case 1:
                    {
                        Console.Clear();
                        Console.WriteLine("Введите число N");
                        N = VvodProverka(1);
                        Beg = BinList.Create(N);
                        Console.Clear();
                        BinList.ShowList(Beg);
                        Console.WriteLine();
                        Menu();
                    }
                    break;
                case 2:
                    {
                        Console.Clear();
                        if (Beg == null) { BinList.ShowList(Beg); Console.WriteLine(); Menu(); }
                        else
                        {
                            BinList.ShowList(Beg); Console.WriteLine();
                            Console.WriteLine("Введите информационное поле искомого элемента");
                            int info = VvodProverka(1,N);
                            Beg.Search(info);
                            BinList.ShowList(Beg);
                            Console.WriteLine(); Menu();
                        }
                    }
                    break;
                case 3:
                    {
                        Console.Clear();
                        if (Beg == null) { BinList.ShowList(Beg); Console.WriteLine(); Menu(); }
                        else
                        {
                            BinList.ShowList(Beg); Console.WriteLine();
                            Console.WriteLine("Введите информационное поле удаляемого элемента");
                            int info = VvodProverka(1,N);
                            Beg = Beg.Remove(info);
                            BinList.ShowList(Beg);
                            Console.WriteLine(); Menu();
                        }
                    }
                    break;
                case 4:
                    Environment.Exit(0);
                    break;

            }
        }

        static void Main(string[] args)
        {
            Menu();
        }
    }
}

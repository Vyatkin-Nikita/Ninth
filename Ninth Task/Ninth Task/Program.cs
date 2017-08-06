using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ninth_Task
{
    class Program
    {
        static BinList Beg;//Первый элемент двунаправленного списка
        static int VvodProverka(int mogr = -1, int bogr = -1)//Проверка вводимых с клавиатуры чисел, mogr и bogr - минимально и максимально возможные значения числа
        {
            bool ok;
            int n;
            do
            {
                ok = int.TryParse(Console.ReadLine(), out n);
                if (!ok) Console.WriteLine("Ошибка. Неверный формат данных. Повторите ввод.");
                if (((n <= mogr) && (mogr != -1) || ((n > bogr) && (bogr != -1))) && (ok)) { Console.WriteLine("Ошибка. Число должно находится в пределах от {0} до {1} . Повторите ввод.", mogr + 1, bogr); ok = false; }

            } while (!ok);
            Console.WriteLine();
            return n;
        }
        static void Menu()//Меню задачи
        {

            Console.WriteLine("Выберите действие:\n1. Создать новый двунаправленный список\n2. Найти элемент списка\n3. Удалить элемент списка\n4. Выход из программы");
            int i = VvodProverka(0, 4);
            switch (i)
            {
                case 1:
                    {
                        Console.Clear();
                        Console.WriteLine("Введите число N");
                        int N = VvodProverka(0);
                        Beg = BinList.Add(N);
                        BinList.ShowList(Beg);
                        Console.WriteLine();
                        Menu();
                    }
                    break;
                case 2:
                    {
                        if (Beg == null) { Console.Clear(); Console.WriteLine("Список пуст."); Menu(); }
                        Console.WriteLine("Введите номер добавляемой строки");
                        int s = VvodProverka(0, 4);
                        if (Beg == null && s != 1)
                        { Console.WriteLine("Ошибка! Длина списка меньше введённого номера"); Menu(); }
                        Console.Clear();
                        BinList.ShowList(Beg);
                      
                        BinList.ShowList(Beg);
                        
                        Console.WriteLine(); Menu();
                    }
                    break;
                case 3:
                    {
                        Console.Clear();
                        Console.WriteLine("Введите информационное поле удаляемого элемента");
                        int info = VvodProverka(0);
                        Beg = null;
                        Console.WriteLine(); Menu();
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

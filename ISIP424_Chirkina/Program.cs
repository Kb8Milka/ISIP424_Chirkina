using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISIP424_Chirkina
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n;
            Dictionary<string, double> Spisok = new Dictionary<string, double>();

            if (Spisok.Count == 2)
            {
                string name = Console.ReadLine();
            }
            else if (Spisok.Count <= 40)
            {
                Console.WriteLine("Значение не принято");
            }
            else
            {
                Console.WriteLine("Значение не принято");
            }

            //меню
            int choice = 0;
            while (choice != 0)
            {
                Console.WriteLine();
                Console.WriteLine("меню:");
                Console.WriteLine("1. Вывод данных");
                Console.WriteLine("2. Статистика");
                Console.WriteLine("3. Сортировка по цене");
                Console.WriteLine("4. Конвертация валюты ");
                Console.WriteLine("5. Поиск по названию ");
                Console.WriteLine("0. Выход");
                Console.WriteLine();
                Console.WriteLine("Выберете пункт: ");
                choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.WriteLine();
                        Console.WriteLine("Все расходы: ");

                        break;
                    case 2:
                        Console.WriteLine();
                        Console.WriteLine("Статистика: ");

                        break;
                    case 3:
                        Console.WriteLine();
                        Console.WriteLine("Отсортированные по цене: ");

                        break;
                    case 4:
                        Console.WriteLine();
                        Console.WriteLine("Выбор валюты: ");
                        break;
                    case 5:
                        Console.WriteLine();
                        Console.WriteLine("Введите название: ");

                        break;
                    case 0:
                        Console.WriteLine();

                        break;
                }
            }
    }
}

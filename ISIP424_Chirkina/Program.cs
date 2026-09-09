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
            Dictionary<string, double> Spisok = new Dictionary<string, double>();
            int n;
            do
            {
                Console.WriteLine("Введите кол-во операций от 2 до 40: ");
                n = Convert.ToInt32(Console.ReadLine());
            } while (n < 2 || n > 40);

            string[] names = new string[n];
            double[] prices = new double[n];

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Введите название услуги или товара: ");
                names[i] = Console.ReadLine();

                Console.WriteLine("Введите название услуги или товара: ");
                prices[i] = Convert.ToDouble(Console.ReadLine());
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
                        Console.WriteLine("Программа завершена, Босс");
                        break;

                    default: 
                        Console.WriteLine("Такого выбора нет :( ");
                        break;
                }
            }
    }
}

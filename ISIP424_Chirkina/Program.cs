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
            choice = Convert.ToInt32(Console.ReadLine());

            // выбор
            switch (choice)
            {
                case 1:
                    Console.WriteLine();
                    Console.WriteLine("Все расходы: ");
                    break;

                case 3:
                    Console.WriteLine();
                    
                    break;

                case 4:
                    Console.WriteLine();
                    Console.WriteLine("Доступные валюты:");

                    break;

                case 5:
                    Console.WriteLine();
                    Console.Write("Введите название: ");
                    string search = Console.ReadLine();

                    bool found = false;

                    for (int i = 0; i < n; i++)
                    {
                        if (names[i] == search)
                        {
                            Console.WriteLine(names[i] + " - " + prices[i] + " руб.");
                            found = true;
                        }
                    }

                    if (found == false)
                    {
                        Console.WriteLine("Ничего не найдено.");
                    }

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

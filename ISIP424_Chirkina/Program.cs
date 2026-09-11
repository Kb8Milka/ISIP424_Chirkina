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
            // ввод операций
            Dictionary<string, double> Spisok = new Dictionary<string, double>();
            int n;
            do
            {
                Console.WriteLine("Введите кол-во операций от 2 до 40: ");
                n = Convert.ToInt32(Console.ReadLine());
            } while (n < 2 || n > 40);

            // ввол данных
            string[] names = new string[n];
            double[] prices = new double[n];

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Введите название услуги или товара: ");
                names[i] = Console.ReadLine();

                Console.WriteLine("Введите Цену: ");
                prices[i] = Convert.ToDouble(Console.ReadLine());
            }

            //меню
            int choice = -1;
            while (choice != 0)
            {
                Console.WriteLine();
                Console.WriteLine("     МЕНЮ:   ");
                Console.WriteLine("1. Вывод данных");
                Console.WriteLine("2. Статистика");
                Console.WriteLine("3. Сортировка по цене");
                Console.WriteLine("4. Конвертация валюты ");
                Console.WriteLine("5. Поиск по названию ");
                Console.WriteLine("0. Выход");
                Console.WriteLine();
                Console.WriteLine("Выберете пункт: ");
                choice = Convert.ToInt32(Console.ReadLine());

                // выбор
                switch (choice)
                {
                    case 1:
                        Console.WriteLine();
                        Console.WriteLine("Все расходы: ");
                        for (int i = 0; i < n; i++)
                        {
                            Console.WriteLine(names[i] + " " + prices[i] + " руб");
                        }
                        break;

                    case 2:
                        Console.WriteLine();
                        Console.WriteLine("Статистика: ");
                        double sum = 0;
                        double max = prices[0];
                        double min = prices[0];

                        for (int i = 0; i < n; i++)
                        {
                            sum = sum + prices[i];
                            if (prices[i] > max)
                            {
                                max = prices[i];
                            }
                            if (prices[i] < min)
                            {
                                min = prices[i];
                            }
                        }

                        double srednee = sum / n;
                        Console.WriteLine("Среднее: " + srednee);
                        Console.WriteLine("Максимум: " + max);
                        Console.WriteLine("Минимум: " + min);
                        Console.WriteLine("Сумма: " + sum);
                        break;

                    case 3:
                        Console.WriteLine();
                        for (int i = 0; i < n - 1; i++)
                        {
                            for (int j = 0; j < n - 1; j++)
                            {
                                if (prices[j] > prices[j + 1])
                                {
                                    double temp = prices[j];
                                    prices[j] = prices[j + 1];
                                    prices[j + 1] = temp;

                                    string tempName = names[j];
                                    names[j] = names[j + 1];
                                    names[j + 1] = tempName;
                                }
                            }
                        }

                        Console.WriteLine("Расходы отсортированы:");
                        for (int i = 0; i < n; i++)
                        {
                            Console.WriteLine(names[i] + " - " + prices[i] + " руб.");
                        }

                        break;

                    case 4:
                        Spisok.Add("USD", 80);
                        Spisok.Add("EUR", 95);
                        Spisok.Add("UAH", 1.89);

                        Console.WriteLine();
                        Console.WriteLine("Доступные валюты:");

                        foreach (string key in Spisok.Keys)
                        {
                            Console.WriteLine(key + " - курс " + Spisok[key]);
                        }

                        Console.WriteLine();
                        Console.Write("Введите валюту: ");
                        string selectedSpisok = Console.ReadLine().ToUpper();

                        if (Spisok.ContainsKey(selectedSpisok))
                        {
                            double rate = Spisok[selectedSpisok];

                            Console.WriteLine();
                            Console.WriteLine("Расходы в " + selectedSpisok + ":");

                            for (int i = 0; i < n; i++)
                            {
                                double result = prices[i] / rate;

                                Console.WriteLine(
                                    names[i] + " - " +
                                    result.ToString("F2") + " " +
                                    selectedSpisok
                                );
                            }
                        }
                        else
                        {
                            Console.WriteLine("Такой валюты нет.");
                        }
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
}

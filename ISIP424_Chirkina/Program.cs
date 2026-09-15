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
            List<Thing> products = new List<Thing>();

            // Список продуктов:
            Thing Apple = new Thing()
            {
                ID = 1001,
                name = "Яблоко",
                cost = 120,
                kolvo = 10,
                nalichie = 1,
                category = "Продукты"
            };

            Thing Banan = new Thing()
            {
                ID = 1002,
                name = "Банан",
                cost = 100,
                kolvo = 15,
                nalichie = 1,
                category = "Продукты"
            };

            Thing Shirt = new Thing()
            {
                ID = 1003,
                name = "Футболка",
                cost = 1200,
                kolvo = 3,
                nalichie = 1,
                category = "Одежда"
            };

            products.Add(Apple);
            products.Add(Banan);
            products.Add(Shirt);

            // Меню
            int choice = -1;
            while (choice != 0)
            {
                Console.WriteLine();
                Console.WriteLine("     МЕНЮ:   ");
                Console.WriteLine("1. Добавить товар");
                Console.WriteLine("2. Удалить товар");
                Console.WriteLine("3. Заказать поставку товара");
                Console.WriteLine("4. Продать товар");
                Console.WriteLine("5. Поиск товаров (по коду, названию и категории)");
                Console.WriteLine("0. Выход");
                Console.WriteLine();
                Console.WriteLine("Выберете пункт: ");
                choice = Convert.ToInt32(Console.ReadLine());

                choice = Convert.ToInt32(Console.ReadLine());

                // выбор
                switch (choice)
                {
                    case 1:
                        Console.WriteLine();
                        Console.WriteLine("Введите товар который хотите добавить: ");

                        break;

                    case 2:
                        Console.WriteLine();
                        Console.WriteLine("Список товаров на данный момент: ");
                        Console.WriteLine("Введите товер, который хотите удалить: ");

                        break;

                    case 3:
                        Console.WriteLine();
                        Console.WriteLine("Введите какой товар хотите заказать: ");

                        break;

                    case 4:
                        Console.WriteLine();
                        Console.WriteLine("Введите какой товар хотите продать: ");

                        break;

                    case 5:
                        Console.WriteLine();
                        Console.Write("Введите код, название или категорию: ");
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

                    case 6:
                        //Вывод всех товаров
                        foreach (Thing product in products)
                        {
                            Console.WriteLine(product.ID + product.name + product.cost);
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

    class Thing
    {
        public int ID;
        public string name;
        public int cost;
        public int kolvo;
        public int nalichie;
        public string category;
    }
}

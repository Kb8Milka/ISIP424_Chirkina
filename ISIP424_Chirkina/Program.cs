using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISIP424_Chirkina
{
    // Перечесление
    enum Kategoriya
    {
        Продукты,
        Одежда,
        Электроника,
        БытоваяТехника
    }

    internal class Program
    {
        // Список всех товаров магазина
        static List<Thing> tovary = new List<Thing>();

        // Счётчик для уникального кода..
        static int ID = 1;

        static void Main(string[] args)
        {
            // Пять тестовых товаров
            tovary.Add(new Thing(ID++, "Хлеб", 50, 10, Kategoriya.Продукты));
            tovary.Add(new Thing(ID++, "Молоко", 80, 5, Kategoriya.Продукты));
            tovary.Add(new Thing(ID++, "Футболка", 1200, 3, Kategoriya.Одежда));
            tovary.Add(new Thing(ID++, "Наушники", 2500, 0, Kategoriya.Электроника));
            tovary.Add(new Thing(ID++, "Микроволновка", 7000, 2, Kategoriya.БытоваяТехника));

            // меню
            int choice = -1;
            while (choice != 0)
            {
                Console.WriteLine();
                Console.WriteLine(" МЕНЮ: ");
                Console.WriteLine("1. Добавить товар");
                Console.WriteLine("2. Удалить товар");
                Console.WriteLine("3. Заказать поставку товара");
                Console.WriteLine("4. Продать товар");
                Console.WriteLine("5. Поиск товаров (по коду, названию и категории)");
                Console.WriteLine("0. Выход");
                Console.WriteLine();
                Console.WriteLine("Выберете пункт: ");

                // Проверка, что введено число
                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Нужно ввести число!");
                    choice = -1;
                    continue;
                }

                // выбор
                switch (choice)
                {
                    case 1:
                        Console.WriteLine();
                        Console.WriteLine("Добавление товара");

                        Console.Write("Введите название товара: ");
                        string newName = Console.ReadLine();

                        if (string.IsNullOrWhiteSpace(newName))
                        {
                            Console.WriteLine("Название не может быть пустым!");
                            break;
                        }

                        int newCost;

                        Console.Write("Введите цену: ");

                        if (!int.TryParse(Console.ReadLine(), out newCost))
                        {
                            Console.WriteLine("Цена должна быть числом!");
                            break;
                        }
                        else if (newCost < 0)
                        {
                            Console.WriteLine("Цена не может быть отрицательной!");
                            break;
                        }

                        int newKolvo;

                        Console.Write("Введите количество: ");

                        if (!int.TryParse(Console.ReadLine(), out newKolvo))
                        {
                            Console.WriteLine("Количество должно быть числом!");
                            break;
                        }
                        else if (newKolvo < 0)
                        {
                            Console.WriteLine("Количество не может быть отрицательным!");
                            break;
                        }

                        Console.WriteLine("Выберите категорию:");
                        Console.WriteLine("1. Продукты");
                        Console.WriteLine("2. Одежда");
                        Console.WriteLine("3. Электроника");
                        Console.WriteLine("4. Бытовая техника");

                        int katChoice;

                        if (!int.TryParse(Console.ReadLine(), out katChoice))
                        {
                            Console.WriteLine("Нужно ввести число!");
                            break;
                        }
                        else if (katChoice < 1 || katChoice > 4)
                        {
                            Console.WriteLine("Такой категории нет!");
                            break;
                        }

                        Kategoriya newKat;

if (katChoice == 1)
{
    newKat = Kategoriya.Продукты;
}
else if (katChoice == 2)
{
    newKat = Kategoriya.Одежда;
}
else if (katChoice == 3)
{
    newKat = Kategoriya.Электроника;
}
else
{
    newKat = Kategoriya.БытоваяТехника;
}

                        tovary.Add(new Thing(ID++, newName, newCost, newKolvo, newKat));
                        Console.WriteLine("Товар успешно добавлен! Код: " + (ID - 1));
                        break;

                    case 2:
                        Console.WriteLine();
                        Console.WriteLine("Удаление товара");
                        Spisok();

                        Console.Write("Введите код товара, который хотите удалить: ");

                        int delID;

                        if (!int.TryParse(Console.ReadLine(), out delID))
                        {
                            Console.WriteLine("Код должен быть числом!");
                            break;
                        }
                        else if (delID <= 0)
                        {
                            Console.WriteLine("Код должен быть положительным!");
                            break;
                        }

                        Thing delThing = null;

                        foreach (Thing t in tovary)
                        {
                            if (t.ID == delID)
                            {
                                delThing = t;
                            }
                        }

                        if (delThing == null)
                        {
                            Console.WriteLine("Товар с таким кодом не найден!");
                        }
                        else
                        {
                            tovary.Remove(delThing);
                            Console.WriteLine("Товар " + delThing.name + " удалён!");
                        }

                        break;

                    case 3:
                        Console.WriteLine();
                        Console.WriteLine("Поставка товара");
                        Spisok();

                        Console.Write("Введите код товара, который хотите заказать: ");

                        int postID;

                        if (!int.TryParse(Console.ReadLine(), out postID))
                        {
                            Console.WriteLine("Код должен быть числом!");
                            break;
                        }
                        else if (postID <= 0)
                        {
                            Console.WriteLine("Код должен быть положительным!");
                            break;
                        }

                        Thing postThing = null;

                        foreach (Thing t in tovary)
                        {
                            if (t.ID == postID)
                            {
                                postThing = t;
                            }
                        }

                        if (postThing == null)
                        {
                            Console.WriteLine("Товар не найден!");
                            break;
                        }

                        int postKolvo;

                        Console.Write("Сколько нужно товара: ");

                        if (!int.TryParse(Console.ReadLine(), out postKolvo))
                        {
                            Console.WriteLine("Количество должно быть числом!");
                            break;
                        }

                        if (postKolvo <= 0)
                        {
                            Console.WriteLine("Количество должно быть больше 0!");
                            break;
                        }

                        postThing.kolvo = postThing.kolvo + postKolvo;
                        postThing.ObnovitNalichie();

                        Console.WriteLine("Поставка выполнена! Теперь на складе: " + postThing.kolvo);
                        break;

                    case 4:
                        Console.WriteLine();
                        Console.WriteLine("Продажа товара");
                        Spisok();

                        Console.Write("Введите код товара, который хотите продать: ");

                        int sellID;

                        if (!int.TryParse(Console.ReadLine(), out sellID))
                        {
                            Console.WriteLine("Код должен быть числом!");
                            break;
                        }
                        else if (sellID <= 0)
                        {
                            Console.WriteLine("Код должен быть положительным!");
                            break;
                        }

                        Thing sellThing = null;

                        foreach (Thing t in tovary)
                        {
                            if (t.ID == sellID)
                            {
                                sellThing = t;
                            }
                        }

                        if (sellThing == null)
                        {
                            Console.WriteLine("Товар не найден!");
                            break;
                        }

                        // Проверка остатка на складе
                        if (sellThing.kolvo == 0)
                        {
                            Console.WriteLine("Товара нет на складе!");
                            break;
                        }

                        int sellKolvo;

                        Console.Write("Сколько продать?: ");

                        if (!int.TryParse(Console.ReadLine(), out sellKolvo))
                        {
                            Console.WriteLine("Количество должно быть числом!");
                            break;
                        }

                        if (sellKolvo <= 0)
                        {
                            Console.WriteLine("Количество должно быть больше 0!");
                            break;
                        }

                        if (sellKolvo > sellThing.kolvo)
                        {
                            Console.WriteLine("Недостаточно товара! На складе только: " + sellThing.kolvo);
                            break;
                        }

                        sellThing.kolvo = sellThing.kolvo - sellKolvo;
                        sellThing.ObnovitNalichie();

                        Console.WriteLine("Продажа выполнена! Сумма покупки: " +
                            (sellKolvo * sellThing.cost) + " руб.");
                        break;

                    case 5:
                        Console.WriteLine();
                        Console.Write("Введите код, название или категорию: ");

                        string search = Console.ReadLine();

                        if (string.IsNullOrWhiteSpace(search))
                        {
                            Console.WriteLine("Пустой запрос!");
                            break;
                        }

                        bool found = false;

                        foreach (Thing t in tovary)
                        {
                            bool sovpadenie = false;

                            // ищем по коду
                            if (t.ID.ToString() == search)
                            {
                                sovpadenie = true;
                            }

                            // ищем по названию
                            if (t.name.ToLower() == search.ToLower())
                            {
                                sovpadenie = true;
                            }

                            // ищем по категории
                            if (t.category.ToString().ToLower() == search.ToLower())
                            {
                                sovpadenie = true;
                            }

                            if (sovpadenie)
                            {
                                Console.WriteLine();
                                t.ShowInfo();
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

        // Метод для вывода всех товаров списком
        static void Spisok()
        {
            if (tovary.Count == 0)
            {
                Console.WriteLine("Список товаров пуст.");
                return;
            }

            Console.WriteLine("Список товаров:");

            foreach (Thing t in tovary)
            {
                Console.WriteLine(t.ID + " " + t.name + " (" + t.category + ") - " +
                    t.cost + " руб, кол-во: " + t.kolvo);
            }
        }
    }

    class Thing
    {
        // лист что можно сделать
        public int ID;
        public string name;
        public int cost;
        public int kolvo;
        public bool nalichie;
        public Kategoriya category;

        // присвоение
        public Thing(int ID, string name, int cost, int kolvo, Kategoriya category)
        {
            this.ID = ID;
            this.name = name;
            this.cost = cost;
            this.kolvo = kolvo;
            this.category = category;
            this.nalichie = kolvo > 0; // если больше 0 - значит есть на складе
        }

        // Обновить поле "в наличии" (вызываем после продажи/поставки)
        public void ObnovitNalichie()
        {
            nalichie = kolvo > 0;
        }

        // Показать полную информацию о товаре
        public void ShowInfo()
        {
            Console.WriteLine("Информация о товаре");
            Console.WriteLine("Код: " + ID);
            Console.WriteLine("Название: " + name);
            Console.WriteLine("Цена: " + cost + " руб.");
            Console.WriteLine("Количество: " + kolvo);
            Console.WriteLine("В наличии: " + (nalichie ? "Да" : "Нет"));
            Console.WriteLine("Категория: " + category);
        }
    }
}

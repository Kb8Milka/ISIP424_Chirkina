using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISIP424_Chirkina
{
    // Перечесление жанров
    enum Genre
    {
        Психолгия,
        Детектив,
        Фантастика
    }

    internal class Program
    {
        // Список всех книг
        static List<Thing> tovary = new List<Thing>();

        // Счётчик индификатора
        static int ID = 1;

        static void Main(string[] args)
        {
            // Пять тестовых товаров
            // ID, название книги, цена, год, автор, жанр
            tovary.Add(new Thing(ID++, "Гарри Поттер и филосовский камень", 340, 2009, "Джоан Роулинг", Genre.Фантастика));
            tovary.Add(new Thing(ID++, "Гарри Поттер и тайная комната", 500, 1998, "Джоан Роулинг", Genre.Фантастика));
            tovary.Add(new Thing(ID++, "Десять негритят", 250, 2014, "Агата Кристи", Genre.Детектив));
            tovary.Add(new Thing(ID++, "Падение дома Ашеров", 304, 2026, "Эдгар Аллан По", Genre.Детектив));
            tovary.Add(new Thing(ID++, "Мудрость психопатов", 999, 2024, "Кевин Даттон", Genre.Психолгия));

            // меню
            int choice = -1;
            while (choice != 0)
            {
                Console.WriteLine();
                Console.WriteLine(" МЕНЮ: ");
                Console.WriteLine("1. Добавить книгу");
                Console.WriteLine("2. Удалить книгу по индификатору");
                Console.WriteLine("3. Отсортировать по названию или году");
                Console.WriteLine("4. Вывод самой дорогой и дешевой");
                Console.WriteLine("5. Поиск книги по автору");
                Console.WriteLine("6. Поиск книги по названию");
                Console.WriteLine("7. Поиск книги по жанру");
                Console.WriteLine("8. Сгруппировать книги по авторам и вывести количество книг каждого автора");
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
                        // добавление товара +
                        Console.WriteLine();
                        Console.WriteLine("Добавление книги");

                        Console.Write("Введите название книги: ");
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

                        int newYear;

                        Console.Write("Введите год: ");

                        if (!int.TryParse(Console.ReadLine(), out newYear))
                        {
                            Console.WriteLine("Год должен быть числом!");
                            break;
                        }
                        else if (newYear < 0)
                        {
                            Console.WriteLine("Год не может быть отрицательным!");
                            break;
                        }

                        Console.Write("Введите автора: ");
                        string newAvtor = Console.ReadLine();

                        if (string.IsNullOrWhiteSpace(newAvtor))
                        {
                            Console.WriteLine("Название не может быть пустым!");
                            break;
                        }

                        Console.WriteLine("Выберите жанр:");
                        Console.WriteLine("1. Психология");
                        Console.WriteLine("2. Детектив");
                        Console.WriteLine("3. Фантастика");

                        int katChoice;

                        if (!int.TryParse(Console.ReadLine(), out katChoice))
                        {
                            Console.WriteLine("Нужно ввести число!");
                            break;
                        }
                        else if (katChoice < 1 || katChoice > 3)
                        {
                            Console.WriteLine("Такой категории нет!");
                            break;
                        }

                        Genre newKat;

                        if (katChoice == 1)
                        {
                            newKat = Genre.Психолгия;
                        }
                        else if (katChoice == 2)
                        {
                            newKat = Genre.Детектив;
                        }
                        else
                        {
                            newKat = Genre.Фантастика;
                        }
                        
                        tovary.Add(new Thing(ID++, newName, newCost, newYear, newAvtor, newKat));
                        Console.WriteLine("Товар успешно добавлен! Код: " + (ID - 1));
                        break;

                    case 2:
                        // удаление по индификатору + 
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
                        // Отсортировать по названию или году +
                        Console.WriteLine();
                        Console.WriteLine("Выберите по чему вы хотите отсортировать: ");
                        Console.WriteLine("1. По названию");
                        Console.WriteLine("2. По году");

                        int Chose;

                        if (!int.TryParse(Console.ReadLine(), out Chose))
                        {
                            Console.WriteLine("Нужно ввести число!");
                            break;
                        }
                        else if (Chose < 1 || Chose > 2)
                        {
                            Console.WriteLine("Такого варианта нет!");
                            break;
                        }

                        if (Chose == 1)
                        {
                            // сортируем копию списка по названию от А до Я
                            List<Thing> sortirovka = tovary.OrderBy(t => t.name).ToList();

                            Console.WriteLine();
                            Console.WriteLine("Книги по алфавиту:");
                            foreach (Thing t in sortirovka)
                            {
                                Console.WriteLine(t.ID + " " + t.name + " " + t.avtorname + " " + t.year + " (" + t.category + ") - " +
                                    t.cost + " руб ");
                            }
                        }
                        else
                        {
                            // сортируем копию списка по году от старых к новым
                            List<Thing> sortirovka = tovary.OrderBy(t => t.year).ToList();

                            Console.WriteLine();
                            Console.WriteLine("Книги по году издания:");
                            foreach (Thing t in sortirovka)
                            {
                                Console.WriteLine(t.ID + " " + t.name + " " + t.avtorname + " " + t.year + " (" + t.category + ") - " +
                                    t.cost + " руб ");
                            }
                        }

                        break;

                    case 4:
                        // Вывод самой дорогой и дешевой +
                        Console.WriteLine();

                        if (tovary.Count == 0)
                        {
                            Console.WriteLine("Список книг пуст!");
                            break;
                        }

                        // сортируем по цене и берём первую книгу
                        Thing dorogaya = tovary.OrderByDescending(t => t.cost).FirstOrDefault();
                        Thing deshevaya = tovary.OrderBy(t => t.cost).FirstOrDefault();

                        Console.WriteLine("Самая дорогая книга:");
                        dorogaya.ShowInfo();
                        Console.WriteLine();
                        Console.WriteLine("Самая дешёвая книга:");
                        deshevaya.ShowInfo();

                        break;

                    case 5:
                        // Поиск книги
                        Console.WriteLine();
                        Console.Write("Введите автора: ");
                        List<Thing> 
                        List<Thing> tovary = tovary.Where(k => k.avtorname.ToLower().Contains(avtorname.ToLower())).ToList();

                        break;

                    case 6:
                        // Поиск книги
                        Console.WriteLine();
                        Console.Write("Введите название: ");
                        // поиск по названию
                       

                        break;

                    case 7:
                        // Поиск книги
                        Console.WriteLine();
                        Console.Write("Введите жанр: ");

                        // поиск по жанру
                        

                        break;

                    case 8:
                        // Сгруппировать книги по авторам и вывести количество книг каждого автора +
                        Console.WriteLine();

                        if (tovary.Count == 0)
                        {
                            Console.WriteLine("Список книг пуст!");
                            break;
                        }

                        // раскладываем книги по авторам
                        var gruppy = tovary.GroupBy(t => t.avtorname);

                        Console.WriteLine("Сколько книг у каждого автора:");
                        foreach (var gruppa in gruppy)
                        {
                            // gruppa.Key - это имя автора
                            // gruppa.Count() - сколько книг в этой группе
                            Console.WriteLine(gruppa.Key + " " + gruppa.Count() + " книг");
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
                Console.WriteLine(t.ID + " " + t.name + t.avtorname + t.year + " (" + t.category + ") - " +
                    t.cost + " руб ");
            }
        }
    }

    class Thing
    {
        // Что должно храниться: Уникальный идентификатор, Название, автор, Жанр, год издания, цена
        public int ID; 
        public string name;
        public string avtorname;
        public int cost;
        public int year;
        public Genre category;

        // присвоение
        public Thing(int ID, string name, int cost, int year, string avtorname, Genre category)
        {
            this.ID = ID;
            this.name = name;
            this.avtorname = avtorname;
            this.cost = cost;
            this.year = year;
            this.category = category;
        }

        // Показать полную информацию о товаре
        public void ShowInfo()
        {
            Console.WriteLine("Информация о товаре");
            Console.WriteLine("Индификатор: " + ID);
            Console.WriteLine("Название книги: " + name);
            Console.WriteLine("Автор: " + avtorname);
            Console.WriteLine("Год: " + year);
            Console.WriteLine("Цена: " + cost + " руб.");
            Console.WriteLine("Жанр: " + category);
        }
    }
}

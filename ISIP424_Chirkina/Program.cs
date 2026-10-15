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
                while (true)
                {
                    Console.WriteLine("ВЫБЕРИ: ");
                    Console.WriteLine("1. Добавить студента");
                    Console.WriteLine("2. Добавить преподавателя");
                    Console.WriteLine("3. Создать курс");
                    Console.WriteLine("4. Записать студента на курс");
                    Console.WriteLine("5. Показать всех студентов");
                    Console.WriteLine("6. Показать всех преподавателей");
                    Console.WriteLine("7. Показать все курсы");
                    Console.WriteLine("8. Курсы студента");
                    Console.WriteLine("9. Студенты курса");
                    Console.WriteLine("0. Выход");
                    Console.Write("Ваш выбор: ");

                    string choice = Console.ReadLine();
                    Console.WriteLine();

                    switch (choice)
                    {
                        case "1":

                            break;
                        case "2":

                            break;
                        case "3":

                            break;
                        case "4":

                            break;
                        case "5":

                            break;
                        case "6":

                            break;
                        case "7":

                            break;
                        case "8":

                            break;
                        case "9":

                            break;
                        case "0":
                            return;
                        default:
                            Console.WriteLine("Такого пункта нет!");
                            break;
                    }

                    Console.WriteLine();
                    Console.WriteLine("Нажмите Enter...");
                    Console.ReadLine();
                    Console.Clear();
                }
        }
    }
}

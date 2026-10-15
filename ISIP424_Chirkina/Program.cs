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
                            //Добавление студента
                            break;
                        case "2":
                            // Добавление препода
                            break;
                        case "3":
                            // создание курса
                            break;
                        case "4":
                            // записать студента на курс
                            break;
                        case "5":
                            // все студенты
                            break;
                        case "6":
                            // все преподы
                            break;
                        case "7":
                            // все курсы
                            break;
                        case "8":
                            // курсы студента
                            break;
                        case "9":
                            // студенты курса
                            break;
                        case "0":
                            return;
                        default:
                            Console.WriteLine("Такого пункта нет!");
                            break;
                    }
                }
        }

        // Классы
        // класс просто человека
        class Person
        {
            public string Name;
            public int Age;

            public void Print()
            {
                Console.WriteLine("Имя: " + Name + ", возраст: " + Age);
            }
        }

        // класс студента
        class Student : Person
        {
            public string Group;
            public List<Course> MyCourses = new List<Course>();

            public void Print()
            {
                Console.WriteLine(Name + ", " + Age + " лет, группа " + Group);
            }
        }

        // Преподаватель
        class Teacher : Person
        {
            public string Subject;
        }

        // курс
        class Course
        {
            public string Title;
            public Teacher Teacher;
            public List<Student> Students = new List<Student>();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISIP424_Chirkina
{
    internal class Program
    {
        // Списки для хранения данных
        static List<Student> students = new List<Student>();
        static List<Teacher> teachers = new List<Teacher>();
        static List<Course> courses = new List<Course>();

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
                            AddStudent();
                            break;
                        case "2":
                            // Добавление препода
                            AddTeacher();
                            break;
                        case "3":
                            // создание курса
                            AddCourse();
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

        // Добавления студентов, преподов, курсов:
        static void AddStudent()
        {
            Student s = new Student();

            Console.Write("Имя: ");
            s.Name = Console.ReadLine();
            if (s.Name == "")
            {
                Console.WriteLine("Имя не может быть пустым!");
                return;
            }

            Console.Write("Возраст: ");
            if (!int.TryParse(Console.ReadLine(), out s.Age) || s.Age <= 0)
            {
                Console.WriteLine("Возраст должен быть положительным числом!");
                return;
            }

            Console.Write("Группа: ");
            s.Group = Console.ReadLine();
            if (s.Group == "")
            {
                Console.WriteLine("Группа не может быть пустой!");
                return;
            }

            students.Add(s);
            Console.WriteLine("Студент добавлен!");
        }

        static void AddTeacher()
        {
            Teacher t = new Teacher();

            Console.Write("Имя: ");
            t.Name = Console.ReadLine();
            if (t.Name == "")
            {
                Console.WriteLine("Имя не может быть пустым!");
                return;
            }

            Console.Write("Возраст: ");
            if (!int.TryParse(Console.ReadLine(), out t.Age) || t.Age <= 0)
            {
                Console.WriteLine("Возраст должен быть положительным числом!");
                return;
            }

            Console.Write("Предмет: ");
            t.Subject = Console.ReadLine();
            if (t.Subject == "")
            {
                Console.WriteLine("Предмет не может быть пустым!");
                return;
            }

            teachers.Add(t);
            Console.WriteLine("Преподаватель добавлен!");
        }

        static void AddCourse()
        {
            if (teachers.Count == 0)
            {
                Console.WriteLine("Сначала добавьте преподавателя!");
                return;
            }

            Course c = new Course();

            Console.Write("Название курса: ");
            c.Title = Console.ReadLine();
            if (c.Title == "")
            {
                Console.WriteLine("Название не может быть пустым!");
                return;
            }

            Console.WriteLine("Выберите преподавателя:");
            for (int i = 0; i < teachers.Count; i++)
                Console.WriteLine((i + 1) + ". " + teachers[i].Name);

            int num;
            if (!int.TryParse(Console.ReadLine(), out num) || num < 1 || num > teachers.Count)
            {
                Console.WriteLine("Неверный номер!");
                return;
            }

            c.Teacher = teachers[num - 1];
            courses.Add(c);
            Console.WriteLine("Курс создан!");
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

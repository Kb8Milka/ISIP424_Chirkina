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
            // 3 преподавателя
            teachers.Add(new Teacher("Иванов И.И.", 45, "Математика"));
            teachers.Add(new Teacher("Петрова А.С.", 38, "Программирование"));
            teachers.Add(new Teacher("Сидоров П.В.", 52, "Физика"));

            // 3 курса
            courses.Add(new Course("Алгебра", teachers[0]));
            courses.Add(new Course("Основы C#", teachers[1]));
            courses.Add(new Course("Механика", teachers[2]));

            // 3 студента
            students.Add(new Student("Смирнова А.К.", 19, "ИТ-101"));
            students.Add(new Student("Козлов Д.М.", 20, "ИТ-101"));
            students.Add(new Student("Волкова Е.Н.", 18, "ИТ-102"));

            // Добавляем студентов на курс
            students[0].MyCourses.Add(courses[1]); // Смирнова -> Основы C#
            courses[1].Students.Add(students[0]);

            students[1].MyCourses.Add(courses[1]); // Козлов -> Основы C#
            courses[1].Students.Add(students[1]);
            students[1].MyCourses.Add(courses[0]); // Козлов -> Алгебра
            courses[0].Students.Add(students[1]);

            students[2].MyCourses.Add(courses[2]); // Волкова -> Механика
            courses[2].Students.Add(students[2]);

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
                        EnrollStudent();
                        break;
                    case "5":
                        // все студенты
                        ShowStudents();
                        break;
                    case "6":
                        // все преподы
                        ShowTeachers();
                        break;
                    case "7":
                        // все курсы
                        ShowCourses();
                        break;
                    case "8":
                        // курсы студента
                        ShowStudentCourses();
                        break;
                    case "9":
                        // студенты курса
                        ShowCourseStudents();
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
            Console.Write("Имя: ");
            string name = Console.ReadLine();
            if (name == "")
            {
                Console.WriteLine("Имя не может быть пустым!");
                return;
            }

            Console.Write("Возраст: ");
            int age;
            if (!int.TryParse(Console.ReadLine(), out age) || age <= 0)
            {
                Console.WriteLine("Возраст должен быть положительным числом!");
                return;
            }

            Console.Write("Группа: ");
            string group = Console.ReadLine();
            if (group == "")
            {
                Console.WriteLine("Группа не может быть пустой!");
                return;
            }

            // создаём студента
            students.Add(new Student(name, age, group));
            Console.WriteLine("Студент добавлен!");
        }

        static void AddTeacher()
        {
            Console.Write("Имя: ");
            string name = Console.ReadLine();
            if (name == "")
            {
                Console.WriteLine("Имя не может быть пустым!");
                return;
            }

            Console.Write("Возраст: ");
            int age;
            if (!int.TryParse(Console.ReadLine(), out age) || age <= 0)
            {
                Console.WriteLine("Возраст должен быть положительным числом!");
                return;
            }

            Console.Write("Предмет: ");
            string subject = Console.ReadLine();
            if (subject == "")
            {
                Console.WriteLine("Предмет не может быть пустым!");
                return;
            }

            // создаём преподавателя
            teachers.Add(new Teacher(name, age, subject));
            Console.WriteLine("Преподаватель добавлен!");
        }

        static void AddCourse()
        {
            if (teachers.Count == 0)
            {
                Console.WriteLine("Сначала добавьте преподавателя!");
                return;
            }

            Console.Write("Название курса: ");
            string title = Console.ReadLine();
            if (title == "")
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

            // создаём курс сразу с названием и выбранным преподавателем
            courses.Add(new Course(title, teachers[num - 1]));
            Console.WriteLine("Курс создан!");
        }

        // Запись студента на курс
        static void EnrollStudent()
        {
            if (students.Count == 0 || courses.Count == 0)
            {
                Console.WriteLine("Нужен хотя бы один студент и один курс!");
                return;
            }

            // выбираем студента
            ShowStudents();
            Console.Write("Номер студента: ");
            int snum;
            if (!int.TryParse(Console.ReadLine(), out snum) || snum < 1 || snum > students.Count)
            {
                Console.WriteLine("Неверный номер!");
                return;
            }

            // выбираем курс
            ShowCourses();
            Console.Write("Номер курса: ");
            int cnum;
            if (!int.TryParse(Console.ReadLine(), out cnum) || cnum < 1 || cnum > courses.Count)
            {
                Console.WriteLine("Неверный номер!");
                return;
            }

            // связываем их друг с другом
            Student st = students[snum - 1];
            Course co = courses[cnum - 1];

            co.Students.Add(st);     // студент теперь в списке курса
            st.MyCourses.Add(co);    // курс теперь в списке студента

            Console.WriteLine("Студент записан на курс!");
        }

        // Показать всех студентов
        static void ShowStudents()
        {
            if (students.Count == 0)
            {
                Console.WriteLine("Студентов нет.");
                return;
            }

            for (int i = 0; i < students.Count; i++)
                Console.WriteLine((i + 1) + ". " + students[i].Name + ", " + students[i].Age + " лет, группа " + students[i].Group);
        }

        // Показать всех преподов
        static void ShowTeachers()
        {
            if (teachers.Count == 0)
            {
                Console.WriteLine("Преподавателей нет.");
                return;
            }

            for (int i = 0; i < teachers.Count; i++)
                Console.WriteLine((i + 1) + ". " + teachers[i].Name + ", " + teachers[i].Age + " лет, предмет " + teachers[i].Subject);
        }

        // Показать все курсы
        static void ShowCourses()
        {
            if (courses.Count == 0)
            {
                Console.WriteLine("Курсов нет.");
                return;
            }

            for (int i = 0; i < courses.Count; i++)
                Console.WriteLine((i + 1) + ". " + courses[i].Title + ", ведет " + courses[i].Teacher.Name);
        }

        // Курсы конкретного студента
        static void ShowStudentCourses()
        {
            if (students.Count == 0)
            {
                Console.WriteLine("Студентов нет.");
                return;
            }

            ShowStudents();
            Console.Write("Номер студента: ");
            int num;
            if (!int.TryParse(Console.ReadLine(), out num) || num < 1 || num > students.Count)
            {
                Console.WriteLine("Неверный номер!");
                return;
            }

            Student st = students[num - 1];

            if (st.MyCourses.Count == 0)
            {
                Console.WriteLine("Этот студент ни на один курс не записан.");
                return;
            }

            for (int i = 0; i < st.MyCourses.Count; i++)
                Console.WriteLine("- " + st.MyCourses[i].Title);
        }

        // Студенты конкретного курса
        static void ShowCourseStudents()
        {
            if (courses.Count == 0)
            {
                Console.WriteLine("Курсов нет.");
                return;
            }

            ShowCourses();
            Console.Write("Номер курса: ");
            int num;
            if (!int.TryParse(Console.ReadLine(), out num) || num < 1 || num > courses.Count)
            {
                Console.WriteLine("Неверный номер!");
                return;
            }

            Course co = courses[num - 1];

            if (co.Students.Count == 0)
            {
                Console.WriteLine("На этот курс никто не записан.");
                return;
            }

            for (int i = 0; i < co.Students.Count; i++)
                Console.WriteLine("- " + co.Students[i].Name);
        }

        // Классы
        // класс просто человека
        class Person
        {
            public string Name;
            public int Age;

            public Person(string name, int age)
            {
                Name = name;
                Age = age;
            }

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

            public Student(string name, int age, string group) : base(name, age)
            {
                Group = group;
            }

            public void Print()
            {
                Console.WriteLine(Name + ", " + Age + " лет, группа " + Group);
            }
        }

        // Преподаватель
        class Teacher : Person
        {
            public string Subject;

            public Teacher(string name, int age, string subject) : base(name, age)
            {
                Subject = subject;
            }
        }

        // курс
        class Course
        {
            public string Title;
            public Teacher Teacher;
            public List<Student> Students = new List<Student>();

            public Course(string title, Teacher teacher)
            {
                Title = title;
                Teacher = teacher;
            }
        }
    }
}
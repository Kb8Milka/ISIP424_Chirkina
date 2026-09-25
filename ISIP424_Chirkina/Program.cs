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
            int choice = -1;
            while (choice != 0)
            {
                Console.WriteLine();
                Console.WriteLine("     МЕНЮ:   ");
                Console.WriteLine("1. Новое предложение и его статистика");
                Console.WriteLine("2. Статистика по прошлым текстам");
                Console.WriteLine("0. Выход");
                Console.WriteLine();
                Console.WriteLine("Выберете пункт: ");
                choice = Convert.ToInt32(Console.ReadLine());

                // выбор
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Введите новое предложение(минимум 100 символов): ");
                        Console.WriteLine("Количество слов в тексте: ");
                        Console.WriteLine("Самое короткое слово: ");
                        Console.WriteLine("Количество предложений: ");
                        Console.WriteLine("Количество гласных и согласных: ");
                        Console.WriteLine("Самое длинное слово: ");
                        Console.WriteLine("Статистика по частоте встречаемости каждой буквы: ");
                        Console.WriteLine("Количество гласных и согласных: ");
                        break;
                    case 2:
                        Console.WriteLine("Статистика по прошлым текстам: ");
                        break;
                    default:

                }
    }
}

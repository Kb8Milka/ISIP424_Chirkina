using System;
using System.Collections.Generic;

namespace ISIP424_Chirkina
{
    // наша статистика
    class Statistica
    {
        public string Text = "";
        public int Words = 0;
        public string ShortWord = "";
        public string LongWord = "";
        public int Sentences = 0;
        public int Vowels = 0;
        public int Consonants = 0;
        public string AllLetters = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";
        public int[] LetterCounts = new int[33];
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            // лист с историей, куда будут складываться предложения
            List<Statistica> history = new List<Statistica>();

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

                switch (choice)
                {
                    case 1:
                        // создание нового предложения
                        string text = "";
                        while (text.Length < 100)
                        {
                            Console.WriteLine("Введите новое предложение (минимум 100 символов): ");
                            text = Console.ReadLine();
                            if (text.Length < 100)
                            {
                                Console.WriteLine("Ошибка! Нужно минимум 100 символов. Попробуйте снова.");
                            }
                        }

                        Statistica st = new Statistica();
                        st.Text = text;

                        // заменяем знаки препинания на пробелы
                        // массив символов, в котором лежат все знаки препинания, которые надо убрать
                        char[] znaki = { '.', ',', '!', '?', ';', ':', '-', '"', '\'', '(', ')' };
                        string cleanText = "";
                        // заменяем в тексте все знаки препинания на пробелы
                        for (int i = 0; i < text.Length; i++)
                        {
                            char c = text[i];
                            bool etoZnak = false;
                            for (int j = 0; j < znaki.Length; j++)
                            {
                                if (c == znaki[j])
                                {
                                    // помечаем: да, это знак препинания
                                    etoZnak = true;
                                }
                            }
                            if (etoZnak)
                            {
                                cleanText = cleanText + " ";
                            }
                            else
                            {
                                cleanText = cleanText + c;
                            }
                        }

                        // режем получившийся текст на слова по пробелам
                        List<string> words = new List<string>();
                        string word = "";
                        for (int i = 0; i < cleanText.Length; i++)
                        {
                            char c = cleanText[i];
                            if (c == ' ')
                            {
                                if (word != "")
                                {
                                    words.Add(word);
                                    word = "";
                                }
                            }
                            else
                            {
                                word = word + c;
                            }
                        }
                        if (word != "")
                        {
                            words.Add(word);
                        }

                        // записываем в статистику количество слов — берём размер списка words
                        st.Words = words.Count;

                        // короткое и длинное слово
                        string shortest = words[0];
                        string longest  = words[0];
                        for (int i = 0; i < words.Count; i++)
                        {
                            if (words[i].Length < shortest.Length) shortest = words[i];
                            if (words[i].Length > longest.Length)  longest  = words[i];
                        }
                        st.ShortWord = shortest;
                        st.LongWord = longest;

                        // предложения
                        int sentences = 0;
                        for (int i = 0; i < text.Length; i++)
                        {
                            if (text[i] == '.' || text[i] == '!' || text[i] == '?')
                            {
                                sentences = sentences + 1;
                            }
                        }
                        st.Sentences = sentences;

                        // гласные и согласные
                        string glasnye   = "аеёиоуыэюяАЕЁИОУЫЭЮЯ";
                        string soglasnye = "бвгджзйклмнпрстфхцчшщБВГДЖЗЙКЛМНПРСТФХЦЧШЩ";
                        int gl = 0;
                        int sg = 0;
                        for (int i = 0; i < text.Length; i++)
                        {
                            char ch = text[i];
                            for (int j = 0; j < glasnye.Length; j++)
                            {
                                if (ch == glasnye[j]) gl = gl + 1;
                            }
                            for (int j = 0; j < soglasnye.Length; j++)
                            {
                                if (ch == soglasnye[j]) sg = sg + 1;
                            }
                        }
                        st.Vowels = gl;
                        st.Consonants = sg;

                        // частота букв
                        for (int i = 0; i < text.Length; i++)
                        {
                            char ch = char.ToLower(text[i]);
                            for (int j = 0; j < st.AllLetters.Length; j++)
                            {
                                if (ch == st.AllLetters[j])
                                {
                                    st.LetterCounts[j] = st.LetterCounts[j] + 1;
                                }
                            }
                        }

                        history.Add(st);

                        // вывод
                        Console.WriteLine();
                        Console.WriteLine("Количество слов в тексте: " + st.Words);
                        Console.WriteLine("Самое короткое слово: " + st.ShortWord);
                        Console.WriteLine("Количество предложений: " + st.Sentences);
                        Console.WriteLine("Количество гласных: " + st.Vowels);
                        Console.WriteLine("Количество согласных: " + st.Consonants);
                        Console.WriteLine("Самое длинное слово: " + st.LongWord);
                        Console.WriteLine("Статистика по частоте встречаемости каждой буквы: ");
                        for (int i = 0; i < st.AllLetters.Length; i++)
                        {
                            if (st.LetterCounts[i] > 0)
                            {
                                Console.WriteLine("  " + st.AllLetters[i] + " - " + st.LetterCounts[i]);
                            }
                        }
                        break;

                    case 2:
                        // Статистика по прошлым текстам:
                        Console.WriteLine("Статистика по прошлым текстам: ");
                        if (history.Count == 0)
                        {
                            Console.WriteLine("Пока нет сохранённых текстов.");
                        }
                        else
                        {
                            for (int i = 0; i < history.Count; i++)
                            {
                                Console.WriteLine();
                                Console.WriteLine("Текст №" + (i + 1));
                                Console.WriteLine("Сам текст: " + history[i].Text);
                                Console.WriteLine("Количество слов: " + history[i].Words);
                                Console.WriteLine("Самое короткое слово: " + history[i].ShortWord);
                                Console.WriteLine("Самое длинное слово: " + history[i].LongWord);
                                Console.WriteLine("Количество предложений: " + history[i].Sentences);
                                Console.WriteLine("Гласных: " + history[i].Vowels);
                                Console.WriteLine("Согласных: " + history[i].Consonants);
                                Console.WriteLine("Частота букв: ");
                                for (int j = 0; j < history[i].AllLetters.Length; j++)
                                {
                                    if (history[i].LetterCounts[j] > 0)
                                    {
                                        Console.WriteLine("  " + history[i].AllLetters[j] + " - " + history[i].LetterCounts[j]);
                                    }
                                }
                            }
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



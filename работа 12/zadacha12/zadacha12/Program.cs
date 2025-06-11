
using System;
using System.Collections.Generic;
using System.IO;
using System.Collections.Generic;
using System.IO;

namespace zadacha12
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ConsoleKeyInfo keyInfo;

            do
            {
                Console.Clear();
                // Выводит главное меню с инструкцией для пользователя
                Console.WriteLine("Нажмите 'S' для запуска программы или 'Q' для выхода.");

                // Считывает нажатую клавишу без отображения в консоли
                keyInfo = Console.ReadKey(true);

                // Если нажата клавиша 'S', запускается основная логика программы
                if (keyInfo.Key == ConsoleKey.S)
                {
                    RunProgram();
                    Console.WriteLine();
                    Console.WriteLine("Нажмите любую клавишу для возврата в меню...");
                    // Ожидает нажатия клавиши для возврата в меню
                    Console.ReadKey(true);
                }

            } while (keyInfo.Key != ConsoleKey.Q);
            // Повторяет цикл до тех пор, пока пользователь не нажмёт 'Q' для выхода
        }

        static void RunProgram()
        {
            // Формирует путь к файлу chisla.txt в директории запуска приложения
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "chisla.txt");

            // Проверяет существование файла, если файла нет — сообщает и завершает метод
            if (!File.Exists(filePath))
            {
                Console.WriteLine("Файл chisla.txt не найден.");
                return;
            }

            // Считывает весь текст из файла
            string content = File.ReadAllText(filePath);

            // Разделяет содержимое файла по запятым, получая массив строк
            string[] parts = content.Split(',');

            // Создаёт список для хранения чисел из файла
            List<int> numbers = new List<int>();

            // Переменная для суммы чисел, которые не будут выведены (не каждое третье)
            int sumSkipped = 0;

            // Обрабатывает каждую полученную строку
            foreach (string part in parts)
            {
                string trimmed = part.Trim(); // Удаляет пробелы по краям
                if (trimmed != "")
                {
                    // Попытка преобразовать строку в число, если успешно — добавляет в список
                    if (int.TryParse(trimmed, out int num))
                    {
                        numbers.Add(num);
                    }
                }
            }

            Console.WriteLine("Каждое третье число:");

            // Перебирает все числа
            for (int i = 0; i < numbers.Count; i++)
            {
                // Проверяет, является ли число "каждым третьим" (считая с 1)
                if ((i + 1) % 3 == 0)
                {
                    Console.Write(numbers[i]); // Выводит это число

                    // Добавляет точку с запятой после числа, если не пос

                 if (i + 3 < numbers.Count)
                    {
                        Console.Write(";");
                    }
                }
                else
                {
                    // Суммирует числа, которые не выводятся
                    sumSkipped += numbers[i];
                }
            }

            Console.WriteLine();
            Console.WriteLine();
            // Выводит сумму пропущенных чисел
            Console.WriteLine("Сумма пропущенных чисел: " + sumSkipped);
        }
    }
}

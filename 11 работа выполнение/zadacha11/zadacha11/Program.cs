
using System;



class Program
{
    // Функция для печати матрицы "змейкой"
    // startFromBottomRight = true - начать с нижнего правого угла
    // startFromBottomRight = false - начать с верхнего левого угла
    static void _bPrintSnake(int[,] matrix, bool startFromBottomRight)
    {
        int rows = matrix.GetLength(0); // количество строк
        int cols = matrix.GetLength(1); // количество столбцов

        // Определяем максимальную длину строки среди всех элементов для выравнивания вывода
        int maxWidth = 0;
        foreach (var item in matrix)
        {
            int len = item.ToString().Length;
            if (len > maxWidth) maxWidth = len;
        }

        if (startFromBottomRight)
        {
            // Обход строк с нижней вверх
            for (int i = rows - 1; i >= 0; i--)
            {

                Console.Write("| ");
                // Чередуем направление обхода столбцов для "змейки"
                if ((rows - 1 - i) % 2 == 0)
                {
                    for (int j = cols - 1; j >= 0; j--)
                        Console.Write(matrix[i, j].ToString().PadLeft(maxWidth) + " ");
                }
                else
                {
                    for (int j = 0; j < cols; j++)
                        Console.Write(matrix[i, j].ToString().PadLeft(maxWidth) + " ");
                }
                Console.WriteLine("|");
            }
        }
        else
        {
            // Обход строк сверху вниз
            for (int i = 0; i < rows; i++)
            {
                Console.Write("| ");
                // Чередуем направление обхода столбцов для "змейки"
                if (i % 2 == 0)
                {
                    for (int j = 0; j < cols; j++)
                        Console.Write(matrix[i, j].ToString().PadLeft(maxWidth) + " ");
                }
                else
                {
                    for (int j = cols - 1; j >= 0; j--)
                        Console.Write(matrix[i, j].ToString().PadLeft(maxWidth) + " ");
                }
                Console.WriteLine("|");
            }
        }
    }

    // Функция для ввода элементов квадратной матрицы заданного размера
    static int[,] _breadMatrix(int size)
    {
        int vvod = 0;
        int[,] matrix = new int[size, size];

        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                Console.Write($"Элемент [{i},{j}]: ");
                // Проверка корректности ввода (целое число)
                while (!int.TryParse(Console.ReadLine(), out vvod))
                    Console.WriteLine("Ошибка! Введите целое положительное число:");
                matrix[i, j] = vvod;
            }
        }
        return matrix;
    }

    static void Main()
    {
        Console.Write("Введите размер двухмерного массива (n): ");
        int n = 0;
        // Проверка корректности ввода размера массива
        while (!int.TryParse(Console.ReadLine(), out n) || n <= 0)
            Console.WriteLine("Ошибка! Введите целое положительное число:");

        Console.WriteLine("Введите элементы матрицы:");
        int[,] matrix = _breadMatrix(n);

        Console.WriteLine("Начать змейку с верхнего левого угла ? (true / false) : ");
        string pos = Console.ReadLine();

        if (pos == "true")
        {
            // Старт с верхнего левого угла
            Console.WriteLine("Печать с верхнего левого угла:");
            _bPrintSnake(matrix, false);
        }
        else if (pos == "false")
        {
            // Старт с нижнего правого угла
            Console.WriteLine("Печать с нижнего правого угла:");
            _bPrintSnake(matrix, true);
        }
        else
        {
            Console.WriteLine("Ошибка: введите 'true' или 'false'.");
        }

        Console.ReadKey();
    }
}



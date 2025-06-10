using System;

class Program
{
    static void Main()
    {
        // Блок объявления всех переменных
        int size;                // Размер квадратных матриц
        double[,] userMatrix1;     // Пользовательская матрица A
        double[,] userMatrix2;     // Пользовательская матрица B

        // Основной код программы

        // Ввод размера матрицы
        Console.Write("Введите размер квадратной матрицы: ");
        while (!int.TryParse(Console.ReadLine(), out size) || size <= 0)
            Console.WriteLine("Ошибка! Введите целое положительное число: ");

        // Ввод элементов матрицы A
        userMatrix1 = new double[size, size];
        Console.WriteLine("Введите элементы матрицы А:");
        for (int i = 0; i < size; i++)
            for (int j = 0; j < size; j++)
            {
                Console.Write($"Элемент [{i + 1},{j + 1}]: ");
                while (!double.TryParse(Console.ReadLine(), out userMatrix1[i, j]))
                    Console.WriteLine("Ошибка! Введите число: ");
            }

        // Ввод элементов матрицы B
        userMatrix2 = new double[size, size];
        Console.WriteLine("Введите элементы матрицы В" +
            " :");
        for (int i = 0; i < size; i++)
            for (int j = 0; j < size; j++)
            {
                Console.Write($"Элемент [{i + 1},{j + 1}]: ");
                while (!double.TryParse(Console.ReadLine(), out userMatrix2[i, j]))
                    Console.WriteLine("Ошибка! Введите число: ");
            }

        // Вычисление результата матрицы А
        for (int i = 0; i < size; i++)
            for (int j = 0; j < size; j++)
                if (i != j)
                {
                    userMatrix2[i, j] = userMatrix1[i, j];
                    userMatrix1[i, j] = -1;
                }

        // Вывод результатов
        Console.WriteLine(" матрица A:");
        for (int i = 0; i < size; i++)
        {
            Console.Write("|");
            for (int j = 0; j < size; j++)
                Console.Write($"{userMatrix1[i, j],6:F2}");
            Console.WriteLine(" |");
        }

        Console.WriteLine("\nМатрица В:");
        for (int i = 0; i < size; i++)
        {
            Console.Write("|");
            for (int j = 0; j < size; j++)
                Console.Write($"{userMatrix2[i, j],6:F2}");
            Console.WriteLine(" |");
        }

        Console.ReadKey(true);
    }
}

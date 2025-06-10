using System;
using System.Security.Cryptography;

namespace WeekDaysEnum
{
    // Перечисление состояний заказа
    enum DodoStatus
    {
        accepted = 0xf,
        cooking_in_the_kitchen = 0xe,
        cooked = 0xd,
        handed_over_to_the_courier = 0xc,
        on_the_way = 0xB,
        delivered = 0xa,
        rate_our_establishment = 0x9
    }

    class Program
    {
        static void Main(string[] args)
        {
            Random rnd= new Random();
            double live = 0;
            DodoStatus status = DodoStatus.accepted;

            // Цикл с предусловием: выполняется, пока currentDay >= 1
            while ((int)status >= 0x9)
            {
                int x = 0;
                int y = 1000000000;
                while (x < y)
                    x += 1;
                int z = rnd.Next(y*(-1), 1000000000);
                y += z;

                // Преобразование числа в элемент перечисления DodoStatus
                //DodoStatus one = (DodoStatus)status;
                // Вывод названия дня
                Console.WriteLine(status);
                // Уменьшение значения для перехода к следующему cтатусу
                status--;
            }

            
            while (true)
            {
                Console.Write("поставьте оценку: ");
                if (double.TryParse(Console.ReadLine(), out live))
                    break;
                else { Console.WriteLine("Ошибка! Введите числовую оценку! Попробуйте ещё раз"); }



            }
            Console.WriteLine("thanks");
            Console.ReadKey();
        }
        }
    }


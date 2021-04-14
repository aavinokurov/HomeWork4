using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise1
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random(); // Генератор случайных чисел

            int[,] financeTable = new int[12, 4]; // Таблица финансов

            int countPositiveProfit = 0; // Кол-во месяцев с положительной прибылью

            int[] profit = new int[12]; // Массив с прибылью
            int[] month = new int[12]; // Массив месяцев

            Console.WriteLine($"{"Месяц",10}|{"Доход",10}|{"Расход",10}|{"Прибыль",10}|"); // Шапка таблицы

            for (int i = 0; i < 12; i++) // Заполнение элементов массива
            {
                financeTable[i, 0] = i + 1; // Месяц

                month[i] = financeTable[i, 0]; // Добавление в массив с месяцами

                financeTable[i, 1] = rnd.Next(4); // Доход за месяц. Случайное число от 0 до 100

                financeTable[i, 2] = rnd.Next(4); // Расход за месяц. Случайное число от 0 до 100

                financeTable[i, 3] = financeTable[i, 1] - financeTable[i, 2]; // Прибыль

                profit[i] = financeTable[i, 3]; // Добавление в массив с прибылью

                if (financeTable[i, 3] > 0) // Подсчет месяцев с положительной прибылью
                {
                    countPositiveProfit++;
                }

                for (int j = 0; j < 4; j++) // Вывод в консоль строки
                {
                    Console.Write($"{financeTable[i, j], 10}|");
                }

                Console.WriteLine(); // Переход на следующую строку
            }

            Console.WriteLine($"Месяцев с положительной прибылью: {countPositiveProfit}"); // Вывод кол-во месяцев с положительной прибылью

            Console.WriteLine("Месяцы с наименьшей прибылью: "); // Вывод таблицы трех месяцев с наименьшей прибылью
            Console.WriteLine($"{"Месяц",10}|{"Прибыль",10}|"); // Вывод шапки таблицы

            Array.Sort(profit, month); // Отсортировать массив прибыли

            int indexLeastProfit = 0; // Кол-во значений с наименьшей прибылью

            for (int i = 0; i < 12; i++) // Формирование таблицы с наименьшей прибылью
            {
                if (i != 0 && profit[i - 1] != profit[i]) // Если текущее значение неравно предыдущему, то увеличиваем счетчик значений
                {
                    indexLeastProfit++;
                }

                if (indexLeastProfit == 3) // Если в таблице три значения заканчиваем цикл
                {
                    break;
                }

                Console.WriteLine($"{month[i],10}|{profit[i],10}|"); // Вывод строки таблицы
            }
        }
    }
}

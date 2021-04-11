using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise2
{
    class Program
    {
        static void Main(string[] args)
        {
            int n; // Кол-во строк в треугольнике Паскаля

            do
            {
                Console.WriteLine("Введите количество строк в треугольнике Паскаля (значение больше 0): "); // Просим пользователя ввести кол-во строк
                n = Convert.ToInt32(Console.ReadLine()); // Считываем с консоли кол-во строк
            } while (n <= 0); // Просим до тех пор пока значение будет больше 0

            int[][] trianglePascal = new int[n][]; // массив для хранения значений треугольника Паскаля

            int space = n; // кол-во пробелов

            for (int i = 0; i < trianglePascal.Length; i++) // Цикл для заполнения значений
            {
                trianglePascal[i] = new int[i + 1]; // Создание строки

                for (int k = 0; k < space; k++) // Вывод пробелов перед строкой
                {
                    Console.Write(" ");
                }

                for (int j = 0; j < trianglePascal[i].Length; j++) // Заполнение значений i-ой строки
                {
                    if (j == 0 || j == trianglePascal[i].Length - 1) // Если это крайний элемент, то он равен 1
                    {
                        trianglePascal[i][j] = 1;
                    }
                    else
                    {
                        trianglePascal[i][j] = trianglePascal[i - 1][j - 1] + trianglePascal[i - 1][j]; // Если это не крайний элемент, то он равен сумме 
                                                                                                            // двух расположенных над ним чисел
                    }

                    Console.Write($"{trianglePascal[i][j], 3}"); // Вывод значения в консоль
                }

                space--; // Уменьшение кол-ва пробелов

                Console.WriteLine(); // Перевод на новую строку
            }
        }
    }
}

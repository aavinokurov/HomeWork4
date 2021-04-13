using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise3
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random(); // Генератор случайных чисел
            int row1; // Кол-во строк первой матрицы
            int column1; // Кол-во столбцов первой матрицы

            do
            {
                do
                {
                    Console.WriteLine("Введите количество строк первой матрицы: "); // Просим пользователя ввести кол-во строк у первой матрицы
                } while (!Int32.TryParse(Console.ReadLine(), out row1)); // Преобразуем строку в целое число
            } while (row1 <= 0); // Если пользователь ввел значение меньше или равное 0

            do
            {
                do
                {
                    Console.WriteLine("Введите количество столбцов первой матрицы: "); // Просим пользователя ввести кол-во столбцов у первой матрицы
                } while (!Int32.TryParse(Console.ReadLine(), out column1)); // Преобразуем строку в целое число
            } while (column1 <= 0); // Если пользователь ввел значение меньше или равное 0

            int[,] matrixA = new int[row1, column1]; // Первая матрица

            for (int i = 0; i < row1; i++) // Инициализация элементов первой матрицы случайными числами от 0 до 9
            {
                for (int j = 0; j < column1; j++)
                {
                    matrixA[i, j] = rnd.Next(10);
                }
            }

            int row2; // Кол-во строк первой матрицы
            int column2; // Кол-во столбцов первой матрицы

            do
            {
                do
                {
                    Console.WriteLine("Введите количество строк второй матрицы: "); // Просим пользователя ввести кол-во строк у второй матрицы
                } while (!Int32.TryParse(Console.ReadLine(), out row2)); // Преобразуем строку в целое число
            } while (row2 <= 0); // Если пользователь ввел значение меньше или равное 0

            do
            {
                do
                {
                    Console.WriteLine("Введите количество столбцов второй матрицы: "); // Просим пользователя ввести кол-во столбцов у второй матрицы
                } while (!Int32.TryParse(Console.ReadLine(), out column2)); // Преобразуем строку в целое число
            } while (column2 <= 0); // Если пользователь ввел значение меньше или равное 0

            int[,] matrixB = new int[row2, column2]; // Вторая матрица

            for (int i = 0; i < row2; i++) // Инициализация элементов второй матрицы случайными числами от 0 до 9
            {
                for (int j = 0; j < column2; j++)
                {
                    matrixB[i, j] = rnd.Next(10);
                }
            }

            int numOperation; // Номер операции

            do
            {
                Console.Clear(); // Очистить консоль от предыдущих значений

                Console.WriteLine("Матрицы А:");

                for (int i = 0; i < row1; i++) // Вывод в консоль матрицы А
                {
                    for (int j = 0; j < column1; j++)
                    {
                        Console.Write($"{matrixA[i, j],3}");
                    }
                    Console.WriteLine();
                }

                Console.WriteLine("Матрицы B:");

                for (int i = 0; i < row2; i++) // Вывод в консоль матрицы B
                {
                    for (int j = 0; j < column2; j++)
                    {
                        Console.Write($"{matrixB[i, j],3}");
                    }
                    Console.WriteLine();
                }

                Console.WriteLine("Операции:\n" +                    // Вывод пользователю доступные операции
                                  "1 - Умножение матрицы на число\n" +
                                  "2 - Сложение и вычитание матриц\n" +
                                  "3 - Умножение двух матриц\n" +
                                  "4 - Выход");

                do
                {                  
                    do
                    {
                        Console.WriteLine("Введите номер операции: ");
                    } while (!Int32.TryParse(Console.ReadLine(), out numOperation)); // Считываем номер операции
                } while (numOperation < 1 || numOperation > 4); // Если пользователь ввел номер операции неправильно

                Console.Clear(); // Очистить консоль от предыдущих значений

                int[,] tempMatrix; // Результат операции

                Console.WriteLine("Результат: ");

                switch (numOperation)
                {
                    case 1: // Умножение матрицы на число
                        string nameMatrix; // Имя матрицы
                        do
                        {
                            Console.WriteLine("Выберите матрицу:\"А\" или \"В\""); // Просим пользователя выбрать матрицу
                            nameMatrix = Console.ReadLine(); // Считываем выбор пользователя
                        } while (nameMatrix != "A" && nameMatrix != "B"); // Если пользовател ввел название матрицы неправильно

                        int n; // Число для умножения
                        do // Считываем число для умножения
                        {
                            Console.WriteLine("Введите число для умножения:");
                        } while (!Int32.TryParse(Console.ReadLine(), out n));

                        tempMatrix = (nameMatrix == "A") ? matrixA : matrixB; // Выбираем матрицу для операции

                        for (int i = 0; i < tempMatrix.GetLength(0); i++) // Умножение матрицы на число и вывод на экран
                        {
                            for (int j = 0; j < tempMatrix.GetLength(1); j++)
                            {
                                tempMatrix[i, j] *= n; // Умножение на число элемента матрицы
                                Console.Write($"{tempMatrix[i, j],3}");
                            }
                            Console.WriteLine();
                        }
                        break;
                    case 2: // Сложение и вычитание матриц
                        if (row1 == row2 && column1 == column2) // Проверяем равенство строк и столбцов первой и второй матрицы
                        {
                            string isSum; // Сумма или вычитание
                            do
                            {
                                Console.WriteLine("Операция: \"+\" - сложение \"-\" - вычитание");
                                isSum = Console.ReadLine(); // Считываем значение
                            } while (isSum != "+" && isSum != "-"); // Если пользователь ввел неправильное значения

                            tempMatrix = new int[row1, column1]; // Первое слагаемое

                            for (int i = 0; i < row1; i++) // Выполнение операции и вывод в консоль
                            {
                                for (int j = 0; j < column1; j++)
                                {
                                    tempMatrix[i, j] = matrixA[i, j] + ((isSum == "+") ? 1 : -1) * matrixB[i, j];
                                    Console.Write($"{tempMatrix[i, j],3}");
                                }
                                Console.WriteLine();
                            }
                        }
                        else // Если нарушается условие, то предупреждаем пользователя
                        {
                            Console.WriteLine("Операция невозможная!");
                            Console.WriteLine("Должно выполняться равенство строк и столбцов первой и второй матрицы");
                        }
                        break;
                    case 3: // Умножение двух матриц
                        if (column1 == row2) // Проверяем условие равенства стобцов первой матрицы и строк второй матрицы
                        {
                            tempMatrix = new int[row1, column2]; // Задаем размерность результирующей матрицы

                            for (int i = 0; i < row1; i++) // Заполняем матрицу элементами и выводим
                            {
                                for (int j = 0; j < column2; j++)
                                {
                                    for (int k = 0; k < column1; k++)
                                    {
                                        tempMatrix[i, j] += matrixA[i, k] * matrixB[k, j];
                                    }
                                    Console.Write($"{tempMatrix[i, j],3}");
                                }
                                Console.WriteLine();
                            }
                        }
                        else // Если условие невыполнено, то вывести предупреждение
                        {
                            Console.WriteLine("Операция невозможная!");
                            Console.WriteLine("Должно выполняться равенство стобцов первой матрицы и строк второй матрицы");
                        }
                        break;
                }
                if (numOperation > 0 && numOperation < 4) // Пауза после операции
                {
                    Console.WriteLine("Нажмите клавишу, чтобы продолжить!");
                    Console.ReadKey();
                }

            } while (numOperation != 4); // Условие выхода
        }
    }
}

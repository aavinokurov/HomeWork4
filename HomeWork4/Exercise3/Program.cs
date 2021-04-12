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
            int row; // Кол-во строк
            int column; // Кол-во столбцов

            do
            {
                Console.WriteLine("Введите количество строк первой матрицы: "); // Просим пользователя ввести кол-во строк у первой матрицы
                row = Convert.ToInt32(Console.ReadLine()); // Считываем кол-во строк с консоли
            } while (row <= 0); // Если пользователь ввел значение меньше или равное 0

            do
            {
                Console.WriteLine("Введите количество столбцов первой матрицы: "); // Просим пользователя ввести кол-во столбцов у первой матрицы
                column = Convert.ToInt32(Console.ReadLine()); // Считываем кол-во столбцов с консоли
            } while (column <= 0); // Если пользователь ввел значение меньше или равное 0

            int[,] matrixA = new int[row, column]; // Первая матрица

            for (int i = 0; i < matrixA.GetLength(0); i++) // Инициализация элементов первой матрицы
            {
                for (int j = 0; j < matrixA.GetLength(1); j++)
                {
                    Console.WriteLine($"Введите значение для элемента а{i+1}{j+1}: "); // Просим пользователя ввести значение элемента
                    matrixA[i, j] = Convert.ToInt32(Console.ReadLine()); // Считываем с консоли значение элемента
                }
            }

            Console.Clear(); // Очистить консоль от предыдущих значений

            do
            {
                Console.WriteLine("Введите количество строк второй матрицы: "); // Просим пользователя ввести кол-во строк у второй матрицы
                row = Convert.ToInt32(Console.ReadLine()); // Считываем кол-во строк с консоли
            } while (row <= 0); // Если пользователь ввел значение меньше или равное 0

            do
            {
                Console.WriteLine("Введите количество столбцов второй матрицы: "); // Просим пользователя ввести кол-во столбцов у второй матрицы
                column = Convert.ToInt32(Console.ReadLine()); // Считываем кол-во столбцов с консоли
            } while (column <= 0); // Если пользователь ввел значение меньше или равное 0

            int[,] matrixB = new int[row, column]; // Вторая матрица

            for (int i = 0; i < matrixB.GetLength(0); i++) // Инициализация элементов второй матрицы
            {
                for (int j = 0; j < matrixB.GetLength(1); j++)
                {
                    Console.WriteLine($"Введите значение для элемента b{i + 1}{j + 1}: "); // Просим пользователя ввести значение элемента
                    matrixB[i, j] = Convert.ToInt32(Console.ReadLine()); // Считываем с консоли значение элемента
                }
            }

            int numOperation; // Номер операции

            do
            {
                Console.Clear(); // Очистить консоль от предыдущих значений

                Console.WriteLine("Матрицы А:");

                for (int i = 0; i < matrixA.GetLength(0); i++) // Вывод в консоль матрицы А
                {
                    for (int j = 0; j < matrixA.GetLength(1); j++)
                    {
                        Console.Write($"{matrixA[i, j],3}");
                    }
                    Console.WriteLine();
                }

                Console.WriteLine("Матрицы B:");

                for (int i = 0; i < matrixB.GetLength(0); i++) // Вывод в консоль матрицы B
                {
                    for (int j = 0; j < matrixB.GetLength(1); j++)
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
                    Console.WriteLine("Введите номер операции: ");
                    numOperation = Convert.ToInt32(Console.ReadLine()); // Считываем номер операции
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

                        Console.WriteLine("Введите число для умножения:");
                        int n = Convert.ToInt32(Console.ReadLine()); // Считываем число для умножения

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
                        if (matrixA.GetLength(0) == matrixB.GetLength(0) && matrixA.GetLength(1) == matrixB.GetLength(1)) // Проверяем равенство строк и столбцов первой и второй матрицы
                        {
                            int isSum; // Сумма или вычитание
                            do
                            {
                                Console.WriteLine("Операция: 1 - сложение 2 - вычитание");
                                isSum = Convert.ToInt32(Console.ReadLine()); // Считываем значение
                            } while (isSum < 1 || isSum > 2); // Если пользователь ввел неправильное значения

                            tempMatrix = new int[matrixA.GetLength(0), matrixA.GetLength(1)]; // Первое слагаемое

                            for (int i = 0; i < tempMatrix.GetLength(0); i++) // Выполнение операции и вывод в консоль
                            {
                                for (int j = 0; j < tempMatrix.GetLength(1); j++)
                                {
                                    tempMatrix[i, j] = matrixA[i, j] + ((isSum == 1) ? 1 : -1) * matrixB[i, j];
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
                        if (matrixA.GetLength(1) == matrixB.GetLength(0)) // Проверяем условие равенства стобцов первой матрицы и строк второй матрицы
                        {
                            tempMatrix = new int[matrixA.GetLength(0), matrixB.GetLength(1)]; // Задаем размерность результирующей матрицы

                            for (int i = 0; i < tempMatrix.GetLength(0); i++) // Заполняем матрицу элементами и выводим
                            {
                                for (int j = 0; j < tempMatrix.GetLength(1); j++)
                                {
                                    for (int k = 0; k < matrixA.GetLength(1); k++)
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

using ClassLibrary3;
using System;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Matrix A = null;
            Matrix B = null;
            Matrix C = null;

            while (true)
            {
                Console.Clear();

                Console.WriteLine();
                Console.WriteLine("|------------------------------ Меню ------------------------------|");
                Console.WriteLine("|                         1. Ввод матриц                           |");
                Console.WriteLine("|            2. Подсчёт кол-во элементов больших чем 3.15          |");
                Console.WriteLine("|  3. Подсчёт кол-во элементов больших чем число и крартных числу  |");
                Console.WriteLine("|                 4. Произведение матриц A*B и B*C                 |");
                Console.WriteLine("|            5. Сформировать массив сумм элементов строк           |");
                Console.WriteLine("|                       0. Выйти из программы                      |");
                Console.WriteLine("-------------------------------------------------------------------|");

                Console.Write("Введите номер действия: ");
                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.Write("Введите количество строк матрицы A: ");
                        int rowsA = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Введите количество столбцов матрицы A: ");
                        int columnsA = Convert.ToInt32(Console.ReadLine());

                        A = new Matrix(rowsA, columnsA);
                        A.InputMatrix();
                        Console.WriteLine("Матрица A успешно введена.");
                        Console.WriteLine("Введенная матрица A:");
                        Console.WriteLine(A);

                        Console.Write("Введите количество строк матрицы B: ");
                        int rowsB = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Введите количество столбцов матрицы B: ");
                        int columnsB = Convert.ToInt32(Console.ReadLine());

                        B = new Matrix(rowsB, columnsB);
                        B.InputMatrix();
                        Console.WriteLine("Матрица B успешно введена.");
                        Console.WriteLine("Введенная матрица B:");
                        Console.WriteLine(B);

                        Console.Write("Введите количество строк матрицы C: ");
                        int rowsC = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Введите количество столбцов матрицы C: ");
                        int columnsC = Convert.ToInt32(Console.ReadLine());

                        C = new Matrix(rowsC, columnsC);
                        C.InputMatrix();
                        Console.WriteLine("Матрица C успешно введена.");
                        Console.WriteLine("Введенная матрица C:");
                        Console.WriteLine(C);

                        Console.WriteLine("Нажмите Enter для продолжения...");
                        Console.ReadLine();
                        Console.Clear();
                        break;

                    case 2:
                        if (A == null)
                        {
                            Console.WriteLine("Матрицы не введены. Пожалуйста, выберите действие 1 для ввода матриц.");
                            break;
                        }
                        Console.WriteLine("Введенная матрица A:");
                        Console.WriteLine(A);
                        Console.WriteLine("Введенная матрица B:");
                        Console.WriteLine(B);
                        Console.WriteLine("Введенная матрица C:");
                        Console.WriteLine(C);
                        int countA = A.CountGreaterThan(3.15);
                        int countB = B.CountGreaterThan(3.15);
                        int countC = C.CountGreaterThan(3.15);
                        Console.WriteLine($"Количество элементов матрицы A, больших чем 3.15: {countA}");
                        Console.WriteLine($"Количество элементов матрицы B, больших чем 3.15: {countB}");
                        Console.WriteLine($"Количество элементов матрицы C, больших чем 3.15: {countC}");

                        Console.WriteLine("Нажмите Enter для продолжения...");
                        Console.ReadLine();
                        Console.Clear();
                        break;

                    case 3:
                        if (A == null)
                        {
                            Console.WriteLine("Матрицы не введены. Пожалуйста, выберите действие 1 для ввода матриц.");
                            break;
                        }

                        Console.Write("Введите число для сравнения элементов матриц: ");
                        double number = Convert.ToDouble(Console.ReadLine());

                        Console.Write("Введите множитель для выбора столбцов: ");
                        int multiple = Convert.ToInt32(Console.ReadLine());

                        int countGreaterThanA = A.CountGreaterThan(number, multiple);
                        int countGreaterThanB = B.CountGreaterThan(number, multiple);
                        int countGreaterThanC = C.CountGreaterThan(number, multiple);
                        Console.WriteLine("Введенная матрица A:");
                        Console.WriteLine(A);
                        Console.WriteLine("Введенная матрица B:");
                        Console.WriteLine(B);
                        Console.WriteLine("Введенная матрица C:");
                        Console.WriteLine(C);
                        Console.WriteLine($"Количество элементов матрицы A, больших чем {number} и кратных {multiple}, в указанных столбцах: {countGreaterThanA}");
                        Console.WriteLine($"Количество элементов матрицы B, больших чем {number} и кратных {multiple}, в указанных столбцах: {countGreaterThanB}");
                        Console.WriteLine($"Количество элементов матрицы C, больших чем {number} и кратных {multiple}, в указанных столбцах: {countGreaterThanC}");

                        Console.WriteLine("Нажмите Enter для продолжения...");
                        Console.ReadLine();
                        Console.Clear();
                        break;

                    case 4:
                        if (A == null || B == null || C == null)
                        {
                            Console.WriteLine("Матрицы A и B или C не введены. Пожалуйста, выберите действие 1 для ввода матриц.");
                            break;
                        }

                        try
                        {
                            Console.WriteLine("Введенная матрица A:");
                            Console.WriteLine(A);
                            Console.WriteLine("Введенная матрица B:");
                            Console.WriteLine(B);
                            Console.WriteLine("Введенная матрица C:");
                            Console.WriteLine(C);
                            Matrix result1 = A * B;
                            Matrix result2 = B * C;

                            Console.WriteLine("Результат умножения матриц A и B:");
                            Console.WriteLine(result1);
                            Console.WriteLine("Результат умножения матриц B и C:");
                            Console.WriteLine(result2);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }

                        Console.WriteLine("Нажмите Enter для продолжения...");
                        Console.ReadLine();
                        Console.Clear();
                        break;

                    case 5:
                        if (A == null || B == null || C == null)
                        {
                            Console.WriteLine("Матрицы не введены. Пожалуйста, выберите действие 1 для ввода матриц.");
                            break;
                        }
                        Console.WriteLine("Введенная матрица A:");
                        Console.WriteLine(A);
                        Console.WriteLine("Введенная матрица B:");
                        Console.WriteLine(B);
                        Console.WriteLine("Введенная матрица C:");
                        Console.WriteLine(C);
                        int positiveEvenA = A.CountPositiveInEvenColumns();
                        int positiveOddB = B.CountPositiveInOddColumns();

                        Console.WriteLine($"\nКоличество положительных элементов в четных столбцах матрицы A: {positiveEvenA}");
                        Console.WriteLine($"Количество положительных элементов в нечетных столбцах матрицы B: {positiveOddB}");

                        double[] sumRows;

                        if (positiveEvenA == positiveOddB)
                        {
                            double[] arrayB = (double[])B;
                            double[] arrayA = (double[])A;

                            sumRows = new double[A.Rows];
                            for (int i = 0; i < A.Rows; i++)
                            {
                                double sumA = arrayA[i]; // Добавляем сумму строк матрицы A
                                double sumB = arrayB[i]; // Добавляем сумму строк матрицы B
                                sumRows[i] = sumA + sumB;
                            }
                        }
                        else
                        {
                            sumRows = new double[C.Rows];
                            for (int i = 0; i < C.Rows; i++)
                            {
                                double sum = 0;
                                for (int j = 0; j < C.Columns; j++)
                                {
                                    sum += C[i, j];
                                }
                                sumRows[i] = sum;
                            }
                        }

                        // Вывод массива сумм элементов строк
                        Console.WriteLine("\nМассив сумм элементов строк:");
                        foreach (var element in sumRows)
                        {
                            Console.Write($"{element} ");
                        }

                        Console.WriteLine("Нажмите Enter для продолжения...");
                        Console.ReadLine();
                        Console.Clear();
                        break;
                }

                Console.WriteLine();
            }
        }
    }
}
﻿using ClassLibrary3;
using System;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Выберите действие:");
            Console.WriteLine("1. Ввести матрицы A, B и C");
            Console.WriteLine("2. Подсчитать количество элементов больших чем 3.15");
            Console.WriteLine("3. Подсчитать количество элементов больших чем number и кратных multiple");
            Console.WriteLine("4. Умножить матрицы");
            Console.WriteLine("5. Сформировать массив сумм элементов строк");
            Console.WriteLine("0. Выйти из программы");

            Matrix A = null;
            Matrix B = null;
            Matrix C = null;

            while (true)
            {
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
                        A.OutputMatrix();

                        Console.Write("Введите количество строк матрицы B: ");
                        int rowsB = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Введите количество столбцов матрицы B: ");
                        int columnsB = Convert.ToInt32(Console.ReadLine());

                        B = new Matrix(rowsB, columnsB);
                        B.InputMatrix();
                        Console.WriteLine("Матрица B успешно введена.");
                        Console.WriteLine("Введенная матрица B:");
                        B.OutputMatrix();

                        Console.Write("Введите количество строк матрицы C: ");
                        int rowsC = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Введите количество столбцов матрицы C: ");
                        int columnsC = Convert.ToInt32(Console.ReadLine());

                        C = new Matrix(rowsC, columnsC);
                        C.InputMatrix();
                        Console.WriteLine("Матрица C успешно введена.");
                        Console.WriteLine("Введенная матрица C:");
                        C.OutputMatrix();
                        break;

                    case 2:
                        if (A == null)
                        {
                            Console.WriteLine("Матрицы не введены. Пожалуйста, выберите действие 1 для ввода матриц.");
                            break;
                        }

                        int countA = A.CountGreaterThan(3.15);
                        int countB = B.CountGreaterThan(3.15);
                        int countC = C.CountGreaterThan(3.15);
                        Console.WriteLine($"Количество элементов матрицы A, больших чем 3.15: {countA}");
                        Console.WriteLine($"Количество элементов матрицы B, больших чем 3.15: {countB}");
                        Console.WriteLine($"Количество элементов матрицы C, больших чем 3.15: {countC}");
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

                        int countGreaterThanA = A.CountGreaterThanInColumns(number, multiple);
                        int countGreaterThanB = B.CountGreaterThanInColumns(number, multiple);
                        int countGreaterThanC = C.CountGreaterThanInColumns(number, multiple);
                        Console.WriteLine($"Количество элементов матрицы A, больших чем {number} и кратных {multiple}, в указанных столбцах: {countGreaterThanA}");
                        Console.WriteLine($"Количество элементов матрицы B, больших чем {number} и кратных {multiple}, в указанных столбцах: {countGreaterThanB}");
                        Console.WriteLine($"Количество элементов матрицы C, больших чем {number} и кратных {multiple}, в указанных столбцах: {countGreaterThanC}");
                        break;

                    case 4:
                        if (B == null || C == null)
                        {
                            Console.WriteLine("Матрицы B и C не введены. Пожалуйста, выберите действие 2 для ввода матриц.");
                            break;
                        }

                        if (A == null || B == null)
                        {
                            Console.WriteLine("Матрицы A и B не введены. Пожалуйста, выберите действие 1 для ввода матриц.");
                            break;
                        }

                        try
                        {
                            Matrix result1 = A * B;
                            Matrix result2 = B * C;

                            Console.WriteLine("Результат умножения матриц A и B:");
                            result1.OutputMatrix();

                            Console.WriteLine("Результат умножения матриц B и C:");
                            result2.OutputMatrix();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;

                    case 5:
                        
                        break;
                }

                Console.WriteLine();
            }
        }
    }
}
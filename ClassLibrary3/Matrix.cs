using System;

namespace ClassLibrary3
{
    /// <summary>
    /// Представляет матрицу, состоящую из числовых элементов типа double.
    /// </summary>
    public class Matrix
    {
        private double[,] _data;

        /// <summary>
        /// Количество строк в матрице.
        /// </summary>
        public int Rows { get { return _data.GetLength(0); } }

        /// <summary>
        /// Количество столбцов в матрице.
        /// </summary>
        public int Columns { get { return _data.GetLength(1); } }

        /// <summary>
        /// Индексатор для доступа к элементам матрицы.
        /// </summary>
        /// <param name="i">Индекс строки.</param>
        /// <param name="j">Индекс столбца.</param>
        /// <returns>Значение элемента матрицы.</returns>
        public double this[int i, int j]
        {
            get { return _data[i, j]; }
            set { _data[i, j] = value; }
        }

        /// <summary>
        /// Создает новую матрицу заданного размера.
        /// </summary>
        /// <param name="rows">Количество строк.</param>
        /// <param name="columns">Количество столбцов.</param>
        public Matrix(int rows, int columns)
        {
            _data = new double[rows, columns];
        }

        /// <summary>
        // Переопределение метода ToString() для вывода матрицы
        /// <summary>
        public override string ToString()
        {
            string matrixString = "";
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    matrixString += $"{this[i, j]} ";
                }
                matrixString += "\n";
            }
            return matrixString;
        }

        /// <summary>
        /// Подсчитывает количество элементов матрицы, которые больше заданного числа.
        /// </summary>
        /// <param name="number">Число, с которым сравниваются элементы матрицы.</param>
        /// <returns>Количество элементов матрицы, больших заданного числа.</returns>
        public int CountGreaterThan(double number)
        {
            int count = 0;
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    if (_data[i, j] > number)
                    {
                        count++;
                    }
                }
            }
            return count;
        }

        /// <summary>
        /// Подсчитывает количество элементов матрицы, больших заданного числа, в указанных столбцах с заданным шагом.
        /// </summary>
        /// <param name="number">Число, с которым сравниваются элементы матрицы.</param>
        /// <param name="multiple">Шаг для выбора столбцов.</param>
        /// <returns>Количество элементов матрицы, больших заданного числа, в указанных столбцах.</returns>
        public int CountGreaterThan(double number, int multiple)
        {
            int count = 0;
            for (int j = 0; j < Columns; j++)
            {
                if (j % multiple == 0)
                {
                    for (int i = 0; i < Rows; i++)
                    {
                        if (_data[i, j] > number)
                        {
                            count++;
                        }
                    }
                }
            }
            return count;
        }

        /// <summary>
        /// Выполняет умножение двух матриц.
        /// </summary>
        /// <param name="a">Первая матрица.</param>
        /// <param name="b">Вторая матрица.</param>
        /// <returns>Результат умножения матриц.</returns>
        public static Matrix operator *(Matrix a, Matrix b)
        {
            if (a.Columns != b.Rows)
            {
                throw new Exception("Невозможно выполнить умножение матриц");
            }

            Matrix result = new Matrix(a.Rows, b.Columns);

            for (int i = 0; i < a.Rows; i++)
            {
                for (int j = 0; j < b.Columns; j++)
                {
                    for (int k = 0; k < a.Columns; k++)
                    {
                        result[i, j] += a[i, k] * b[k, j];
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Преобразует матрицу в одномерный массив, содержащий сумму элементов каждой строки матрицы.
        /// </summary>
        /// <param name="a">Матрица для преобразования.</param>
        /// <returns>Одномерный массив сумм элементов каждой строки матрицы.</returns>
        public static implicit operator double[](Matrix a)
        {
            double[] result = new double[a.Rows];

            for (int i = 0; i < a.Rows; i++)
            {
                double sum = 0;
                for (int j = 0; j < a.Columns; j++)
                {
                    sum += a[i, j];
                }
                result[i] = sum;
            }

            return result;
        }

        /// <summary>
        /// Подсчитывает количество положительных элементов матрицы в четных столбцах.
        /// </summary>
        /// <returns>Количество положительных элементов матрицы в четных столбцах.</returns>
        public int CountPositiveInEvenColumns()
        {
            int count = 0;
            for (int j = 0; j < Columns; j += 2)
            {
                for (int i = 0; i < Rows; i++)
                {
                    if (_data[i, j] > 0)
                    {
                        count++;
                    }
                }
            }
            return count;
        }

        /// <summary>
        /// Подсчитывает количество положительных элементов матрицы в нечетных столбцах.
        /// </summary>
        /// <returns>Количество положительных элементов матрицы в нечетных столбцах.</returns>
        public int CountPositiveInOddColumns()
        {
            int count = 0;
            for (int j = 1; j < Columns; j += 2)
            {
                for (int i = 0; i < Rows; i++)
                {
                    if (_data[i, j] > 0)
                    {
                        count++;
                    }
                }
            }
            return count;
        }
    }
}
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassLibrary3;
using System.IO;
using System;

namespace UnitTestProject1
{
    [TestClass]
    public class MatrixTests
    {
        [TestMethod]
        public void TestInputMatrix()
        {
            // Подготовка к перехвату консольного вывода
            StringWriter sw = new StringWriter();
            Console.SetOut(sw);

            // Подготовка к предоставлению консольного ввода
            StringReader sr = new StringReader("1\n2\n3\n4\n");

            Console.SetIn(sr);

            // Вызов метода, который будет использовать Console.ReadLine() для ввода
            Matrix matrix = new Matrix(2, 2);
            matrix.InputMatrix();

            // Ожидаемый результат
            string expectedOutput = "Введите элемент [0,0]: Введите элемент [0,1]: Введите элемент [1,0]: Введите элемент [1,1]: ";

            // Проверка, что вызов Console.Write был сделан с ожидаемым результатом
            Assert.AreEqual(expectedOutput, sw.ToString());
        }

        [TestMethod]
        public void TestOutputMatrix()
        {
            // Arrange
            Matrix matrix = new Matrix(2, 2);
            matrix[0, 0] = 1;
            matrix[0, 1] = 2;
            matrix[1, 0] = 3;
            matrix[1, 1] = 4;

            // Создаем StringWriter для перехвата вывода в консоль
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                // Act
                Console.WriteLine(matrix.ToString());

                // Assert
                string expectedOutput = "1 2 \n3 4 \n";
                string[] expectedLines = expectedOutput.Trim().Split('\n');
                string[] actualLines = sw.ToString().Trim().Split('\n');

                for (int i = 0; i < expectedLines.Length; i++)
                {
                    CollectionAssert.AreEqual(
                        expectedLines[i].Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries),
                        actualLines[i].Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                    );
                }
            }
        }

        [TestMethod]
        public void TestCountGreaterThan()
        {
            Matrix matrix = new Matrix(2, 2);
            matrix[0, 0] = 1;
            matrix[0, 1] = 2;
            matrix[1, 0] = 3;
            matrix[1, 1] = 4;

            int count = matrix.CountGreaterThan(2);

            Assert.AreEqual(2, count);
        }

        [TestMethod]
        public void TestCountGreaterThanInColumns()
        {
            Matrix matrix = new Matrix(2, 2);
            matrix[0, 0] = 1;
            matrix[0, 1] = 2;
            matrix[1, 0] = 3;
            matrix[1, 1] = 4;

            int count = matrix.CountGreaterThan(3.15, 2);

            Assert.AreEqual(0, count);
        }

        [TestMethod]
        public void TestMatrixMultiplication()
        {
            Matrix a = new Matrix(2, 2);
            Matrix b = new Matrix(2, 2);

            a[0, 0] = 1;
            a[0, 1] = 2;
            a[1, 0] = 3;
            a[1, 1] = 4;

            b[0, 0] = 5;
            b[0, 1] = 6;
            b[1, 0] = 7;
            b[1, 1] = 8;

            Matrix result = a * b;

            Assert.AreEqual(19, result[0, 0]);
            Assert.AreEqual(22, result[0, 1]);
            Assert.AreEqual(43, result[1, 0]);
            Assert.AreEqual(50, result[1, 1]);
        }

        [TestMethod]
        public void TestConversionToDoubleArray()
        {
            Matrix matrix = new Matrix(2, 2);
            matrix[0, 0] = 1;
            matrix[0, 1] = 2;
            matrix[1, 0] = 3;
            matrix[1, 1] = 4;

            double[] result = (double[])matrix;

            Assert.AreEqual(3, result[0]);
            Assert.AreEqual(7, result[1]);
        }

        [TestMethod]
        public void TestCountPositiveInEvenColumns()
        {
            Matrix matrix = new Matrix(2, 2);
            matrix[0, 0] = 1;
            matrix[0, 1] = -2;
            matrix[1, 0] = 3;
            matrix[1, 1] = -4;

            int count = matrix.CountPositiveInEvenColumns();

            Assert.AreEqual(2, count);
        }

        [TestMethod]
        public void TestCountPositiveInOddColumns()
        {
            Matrix matrix = new Matrix(2, 3);
            matrix[0, 0] = 1;
            matrix[0, 1] = -2;
            matrix[0, 2] = 3;
            matrix[1, 0] = 4;
            matrix[1, 1] = -5;
            matrix[1, 2] = 6;

            int count = matrix.CountPositiveInOddColumns();

            Assert.AreEqual(0, count);
        }

        [TestMethod]
        public void MatrixMultiplication_DifferentDimensions_ThrowsException()
        {
            // Arrange
            Matrix a = new Matrix(2, 3); // Создаем матрицу размером 2x3
            Matrix b = new Matrix(4, 2); // Создаем матрицу размером 4x2

            // Act & Assert
            Assert.ThrowsException<Exception>(() => { Matrix result = a * b; }, "Невозможно выполнить умножение матриц");
        }

        [TestMethod]
        public void MatrixToDoubleArrayConversion_ValidMatrix_ReturnsExpectedResult()
        {
            // Arrange
            Matrix matrix = new Matrix(2, 3);
            matrix[0, 0] = 1;
            matrix[0, 1] = 2;
            matrix[0, 2] = 3;
            matrix[1, 0] = 4;
            matrix[1, 1] = 5;
            matrix[1, 2] = 6;

            // Act
            double[] result = (double[])matrix;

            // Assert
            double[] expected = { 6, 15 };
            CollectionAssert.AreEqual(expected, result);
        }
    }
}


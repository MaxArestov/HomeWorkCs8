// Задача 58: Задайте две матрицы. Напишите метод, который будет находить произведение двух матриц.
// Например, даны 2 матрицы:
// 2 4 | 3 4
// 3 2 | 3 3
// Результирующая матрица будет:
// 18 20
// 15 18
Console.Clear();
Console.WriteLine("Введите количество строк первой матрицы:");
int rowsMatrix1 = GetNumber();

Console.WriteLine("Введите количество столбцов первой матрицы и строк 2 матрицы:");
int columnsMatrix1 = GetNumber();

Console.WriteLine("Введите количество столбцов второй матрицы:");
int columnsMatrix2 = GetNumber();

int[,] firstMatrix = new int[rowsMatrix1, columnsMatrix1];
int[,] secondMatrix = new int[columnsMatrix1, columnsMatrix2];

Console.WriteLine("Элементы первой матрицы:");
Fill2dArray(firstMatrix);
Print2dArray(firstMatrix);

Console.WriteLine("Элементы второй матрицы:");
Fill2dArray(secondMatrix);
Print2dArray(secondMatrix);

Console.WriteLine("Элементы произведения двух матриц:");
int[,] matrixResult = GetProductOfMatrices(firstMatrix, secondMatrix);
Print2dArray(matrixResult);

int[,] GetProductOfMatrices(int[,] matrixA, int[,] matrixB)
{
    int[,] resultMatrix = new int[matrixA.GetLength(0), matrixB.GetLength(1)];
    for (int i = 0; i < resultMatrix.GetLength(0); i++)
    {
        for (int j = 0; j < resultMatrix.GetLength(1); j++)
        {
            int productMatrices = 0;
            for (int k = 0; k < matrixA.GetLength(1); k++)
            {
                productMatrices += matrixA[i, k] * matrixB[k, j];
            }
            resultMatrix[i, j] = productMatrices;
        }
    }
    return resultMatrix;
}

void Fill2dArray(int[,] array)
{
    Random random = new Random();
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            array[i, j] = random.Next(1, 10);
        }
    }
}

void Print2dArray(int[,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            Console.Write($"{array[i, j]} ");
        }
        Console.WriteLine();
    }
}

int GetNumber()
{
    int n = 0;
    bool check = true;
    while (check)
    {
        bool isParsed = int.TryParse(Console.ReadLine(), out n);
        if (!isParsed)
        {
            Console.WriteLine("Введены некорректные данные. Введите целое число:");
        }
        else
        {
            check = false;
            if (n < 0)
            {
                n *= -1;
            }
        }
    }
    return n;
}
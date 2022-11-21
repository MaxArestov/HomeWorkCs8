// Задача 56: Задайте прямоугольный двумерный массив. 
// Напишите метод, который будет находить строку с наименьшей суммой элементов.
Console.Clear();
Console.WriteLine("Введите количество строк массива:");
int rows = GetNumber();

Console.WriteLine("Введите количество столбцов массива:");
int columns = GetNumber();

if (rows == columns)
{
    Console.WriteLine("Введите разные числа, обозначающие количество строк и столбцов.");
    return;
}

int[,] arrayNums = new int[rows, columns];
Fill2dArray(arrayNums);
Print2dArray(arrayNums);
Console.WriteLine();
int minRow = new int();
int minSum = FindMinimalSum(arrayNums, out minRow);
Console.WriteLine($"Сумма наименьшей строчки - {minSum} на строчке {minRow}.");

int FindMinimalSum(int[,] array, out int minimalRow)
{
    int sum = 0;
    for (int k = 0; k < array.GetLength(0); k++)
    {
        for (int l = 0; l < array.GetLength(1); l++)
        {
            sum += array[k, l];
        }
    }
    int minimalSum = sum;
    minimalRow = 0;
    for (int i = 0; i < array.GetLength(0); i++)
    {
        sum = 0;
        for (int j = 0; j < array.GetLength(1); j++)
        {
            sum += array[i, j];
        }
        if (sum < minimalSum)
        {
            minimalSum = sum;
            minimalRow = i;
        }
    }
    return minimalSum;
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
// Задача 54: Задайте двумерный массив. 
// Напишите метод, который упорядочит по убыванию элементы каждой строки двумерного массива.
// И продемонстрируйте его работу.
// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// В итоге получается вот такой массив:
// 7 4 2 1
// 9 5 3 2
// 8 4 4 2
Console.Clear();
Console.WriteLine("Введите количество строк массива:");
int rows = GetNumber();

Console.WriteLine("Введите количество столбцов массива:");
int columns = GetNumber();

int[,] arrayNums = new int[rows, columns];
Fill2dArray(arrayNums);
Print2dArray(arrayNums);
Console.WriteLine();

ArrangeArray(arrayNums);
Print2dArray(arrayNums);

void ArrangeArray(int[,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            for (int k = 0; k < array.GetLength(1) - 1; k++)
            {
                if (array[i, k] < array[i, k + 1])
                {
                    int tmp = array[i, k];
                    array[i, k] = array[i, k + 1];
                    array[i, k + 1] = tmp;
                }
            }
        }
    }
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
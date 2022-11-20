// Задача 60. ...Сформируйте трёхмерный массив из неповторяющихся двузначных чисел. 
// Напишите метод, который будет построчно выводить массив, добавляя индексы каждого элемента.
Console.Clear();
Console.WriteLine("Введите количество строк массива:");
int rows = GetNumber();

Console.WriteLine("Введите количество столбцов массива:");
int columns = GetNumber();

Console.WriteLine("Введите количество глубины массива:");
int depth = GetNumber();

int[,,] arrayNums = new int[rows, columns, depth];
Fill3dArray(arrayNums);
Print3dArray(arrayNums);


void Fill3dArray(int[,,] array)
{
    List<int> list = new List<int>();
    Random random = new Random();
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            for (int k = 0; k < array.GetLength(2); k++)
            {
                bool check = true;
                while (check)
                {
                    int randomNumber = random.Next(10, 100);
                    if (!list.Contains(randomNumber))
                    {
                        list.Add(randomNumber);
                        array[i, j, k] = randomNumber;
                        check = false;
                    }
                }
            }
        }
    }
}

void Print3dArray(int[,,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            Console.Write($"X:{i}, Y:{j} ");
            for (int k = 0; k < array.GetLength(2); k++)
            {
                Console.Write($"Z:{k}: ");
                Console.Write($"{array[i, j, k]} ");
            }
        }
        Console.WriteLine();
    }
    Console.WriteLine();
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
        else check = false;
    }
    return n;
}
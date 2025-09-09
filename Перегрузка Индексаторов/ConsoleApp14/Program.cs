using System;

namespace ConsoleApplication1
{
    class MyArr
    {
        private int[] arr;

        public MyArr(int size)
        {
            arr = new int[size];
        }

        public int this[int index]
        {
            get
            {
                if (index < 0 || index >= arr.Length)
                {
                    return 0; 
                }
                return arr[index];
            }
            set
            {
                if (index >= 0 && index < arr.Length)
                {
                    arr[index] = value; 
                }
            }
        }

        public int this[double index]
        {
            get
            {
                int roundedIndex = (int)Math.Round(index);
                if (roundedIndex < 0 || roundedIndex >= arr.Length)
                {
                    return 0; 
                }
                return arr[roundedIndex];
            }
            set
            {
                int roundedIndex = (int)Math.Round(index);
                if (roundedIndex >= 0 && roundedIndex < arr.Length)
                {
                    arr[roundedIndex] = value; 
                }
            }
        }

        public int Length => arr.Length; 
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите количество элементов в массиве: ");
            int size;
            while (!int.TryParse(Console.ReadLine(), out size) || size <= 0)
            {
                Console.Write("введите положительное целое число: ");
            }

            MyArr arr = new MyArr(size);
            Random random = new Random();

            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = random.Next(1, 101);
            }

            Console.WriteLine("Получившийся массив: ");
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write($"{arr[i]}\t"); 
            }
            Console.WriteLine(); 

            Console.Write("Введите индекс для доступа к элементу массива: ");
            if (int.TryParse(Console.ReadLine(), out int index))
            {
                int value = arr[index];
                Console.WriteLine($"Элемент по индексу {index}: {value}");
            }
            else
            {
                Console.WriteLine("введите корректное целое число.");
            }

            Console.ReadLine();
        }
    }
}

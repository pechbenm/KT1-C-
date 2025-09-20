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
            Console.WriteLine("Выберите действие:");
            Console.WriteLine("1. Запустить программу с массивом.");
            Console.WriteLine("2. Выполнить задачу с индексами [4.51, 9.49, 99.9].");
            Console.Write("Введите номер действия (1 или 2): ");

            if (int.TryParse(Console.ReadLine(), out int choice) && (choice == 1 || choice == 2))
            {
                if (choice == 1)
                {
                    RunArrayProgram();
                }
                else
                {
                    RunDoubleIndexTask();
                }
            }
            else
            {
                Console.WriteLine("Некорректный ввод. Пожалуйста, введите 1 или 2.");
            }

            Console.ReadLine();
        }

        static void RunArrayProgram()
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

            Console.Write("Введите индекс для доступа к элементу массива(с нуля): ");
            if (int.TryParse(Console.ReadLine(), out int index))
            {
                int value = arr[index];
                Console.WriteLine($"Элемент по индексу {index}: {value}");
            }
            else
            {
                Console.WriteLine("введите корректное целое число.");
            }
        }

        static void RunDoubleIndexTask()
        {
            double[] indices = { 4.51, 9.49, 99.9 };
            int size = 100; 
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

            foreach (var index in indices)
            {
                int value = arr[index];
                Console.WriteLine($"Элемент по индексу {index}: {value}");
            }
        }
    }
}

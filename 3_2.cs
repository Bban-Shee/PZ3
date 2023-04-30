using System;

namespace PZ3_2
{
    class Program
    {
        public static void Main(string[] args)
        {
            //Введення кількості членів ряду
            Print("Введiть кiлькiсть членiв ряду: ");
            string str = Console.ReadLine();
            uint number = Check(str);
            //Виведення створеного ряду
            PrintArray(Array(number));
            //Виведення суми перших 10 членів ряду та суму усіх членів ряду з точністю до 0,000001
            Print($"\nСума всiх членiв ряду: {SumArray(Array(number)): 0.000000}\n");
            Sum10Array(Array(number));
        }

        //Метод для друку заданого рядка
        public static void Print(string str)
        {
            Console.Write(str);
        }

        //Метод для перевірки: чи є введене значення цілим додатним числом
        public static uint Check(string a)
        {
            uint b;
            bool isPNumber = uint.TryParse(a, out b);
            while (!isPNumber || b == 0)
            {
                Console.WriteLine("Ви помилились, введiть цiле додатнє число!");
                var c = Console.ReadLine();
                isPNumber = uint.TryParse(c, out b);
            }
            return b;
        }

        //Метод для створення ряду, кожен член якого обраховується по формулі
        public static float[] Array(uint n)
        {
            float [] arr = new float[n];
            {
                for(int i = 0; i < n; i++)
                {
                    arr[i] = (float) (Math.Pow(-1, i) * (1.0 - (Math.Pow((i + 1), 2)/ Math.Pow((i + 2), 2))));
                }
            }
            return arr;
        }

        //Метод для виведення створеного ряду
        public static void PrintArray(float[] arr)
        {
            Console.Write("Створено ряд: ");
            foreach (float i in arr) Console.Write(i + " ");
            Console.WriteLine();
        }

        //Обрахування суми всіх членів ряду
        public static float SumArray(float[] arr)
        {
            float sum = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                sum += arr[i];
            }
            return sum;
        }

        //Метод для виведення суми перших 10 членів ряду з точністю до 0,000001, якщо ряд містить більше 10 членів
        public static void Sum10Array(float[] arr)
        {
            float sum10 = 0;
            if (arr.Length > 10) 
            {
                for (int i = 0; i < 10; i++)
                {
                    sum10 += arr[i];
                }
                Console.WriteLine($"Сума перших 10 членiв ряду: {sum10: 0.000000}");
            }
        }
    }
}
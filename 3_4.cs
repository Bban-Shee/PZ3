using System;

namespace PZ3_4
{
    class Program
    {
        public static void Main(string[] args)
        {
            //Введення значення параметра k
            Print("Введiть значення параметра k: ");
            string str = Console.ReadLine();
            uint k = Check(str);
            //Виведення всіх можливих розв'язків рівняння
            Solution(k);
        }

        //Метод для друку заданого рядка
        public static void Print(string str)
        {
            Console.Write(str);
        }

        //Метод для перевірки: чи є введене значення натуральним числом від 1 до 30
        public static uint Check(string str)
        {
            uint k;
            bool isPNumber = uint.TryParse(str, out k);
            while (!isPNumber || k < 1 || k > 30)
            {
                Console.WriteLine("Ви помилились, введiть натуральне число вiд 1 до 30!");
                var a = Console.ReadLine();
                isPNumber = uint.TryParse(a, out k);
            }
            return k;
        }

        //Метод для розв'язання рівнняння
        public static void Solution(uint k)
        {
            //Створення масиву невід'ємних розв'язків рівняння
            int[,] variables = new int[30, 2];
            for (int i = 1; i <= variables.GetLength(0); i++)
            {
                variables[(i - 1), 0] = i;
                float t = (float)Math.Sqrt(Math.Pow(k, 2) - Math.Pow(i, 2));
                if (t == Math.Truncate(t)) variables[(i - 1), 1] = (int)t;
                else variables[(i - 1), 1] = 0;
            }
            //Перевірка існування розв'язків в межах від 1 до 30 та їх виведення
            int counter = 0;
            for (int i = 0; i < variables.GetLength(0); i++)
            {
                if (variables[i, 1] < 1 || variables[i, 1] > 30) counter++;
            }
            if (counter == variables.GetLength(0))
                Console.WriteLine("Задане рiвняння не має натуральних розв'язкiв в межах вiд 1 до 30!");
            else
            {
                Console.WriteLine("Розвязки рiвняння:");
                for (int i = 0; i < variables.GetLength(0); i++)
                {
                    if (variables[i, 1] >= 1 && variables[i, 1] <= 30)
                    {
                        Console.WriteLine("x = " + variables[i, 0] + ", y = " + variables[i, 1]);
                    }
                }
            }
        }
    }
}
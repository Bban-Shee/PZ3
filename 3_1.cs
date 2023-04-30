using System;

namespace PZ3_1
{
    class Program
    {
        public static void Main(string[] args)
        {
            //Введення кількості непарних чисел для обрахунку
            Print("Введiть кiлькiсть непарних чисел, суму яких ви бажаєте обрахувати: ");
            string str = Console.ReadLine();
            uint number = Check(str);
            //Виведення суми заданої кількості непарних чисел
            Print("Сума чисел: " + Sum(number) + "\n");
        }

        //Метод для друку заданого рядка
        public static void Print(string str)
        {
            Console.Write(str);
        }

        //Метод для перевірки: чи є введене значення додатним числом або 0
        public static uint Check(string a)
        {
            uint b;
            bool isPNumber = uint.TryParse(a, out b);
            while (!isPNumber)
            {
                Console.WriteLine("Ви помилились, введiть цiле додатнє число!");
                var c = Console.ReadLine();
                isPNumber = uint.TryParse(c, out b);
            }
            return b;
        }

        //Метод для обрахування суми заданої кількості непарних чисел
        public static uint Sum(uint n)
        {
            uint sum = 0;
            uint t = 1;
            if (n > 0)
            {
                while (t <= (2 * n - 1))
                {
                    sum += t;
                    t += 2;
                }
            }
            return sum;
        }
    }
}
using System;

namespace PZ3_3
{
    class Program
    {
        //Задання константні значення номеру варіанту та кроку
        const int VARIANT = 6;
        const float H = 0.6f;

        public static void Main(string[] args)
        {
            //Обчислення кількість розв'язків на даному проміжку з заданим кроком
            uint size = (int)((VARIANT / H) + 1);
            //Табуляція функції та виведення таблиці пар чисел х та y
            Tabulation(Solution(size));
            //Виведення графіку розв'язків
            Graph(Minimum(Solution(size)), Maximum(Solution(size)));
            //Виведення кількості негативних значень
            Negative(Solution(size));
            //Виведення максимального значення функції
            Print("Максимальне значення функцiї:" + $"{Maximum(Solution(size)): 0.000}\n\n");
        }

        //Метод для друку заданого рядка
        public static void Print(string str)
        {
            Console.Write(str);
        }

        //Метод для обрахування значення функції в точці х
        public static float Func14(float x)
        {
            float func = (float)(7 * Math.Cos(x) * Math.Sin(7 + 2 * x));
            return func;
        }

        //Метод для створення масиву пар чисел х та y
        public static float[,] Solution(uint size)
        {
            float[,] variables = new float[size, 2];
            float x = 0;
            for (int i = 0; i < variables.GetLength(0); i++)
            {
                variables[i, 0] = x;
                variables[i, 1] = Func14(x);
                x += H;
            }
            return variables;
        }

        //Метод для виведення таблиці пар чисел х та y
        public static void Tabulation(float[,] variables)
        {
            Console.WriteLine(" x\t   y");
            for (int i = 0; i < variables.GetLength(0); i++) Console.WriteLine(variables[i, 0] + "\t" + $"{variables[i, 1]: 0.000}");
        }
        
        //Метод для підрахування кількості від'ємних значень функції
        public static void Negative(float[,] variables)
        {
            uint counter = 0;
            for (int i = 0; i < variables.GetLength(0); i++) if (variables[i, 1] < 0) counter++;
            if (counter > 0) Console.WriteLine("Кiлькiсть вiд'ємних значень: " + counter);
            else Console.WriteLine("При заданих значеннях х функцiя не набуває вiд'ємних значень!");
        }

        //Метод для обчислення найбільшого значення функції
        public static float Maximum(float[,] variables)
        {
            float max = variables[0, 1];
            for (int i = 0; i < variables.GetLength(0); i++) if (variables[i, 1] > max) max = variables[i, 1];
            return max;
        }

        //Метод для обчислення найменшого значення функції
        public static float Minimum(float[,] variables)
        {
            float min = variables[0, 1];
            for (int i = 0; i < variables.GetLength(0); i++) if (variables[i, 1] < min) min = variables[i, 1];
            return min;
        }

        //Метод для друку певного символу задану кількість разів
        public static void CharPrint(char a, uint number)
        {
            for (int i = 1; i <= number; i++) Console.Write(a);
        }

        //Метод для виведення графіку розв'язків функції
        public static void Graph(float min, float max)
        {
            //Знаходження найбільшого значенння осі ординат
            int high = 0;
            if (Math.Abs(min) < Math.Abs(max)) high = (int)(Math.Abs(max) + 1);
            else high = (int)(Math.Abs(min) + 1);
            //Знаходження найбільшого значенння осі абсцис
            int width = (int)(((VARIANT / H) * 2) + 4);

            int y = high;
            float x = 0;
            //Виведення графіку за допомогою символів. Точки позначають розв'язки функції
            Console.WriteLine();
            for (int i = 0; i < (high - 1) * 4; i ++)
            {
                if (i == 0) Console.Write("y\n ^");
                else if (i == (high * 2) - 1)
                {
                    for (int j = 0; j < width; j++)
                    {
                        if (j == width - 1) Console.Write("> x");
                        else if (j == 0) Console.Write("-");
                        else if (j % 2 == 0) Console.Write("---");
                        else
                        {
                            Console.Write(x);
                            x += H;
                        }
                    }
                }
                else if (y == 5)
                {
                    Console.Write(" |");
                    CharPrint(' ', 4);
                    Console.Write(".\n " + y);
                    y--;
                }
                else if (y == 4)
                {
                    Console.Write(" .\n |\n " + y);
                    CharPrint(' ', 22);
                    Console.Write(".");
                    y--;
                }
                else if (y == 1)
                {
                    Console.Write(" |");
                    CharPrint(' ', 16);
                    Console.Write(".\n " + y);
                    CharPrint(' ', 55);
                    Console.Write(".");
                    y--;
                }
                else if (y == 0)
                {
                    Console.Write(" |");
                    CharPrint(' ', 10);
                    Console.Write(".");
                    y--;
                }
                else if (y == -1)
                {
                    Console.Write(" |");
                    CharPrint(' ', 44);
                    Console.Write(".\n " + y);
                    CharPrint(' ', 37);
                    Console.Write(".");
                    y--;
                }
                else if (y == -3)
                {
                    Console.Write(" |");
                    CharPrint(' ', 27);
                    Console.Write(".\n " + y + "\n |");
                    CharPrint(' ', 50);
                    Console.Write(".");
                    y--;
                }
                else if (y == -6)
                {
                    Console.Write(" |\n " + y);
                    CharPrint(' ', 31);
                    Console.Write(".\n |");
                    y--;
                }
                else if ((i % 2) == 0)
                {
                    Console.Write(" " + y);
                    y--;
                }
                else Console.Write(" |");
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}
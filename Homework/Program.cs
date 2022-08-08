using System;

namespace Homework
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Васильева Серафима
            //Задание 1. Программа «Анкета». 
            Console.WriteLine("Введите имя");
            string name = Console.ReadLine();

            Console.WriteLine("Введите фамилию");
            string surname = Console.ReadLine();

            Console.WriteLine("Введите возраст");
            int age = int.Parse(Console.ReadLine());

            Console.WriteLine("Введите рост в метрах");
            double height = double.Parse(Console.ReadLine()); //некоторые комментарии для себя: знак ,

            Console.WriteLine("Введите вес");
            int weight = int.Parse(Console.ReadLine());

            Console.WriteLine("Имя - " + name + "; Фамилия - " + surname + "; Возраст - " + age + "; Рост - " + height + "; Вес - " + weight); //Склейка
            Console.WriteLine("Имя - {0}; Фамилия - {1}; Возраст - {2}; Рост - {3}; Вес - {4}", name, surname, age, height, weight); // Форматирование
            Console.WriteLine($"Имя - {name}; Фамилия - {surname}; Возраст - {age}; Рост - {height}; Вес - {weight}\n"); // Интерполяция строк


            //Задание 2. Индекс массы тела.

            double result = CalculateIndex(weight, height);

            Console.WriteLine("Индекс массы тела = " + Math.Round(result, 2) + "\n");

            //Задание 3. Расстояние между точками с координатами

            Console.WriteLine("Введите координату x1");
            int x1 = int.Parse(Console.ReadLine());

            Console.WriteLine("Введите координату y1");
            int y1 = int.Parse(Console.ReadLine());

            Console.WriteLine("Введите координату x2");
            int x2 = int.Parse(Console.ReadLine());

            Console.WriteLine("Введите координату y2");
            int y2 = int.Parse(Console.ReadLine());

            /* Осознаю, что тут сильное дублирование кода, но не понимаю, как совместить вывод WriteLine (видимо через static void?) и при это задание координаты (static int?)
             и нужно ли это вообще */

            double resultLength = CalculateLength(x1, y1, x2, y2);

            Console.WriteLine("Расстояние между точками = " + Math.Round(resultLength, 2) + "\n");

            //Задание 4. Обмен значениями двух переменных
            // 3 переменная

            Console.WriteLine("Введите число a");
            int a1 = int.Parse(Console.ReadLine());

            Console.WriteLine("Введите число b");
            int b1 = int.Parse(Console.ReadLine());

            Console.WriteLine("a = " + a1 + ", b = " + b1);

            int c = a1;
            a1 = b1;
            b1 = c;

            Console.WriteLine("a = " + a1 + ", b = " + b1 + "\n");

            //без третьей
            Console.WriteLine("Введите число a");
            int a2 = int.Parse(Console.ReadLine());

            Console.WriteLine("Введите число b");
            int b2 = int.Parse(Console.ReadLine());

            Console.WriteLine("a = " + a2 + ", b = " + b2);

            a2 = a2 + b2;
            b2 = a2 - b2;
            a2 = a2 - b2;

            Console.WriteLine("a = " + a2 + ", b = " + b2 + "\n");

            //Задание 5. Вывод имени, фамилии, города

            string name1 = "Серафима";
            string surname1 = "Васильева";
            string town = "Санкт-Петербург";

            int x = (Console.WindowWidth / 2 - name1.Length / 2);
            int y = (Console.WindowHeight / 2 - 1);
            Print(name1, x, y);


            x = (Console.WindowWidth / 2 - surname1.Length / 2);
            y = (Console.WindowHeight / 2);
            Print(surname1, x, y);

            x = (Console.WindowWidth / 2 - town.Length / 2);
            y = (Console.WindowHeight / 2 + 1);
            Print(town, x, y);

            Console.ReadLine();
        }

        static double CalculateIndex(int m, double h)
        {
            return (m / (h * h));
        }


        static double CalculateLength(int x1, int y1, int x2, int y2)
        {
            double r = Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
            return r;
        }

        static void Print(string text, int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.WriteLine(text);
        }
    }
}

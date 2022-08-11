using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Homework.Utilities;

namespace Homework2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool f = true;

            while (f)
            {
                Tools.Header(2, "Васильева Серафима");
                Console.WriteLine(" Задания");
                Console.WriteLine("________________________________________________\n");
                Console.WriteLine("1. Минимальное из трех чисел");
                Console.WriteLine("2. Подсчет кол-ва цифр числа");
                Console.WriteLine("3. Сумма введенных нечетных положительных чисел");
                Console.WriteLine("4. Проверка логина и пароля");
                Console.WriteLine("5. Расчет нормализации веса");
                Console.WriteLine("6. Хорошие числа\n");
                Console.WriteLine("Введите 0 для завершения работы");
                Console.WriteLine("________________________________________________\n");

                Console.Write("Введите номер задачи: ");
                int number = int.Parse(Console.ReadLine());
                Console.WriteLine(" ");

                switch (number)
                {
                    case 0:
                        f = false;
                        break;

                    case 1:
                        Task1();
                        break;

                    case 2:
                        Task2();
                        break;

                    case 3:
                        Task3();
                        break;

                    case 4:
                        Task4();
                        break;

                    case 5:
                        Task5();
                        break;

                    case 6:
                        Task6();
                        break;

                    default:
                        Console.WriteLine("Некорректный номер. \n Попробуйте снова.");  //При попытке вывода другого текста после этого выходит наслоение
                        
                        break;
                }
                Tools.Pause();
                Console.Clear();

            }

            Console.WriteLine("Завершение программы. До свидания.");
            Console.ReadLine();

        }

        static void Task1()
        {
            Console.WriteLine("Задача 1. Поиск минимального числа \n");

            Console.Write("Введите первое число: ");
            int a = int.Parse(Console.ReadLine());
            Console.Write("Введите первое число: ");
            int b = int.Parse(Console.ReadLine());
            Console.Write("Введите первое число: ");
            int c = int.Parse(Console.ReadLine());

            int minNumber = a < b ? a : b;
            minNumber = minNumber < c ? minNumber : c;

            Console.WriteLine($"Минимальное число: {minNumber}");

        }

        static void Task2()
        {
            Console.WriteLine("Задача 2. Подсчет кол-ва цифр числа \n");

            Console.Write("Введите число: ");
            int number = int.Parse(Console.ReadLine());
            int n = number;
            int count = 0;

            while (n != 0)
            {
                count++;
                n = n / 10;
            }
            Console.WriteLine($"В числе {number} {count} цифр");



        }

        static void Task3()
        {
            Console.WriteLine("Задача 3. Подсчет суммы нечетных положительных чисел \n");

            int n, sum = 0;

            Console.WriteLine("Вводите положительные числа. Если будет введен 0, программа завершится ");

            do
            {
                Console.Write("Ваше число: ");
                n = int.Parse(Console.ReadLine());
                if (n < 0) Console.WriteLine("Введено отрицательное число. Повторите ввод снова."); 
                if (isOdd(n)) sum = sum + n;
            }
            while (n != 0);

            /* 
            Сначала планировала сделать while n != 0 && n > 0, но не хотелось, чтобы программа прерывалась из-за отрицательного числа.
            Но теперь я не понимаю, почему отрицательное нечетное число не идет в сумму. В теории, я бы добавила if (n>o) в работу isOdd 
            или сделала бы else вместо 2го if в основном блоке, но сейчас мне интересно, почему оно и так работает
            */

            Console.WriteLine($"Сумма нечетных положительных чисел равна {sum}");
        }

        static void Task4() //Не уверена, что поняла задание верно, поэтому сделала таким образом
        {
            Console.WriteLine("Задача 4. Проверка логина и пароля \n");

            string login = "root";
            string password = "GeekBrains";
            int count = 0;

            string userLogin, userPassword;

            Console.WriteLine("Введите логин и пароль");

            do
            {
                Console.Write("Введите логин: ");
                userLogin = Console.ReadLine();
                Console.Write("Введите пароль: ");
                userPassword = Console.ReadLine();
                Console.WriteLine(" ");

                if (userLogin == login && userPassword == password)
                {
                    Console.WriteLine("Авторизация пройдена");
                    break;
                }
                else
                {
                    Console.WriteLine("Неверный логин или пароль");
                    count++;
                }

            }
            while (count < 3);
            if (count == 3) Console.WriteLine("Вы исчерпали все попытки.");
        }

        static void Task5()
        {
            Console.WriteLine("Задача 5. Рекоммендации по нормализации веса \n");

            Console.Write("Введите свой вес: ");
            double weigth = double.Parse(Console.ReadLine());
            Console.Write("Введите свой рост в метрах: ");
            double height = double.Parse(Console.ReadLine());

            double index = Tools.CalculateIndex(weigth, height);
            Console.WriteLine($"Ваш ИМТ равен {(Math.Round(index, 2))}.");

            if (index < 18.5 )
            {
                double normalWeight = 18.5 * (height * height);
                double diff = normalWeight - weigth;
                Console.WriteLine($"У вас дефицит массы тела. Рекомендуется набрать {(Math.Round(diff,1))} кг.");
            }
            else if (index >= 18.5 && index <= 25)
            {
                Console.WriteLine("Ваш вес в норме.");
            }
            else
            {
                double normalWeight = 25 * (height * height);
                double diff = weigth - normalWeight;
                Console.WriteLine($"У вас избыточный вес. Рекомендуется сбросить {(Math.Round(diff, 1))} кг.");
            }

        }

        static void Task6()
        {
            Console.WriteLine("6. Поиск хороших чисел \n");
            DateTime start = DateTime.Now;

            int i;

            for (i = 1; i <= 1000000000; i++)
            {
                if (i % sum(i) == 0) Console.WriteLine(i);
            }

            DateTime finish = DateTime.Now;
            Console.WriteLine($"Затрачено времени: {(finish-start)}");
        }

        static bool isOdd(int n)
        {
            return n % 2 == 1;
        }

        static int sum (int n) // сумма цифр числа
        {
            int s = 0;
            while(n > 0)
            {
                s = s + n % 10;
                n = n / 10;
            }
            return s;
        }
        
    }

}

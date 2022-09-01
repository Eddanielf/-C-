using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Homework.Utilities;

namespace Homework4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool f = true;

            while (f)
            {
                Tools.Header(4, "Васильева Серафима");
                Console.WriteLine(" Задания");
                Console.WriteLine("________________________________________________\n");
                Console.WriteLine("1. Работа с одномерным массивов");
                Console.WriteLine("2. Считывание логина и пароля из файла");
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

                    default:
                        Console.WriteLine("Некорректный номер. \n Попробуйте снова.");

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
            bool h = true;

            while (h)
            {
                Console.WriteLine("Задаем массив:");
                Console.WriteLine("1. Массив с шагом ");
                Console.WriteLine("2. Рандомный массив ");
                Console.WriteLine("0. Выход ");
                Console.WriteLine("________________________________________________\n");

                Console.Write("Введите номер задачи: ");
                int number1 = int.Parse(Console.ReadLine());
                Console.WriteLine(" ");

                switch (number1)
                {
                    case 0:
                        h = false;
                        break;

                    case 1:
                        Task1_1();
                        break;

                    case 2:
                        Task1_2();
                        break;

                    default:
                        Console.WriteLine("Некорректный номер. \n Попробуйте снова.");

                        break;
                }
                Tools.Pause();
                Console.Clear();

            }
            Console.WriteLine("Нажмите любую клавишу");

        }

        static void Task1_1()
        {
            Console.Write("Введите число элементов массива: ");
            int n = int.Parse(Console.ReadLine());

            Console.Write("Введите начальный элемент массива: ");
            int n1 = int.Parse(Console.ReadLine());

            Console.Write("Введите шаг массива: ");
            int d = int.Parse(Console.ReadLine());

            MyArray a = new MyArray(n, n1, d);
            Console.WriteLine($"Ваш массив: {a.ToString()}");
            Console.WriteLine($"Минимальное число - {a.Min}; Максимальное - {a.Max}");
            Console.WriteLine($"Сумма элементов массива: {a.Sum}");
            MyArray b = a.Inverse();
            Console.WriteLine($"Инверсированный массив: {b.ToString()}");
            Console.Write("На какое число умножим элементы массива? ");
            int n2 = int.Parse(Console.ReadLine());
            a = a.Multi(n2);
            Console.WriteLine($"Массив, умноженный на {n2}: {a.ToString()}");
        }

        static void Task1_2()
        {
            MyArray c = new MyArray(10);
            Console.WriteLine($"Рандомный массив от -5 до 5: {c.ToString()}");
            Console.WriteLine($"Минимальное число - {c.Min}; Максимальное - {c.Max}");
            Console.WriteLine($"Сумма элементов массива: {c.Sum}");
            MyArray b = c.Inverse();
            Console.WriteLine($"Инверсированный массив: {b.ToString()}");
            Console.WriteLine($"Кол-во максимальных элементов массива: {c.MaxCount}");
        }

        static void Task2()
        {
            string[] d = MyArray.LoadArrayFromFile(AppDomain.CurrentDomain.BaseDirectory + "Authy.txt");
            string[] e = MyArray.Deplete(d[0]);
            string login = e[0];
            string password = e[1];
            int count = 0;
            string userLogin, userPassword;                     

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
                    Console.WriteLine("Неверный логин или пароль\n");
                    count++;
                }

            }
            while (count < 3);
            if (count == 3) Console.WriteLine("Вы исчерпали все попытки.");

        }
    }
}

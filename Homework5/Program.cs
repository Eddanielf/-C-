using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;
using Homework.Utilities;

namespace Homework5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool f = true;

            while (f)
            {
                Tools.Header(5, "Васильева Серафима");
                Console.WriteLine(" Задания");
                Console.WriteLine("________________________________________________\n");
                Console.WriteLine("1. Корректность ввода логина");
                Console.WriteLine("2. Класс Message");
                Console.WriteLine("3. Метод проверки строк");
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
            Console.WriteLine(" Задание #1. Корректность ввода логина. \n");
            Regex login = new Regex("^[a-zA-Z][a-zA-Z0-9]{1,9}$");

            string userLogin;
            
            do
            {
                Console.Write("Введите логин: ");
                userLogin = Console.ReadLine();
                if (login.IsMatch(userLogin))
                {
                    Console.WriteLine("Логин корректный");
                    break;
                }
                else
                {
                    Console.WriteLine("Логин некорректный.Попробуйте снова");
                }
            }
            while (true);

        }

        static void Task2()
        {
            Console.WriteLine(" Задание #2. Демонстрация работы класса Message. ");

            string message = "белка с утра купила булку с яблоком и сок";
            Console.WriteLine(" ");
            Console.WriteLine($"Сообщение: + {message}");

            Console.Write("В словах должно быть x или менее букв: ");
            int n = int.Parse(Console.ReadLine());
            Message.PrintWords(message, n);
            Console.WriteLine(" ");

            Console.Write("Убираем слово: ");
            string word = Console.ReadLine();
            Console.WriteLine(Message.RemoveWords(message, word));
            Console.WriteLine(" ");

            Console.WriteLine($"Самое длинное слово: {(Message.MaxWord(message))}");
            Console.WriteLine($"Самое короткое слово: {(Message.MinWord(message))}\t");

            Console.WriteLine($"Три самых длинных слова: {Message.maxWords(message)} ");

        }

        static void Task3()
        {
            Console.WriteLine(" Задание #3. Проверка соответствия строк. "); //без учета регистра. Чисто перестановка слов

            Console.Write("Введите первую строку: ");
            string str1 = Console.ReadLine();
            Console.Write("Введите вторую строку: ");
            string str2 = Console.ReadLine();

            bool f = Message.CompareStrings(str1, str2);

            if (f == true)
                Console.WriteLine("Строки состоят из одних и тех же символов.");
            else
                Console.WriteLine("Строки различны.");
        }
    }
}

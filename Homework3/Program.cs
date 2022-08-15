using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Homework.Utilities;

namespace Homework3
{
    public struct Complex
    {
        public double im;
        public double re;

        public Complex Plus(Complex x)
        {
            Complex y = new Complex();
            y.im = im + x.im;
            y.re = re + x.re;
            return y;
        }

        public static Complex Plus(Complex complex1, Complex complex2)
        {
            Complex res = new Complex();
            res.re = complex1.re + complex2.re;
            res.im = complex1.im + complex2.im;
            return res;
        }

        public Complex Minus(Complex x)
        {
            Complex y = new Complex();
            y.im = im - x.im;
            y.re = re - x.re;
            return y;
        }

        public static Complex Minus(Complex complex1, Complex complex2)
        {
            Complex res = new Complex();
            res.re = complex1.re - complex2.re;
            res.im = complex1.im - complex2.im;
            return res;
        }
        public override string ToString()
        {
            return $"{re} + {im}i";
        }
    }

    public class ComplexClass
    {
        public double re;
        public double im;

        public ComplexClass()
        {

        }

        public ComplexClass(double re, double im)
        {
            this.re = re;
            this.im = im;

        }

        public static ComplexClass Plus(ComplexClass complex1, ComplexClass complex2)
        {
            ComplexClass res = new ComplexClass();
            res.re = complex1.re + complex2.re;
            res.im = complex1.im + complex2.im;
            return res;
        }

        public static ComplexClass Minus(ComplexClass complex1, ComplexClass complex2)
        {
            ComplexClass res = new ComplexClass();
            res.re = complex1.re - complex2.re;
            res.im = complex1.im - complex2.im;
            return res;
        }
        public static ComplexClass Multi(ComplexClass complex1, ComplexClass complex2)
        {
            ComplexClass res = new ComplexClass();
            res.re = complex1.re * complex2.re;
            res.im = complex1.im * complex2.im;
            return res;
        }


        public override string ToString()
        {
            return $"{re} + {im}i";
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            bool f = true;

            while (f)
            {
                Console.Clear();
                Tools.Header(3, "Васильева Серафима");
                Console.WriteLine(" Задания");
                Console.WriteLine("________________________________________________\n");
                Console.WriteLine("1. Доработка структуры и класса Complex");
                Console.WriteLine("2. Сумма всех нечетных чисел с использованием TryParse");
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

            }


            Console.WriteLine("Завершение программы. До свидания.");
            Console.ReadLine();
        }

        static void Task1()
        {
            Console.Clear();
            Tools.Header(3, "Васильева Серафима");

            Task1Struct();

            Console.WriteLine("Суммирование, вычитание, умножение комплексных чисел через класс\n");

            ComplexClass complex3 = new ComplexClass();
            Console.Write("Введите действительную часть комплексного числа complex3: ");
            complex3.re = double.Parse(Console.ReadLine());
            Console.Write("Введите мнимую часть комплексного числа complex3: ");
            complex3.im = double.Parse(Console.ReadLine());
            Console.WriteLine($"Ваше число complex3: {complex3.ToString()}\n");

            ComplexClass complex4 = new ComplexClass();
            Console.Write("Введите действительную часть комплексного числа complex4: ");
            complex4.re = double.Parse(Console.ReadLine());
            Console.Write("Введите мнимую часть комплексного числа complex4: ");
            complex4.im = double.Parse(Console.ReadLine());
            Console.WriteLine($"Ваше число complex4: {complex4.ToString()}\n");

            bool n = true;

            while (n)
            {
                Console.Clear();
                Console.WriteLine($"Ваше число complex3: {complex3.ToString()}\n");
                Console.WriteLine($"Ваше число complex4: {complex4.ToString()}\n");
                Console.WriteLine("Сложение, вычитание, умножение комплексных чисел через класс");
                Console.WriteLine("1. Сложение комплексных чисел");
                Console.WriteLine("2. Вычитание комплексных чисел");
                Console.WriteLine("3. Умножение комплексных чисел");
                Console.WriteLine("0. Выход в основное меню");

                Console.Write("Введите номер: ");
                int number1 = int.Parse(Console.ReadLine());
                Console.WriteLine(" ");

                switch (number1)
                {
                    case 0:
                        n = false;
                        break;

                    case 1:
                        Task1ClassPlus(complex3, complex4);
                        break;

                    case 2:
                        Task1ClassMinus(complex3, complex4);
                        break;

                    case 3:
                        Task1ClassMulti(complex3, complex4);
                        break;

                    default:
                        Console.WriteLine("Некорректный номер. \n Попробуйте снова.");
                        break;
                }
                Tools.Pause();
            }
        }

        static void Task2()
        {
            Console.WriteLine("Задача 2. Сумма всех нечетных чисел с использованием TryParse\n");
           
            int n, sum = 0;

            Console.WriteLine("Вводите положительные числа. Если будет введен 0, программа завершится ");

            do
            {
                if (int.TryParse(Console.ReadLine(), out n) && n >= 0)
                {
                    if(Tools.isOdd(n)) sum = sum + n;
                }
                else
                {
                    Console.WriteLine("Вы ввели некорректное число.");
                    
                }
            }
            while (n != 0);

            Console.WriteLine($"Сумма нечетных положительных чисел равна {sum}");
        }

        static void Task1Struct()
        {
            Console.WriteLine("Суммирование и вычитание комплексных чисел через структуру\n");
            Complex complex1 = new Complex();
            complex1.re = 1;
            complex1.im = -1;
            Console.WriteLine($"complex1 = {complex1.ToString()}");
           
            Complex complex2 = new Complex();
            complex2.re = 2;
            complex2.im = 5;
            Console.WriteLine($"complex2 = {complex2.ToString()}");

            Complex resultPlus1 = complex1.Plus(complex2);
            Console.WriteLine($"Сложение: {resultPlus1.ToString()}");

            Complex resultPlus2 = Complex.Plus(complex1, complex2);
            Console.WriteLine($"через статичный метод {resultPlus2.ToString()}");

            Complex resultMinus1 = complex1.Minus(complex2);
            Console.WriteLine($"Вычитание: {resultMinus1.ToString()}");

            Complex resultMinus2 = Complex.Minus(complex1, complex2);
            Console.WriteLine($"через статичный метод {resultMinus2.ToString()}\n");

        }

        static void Task1ClassPlus(ComplexClass complex3, ComplexClass complex4)
        {
            Console.WriteLine("Суммирование комплексных чисел через класс\n");

            ComplexClass resultPlus3 = ComplexClass.Plus(complex3, complex4);
            Console.WriteLine($"Суммирование: {resultPlus3.ToString()}\n");


        }

        static void Task1ClassMinus(ComplexClass complex3, ComplexClass complex4)
        {
            Console.WriteLine("Вычитание комплексных чисел через класс\n");

            ComplexClass resultMinus3 = ComplexClass.Minus(complex3, complex4);
            Console.WriteLine($"Вычитание: {resultMinus3.ToString()}\n");

        }

        static void Task1ClassMulti(ComplexClass complex3, ComplexClass complex4)
        {
            Console.WriteLine("Умножение комплексных чисел через класс\n");
            ComplexClass resultMulti3 = ComplexClass.Multi(complex3, complex4);
            Console.WriteLine($"Умножение: {resultMulti3.ToString()} \n");
        }
    }
}

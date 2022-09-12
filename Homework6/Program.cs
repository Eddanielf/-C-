using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections.Generic;
using Homework.Utilities;

namespace Homework6
{
    public delegate double Fun(double a, double x);

    class Student
    {
        public string lastName;
        public string firstName;
        public string university;
        public string faculty;
        public string department;
        public int age;
        public int course;
        public int group;
        public string city;
        
        
        public Student(string firstName, string lastName, string university, string faculty, string department, int age, int course, int group, string city)
        {
            this.lastName = lastName;
            this.firstName = firstName;
            this.university = university;
            this.faculty = faculty;
            this.department = department;
            this.age = age;
            this.course = course;
            this.group = group;
            this.city = city;

        }
    }


    internal class Program
    {
        public static void Table(Fun F, double a, double x, double b)
        {
            Console.WriteLine("----- X ----- F(x) -----");
            while (x <= b)
            {
                Console.WriteLine("| {0,8:0.00} | {1,8:0.00} |", x, F(a, x));
                x += 1;
            }
            Console.WriteLine("---------------------");
        }

        public static double MyFunc(double a, double x)
        {
            return a * x * x;
        }

        public static double MySin(double a, double x)
        {
            return a * (Math.Sin(x));
        }

        public delegate double function (double x);

        public static double F1(double x)
        {
            return x * x - 50 * x + 10;
        }

        public static double F2(double x)
        {
            return x * x - 24 * x;
        }

        public static double F3(double x)
        {
            return 4 * x * x - 16 * x + 8;
        }

        public static void SaveFunc(string fileName, function F, double a, double b, double h)
        {
            FileStream fs = new FileStream(fileName, FileMode.Create,
            FileAccess.Write);
            BinaryWriter bw = new BinaryWriter(fs);
            double x = a;
            while (x <= b)
            {
                bw.Write(F(x));
                x += h;// x=x+h;
            }
            bw.Close();
            fs.Close();
        }
        public static double Load(string fileName)
        {
            FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            BinaryReader bw = new BinaryReader(fs);
            double min = double.MaxValue;
            double d;
            for (int i = 0; i < fs.Length / sizeof(double); i++)
            {
                d = bw.ReadDouble();
                if (d < min) min = d;
            }
            bw.Close();
            fs.Close();
            return min;
        }

        static int MyDelegat(Student st1, Student st2)
        {
            return String.Compare(st1.age.ToString(), st2.age.ToString());
        }

        static void Main(string[] args)
        {
            bool f = true;

            while (f)
            {
                Tools.Header(6, "Васильева Серафима");

                Console.Write("Введите номер задачи (1-3): ");
                int number = int.Parse(Console.ReadLine());
                Console.WriteLine("________________________________________________\n");
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
            Console.WriteLine("Задание #1.");
            Console.WriteLine("________________________________________________\n");

            double a = 3;
            double x = -2;
            double b = 2;
            Console.WriteLine($"Функция имеет вид: F(x) = {a} * x * x");
            Console.WriteLine("Таблица функции MyFunc:");
            Table(new Fun(MyFunc), a, x, b);
            Console.WriteLine(" ");

            Console.WriteLine($"Функция имеет вид: F(x) = {a} * sin(x)");
            Console.WriteLine("Таблица функции MySin:");
            Table(new Fun(MySin), a, x, b);
        }

        static void Task2()
        {
            Console.WriteLine("Задание #2.");
            Console.WriteLine("________________________________________________\n");

            function[] F = { F1, F2, F3 };
            Console.Write($"F1 = x * x - 50 * x + 10; \t F2 = x * x - 24 * x; \t F3 = 4 * x * x - 16 * x + 8; \n Выберите функцию (1-3): ");
            int userF = int.Parse(Console.ReadLine());
            SaveFunc("data.bin", F[userF-1], -100, 100, 0.5);
            Console.Write("Минимум функции равен: ");
            Console.WriteLine(Load("data.bin"));
            Console.ReadKey();
        }

        static void Task3()
        {
            Console.WriteLine("Задание #3.");
            Console.WriteLine("________________________________________________\n");
            int bakalavr = 0;
            int magistr = 0;
            List<Student> list = new List<Student>();

            DateTime dt = DateTime.Now;
            StreamReader sr = new StreamReader("D:/C#/СSharp/Vasileva.Homework/-C-/Homework6/students_6.csv");
            while (!sr.EndOfStream)
            {
                try
                {
                    string[] s = sr.ReadLine().Split(';');
                    // Добавляем в список новый экземпляр класса Student
                    list.Add(new Student(s[0], s[1], s[2], s[3], s[4], int.Parse(s[5]), int.Parse(s[6]), int.Parse(s[7]), s[8]));
                    // Одновременно подсчитываем количество бакалавров и магистров
                    if (int.Parse(s[6]) < 5) bakalavr++; else magistr++;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine("Ошибка!ESC - прекратить выполнение программы");
                    // Выход из Main
                    if (Console.ReadKey().Key == ConsoleKey.Escape) return;
                }
            }
            sr.Close();
            
            Console.WriteLine("Всего студентов:" + list.Count + "\n");
            int course6 = 0;
            int course5 = 0;
            Console.WriteLine("Учащиеся 18-20 лет: ");

            foreach (var v in list)
            {
                if (v.age >= 18 && v.age <= 20)
                    Console.WriteLine(v.firstName + " " + v.course);

                if (v.course == 6) course6++;

                if (v.course == 5) course5++;
            }
            Console.WriteLine(" ");
            Console.WriteLine($"Учащихся на 6 курсе: {course6}");
            Console.WriteLine($"Учащихся на 5 курсе: {course5} \n");

            Console.WriteLine("Сортировка по возрасту:");
            list.Sort(new Comparison<Student>(MyDelegat));
            foreach (var v in list)
                Console.WriteLine(v.firstName + " " + v.age);
            Console.WriteLine(" ");
            Console.WriteLine(DateTime.Now - dt);
            Console.ReadKey();
        }
    }
}

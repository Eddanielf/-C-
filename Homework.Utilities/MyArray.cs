using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Homework.Utilities
{
    public class MyArray
    {
        int[] a;

        public MyArray(int[] a)
        {
            this.a = a;
        }

        public MyArray(int n)
        {
            a = new int[n];
            Random rnd = new Random();
            for (int i = 0; i < n; i++)
                a[i] = rnd.Next(-5, 6);
        }

        public MyArray(int n, int e1) // заполнение массива одним значением e1
        {
            a = new int[n];
            for (int i = 0; i < n; i++)
                a[i] = e1;
        }

        public MyArray(int n, int from, int inter) // массив со стартовым значением и шагом
        {
            a = new int[n];
            a[0] = from;
            for (int i = 1; i < n; i++)
                a[i] = a[i - 1] + inter;
        }

        public MyArray(string fileName)
        {
           string []array = LoadArrayFromFile(fileName);
        }

        public int Min
        {
            get
            {
                int min = a[0];
                for (int i = 1; i < a.Length; i++)
                    if (a[i] < min) min = a[i];
                return min;
            }
        }

        public int Max
        {
            get
            {
                int max = a[0];
                for (int i = 1; i < a.Length; i++)
                    if (a[i] > max) max = a[i];
                return max;
            }
        }

        public int CountPositive
        {
            get
            {
                int count = 0;
                for (int i = 0; i < a.Length; i++)
                    if (a[i] > 0) count++;
                return count;
            }
        }

        public int CountNegative
        {
            get
            {
                int count = 0;
                for (int i = 0; i < a.Length; i++)
                    if (a[i] < 0) count++;
                return count;
            }
        }

        public int Sum
        {
            get
            {
                int sum = 0;
                for (int i = 0; i < a.Length; i++)
                    sum = sum + a[i];
                return sum;
            }
        }

        public int MaxCount
        {
            get
            {
                int count = 0;
                int max = a.Max();
                for (int i = 0; i < a.Length; i++)
                    if (a[i] == max) count++;
                return count;
            }
        }


        public MyArray Inverse()
        {
            int[] b = new int[a.Length];
            for (int i = 0; i < a.Length; i++)
                b[i] = -a[i];
            return new MyArray(b);
        }

        public MyArray Multi(int k)
        {
            for (int i = 0; i < a.Length; i++)
                a[i] = a[i] * k;
            return new MyArray(a);
        }

        public override string ToString()
        {
            string s = "";
            foreach (int v in a)
                s = s + v + " ";
            return s;
        }

        public void PrintArray()
        {
            for (int i = 0; i < a.Length; i++)
            {
                Console.Write($"{a[i]}\t");
            }
            Console.WriteLine();
        }

        public static void PrintArray(string[] a)
        {
            for (int i = 0; i < a.Length; i++)
            {
                Console.Write($"{a[i]}\t");
            }
            Console.WriteLine();
        }

        public static string [] Deplete(string x)
        {
            return x.Split(':');

        }

        public static string[] LoadArrayFromFile(string fileName)
        {
            if (File.Exists(fileName))
            {
                //StreamWriter
                //    WriteLine
                StreamReader streamReader = new StreamReader(fileName);
                string [] buf = new string [1000];
                int count = 0;
                //streamReader.ReadLine();
                //streamReader.EndOfStream
                while (!streamReader.EndOfStream)
                {
                    buf[count] = streamReader.ReadLine();
                    count++;
                }

                string [] a = new string [count];
                Array.Copy(buf, a, count);
                streamReader.Close();
                return a;

            }
            else
                throw new FileNotFoundException();
        }
        
    }
}

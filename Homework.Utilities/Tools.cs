using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework.Utilities
{
    public class Tools
    {
        public static void Header(int homeworkNumber, string name)
        {
            Console.SetCursorPosition((Console.WindowWidth - name.Length - 1), 1);
            Console.WriteLine(name);
            Console.SetCursorPosition((Console.WindowWidth - name.Length - 1), 2);
            Console.WriteLine("Homework " + homeworkNumber);
            Console.SetCursorPosition((Console.WindowWidth - name.Length - 1), 3);
            Console.WriteLine("___________________\n");
        }
        public static void Pause()
        {
            Console.ReadKey();
        }

        public static double CalculateIndex(double m, double h)
        {
            return (m / (h * h));
        }

    }
}

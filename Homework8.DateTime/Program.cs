using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Homework.Utilities;

namespace Homework8.Reflection
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Tools.Header(8, "Васильева Серафима");
            Type typeData = typeof(DateTime);
            
            Console.WriteLine("Свойства структуры DateTime");
            Console.WriteLine("---------------------------\n");
            foreach (var v in typeData.GetProperties())
            {
                Console.WriteLine("\t" + v.Name);
            }
            Console.ReadLine();
        }
    }
}

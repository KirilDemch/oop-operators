using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NameFraction;

namespace FractionConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Fraction drob1 = new Fraction(1, 2);
            Fraction drob2 = new Fraction(3, 5);
            Fraction drob3 = new Fraction(12.4);
            Console.WriteLine(drob3 + drob1 / (-drob1) * drob2 - drob1);
            Console.ReadKey();
        }
    }
}

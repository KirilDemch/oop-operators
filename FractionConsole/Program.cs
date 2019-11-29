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
            Console.WriteLine(drob1 - drob2);
            Console.ReadKey();
        }
    }
}

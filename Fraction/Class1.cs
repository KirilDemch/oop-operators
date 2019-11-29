using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NameFraction
{
    public class Fraction
    {
        protected long Numerator;
        protected long Denominator;

        public Fraction(long Numerator, long Denominator)
        {
            this.Numerator = Numerator;
            this.Denominator = Denominator;
            Fix();
        }
        public Fraction(long Numerator)
        {
            this.Numerator = Numerator;
            Denominator = 1;
        }
        public Fraction(Fraction a)
        {
            Numerator = a.Numerator;
            Denominator = a.Denominator;
        }
        private void Fix()
        {
            if (Numerator > 0 && Denominator < 0)
            {
                Numerator = -Numerator;
                Denominator = -Denominator;
            }
            if (Numerator < 0 && Denominator < 0)
            {
                Denominator = -Denominator;
            }
        }
        // наибольший общий делитель 
        private static long Nod(Fraction a)
        {
            a.Numerator = Math.Abs(a.Numerator);
            a.Denominator = Math.Abs(a.Denominator);
            while (a.Denominator != 0 && a.Numerator != 0)
            {
                if (a.Numerator % a.Denominator > 0)
                {
                    var temp = a.Numerator;
                    a.Numerator = a.Denominator;
                    a.Denominator = temp % a.Denominator;
                }
                else break;
            }
            if (a.Denominator != 0 && a.Numerator != 0) return a.Denominator;
            return 0;
        }
        private static void Simplify(Fraction a)
        {
            long nod = Nod(a);
            if (nod > 0)
            {
                a.Numerator /= nod;
                a.Denominator /= nod;
            }
        } 

        // унарні: +, –  
        public static Fraction operator +(Fraction a)
        {
            return a;
        }
        public static Fraction operator -(Fraction a)
        {
            a.Numerator = -a.Numerator;
            return a;
        }
        // бінарні +, –, *, /
        public static Fraction operator +(Fraction a, Fraction b)
        {

            return new Fraction(a.Numerator * b.Denominator + b.Numerator * a.Denominator, a.Denominator * b.Denominator);
        }
        public static Fraction operator -(Fraction a, Fraction b)
        {
            Fraction res = new Fraction(a.Numerator * b.Denominator - b.Numerator * a.Denominator, a.Denominator * b.Denominator);
            //Nod(res);
            return res;
        }
        public static Fraction operator *(Fraction a, Fraction b)
        {
            return new Fraction(a.Numerator * b.Numerator, a.Denominator * b.Denominator);
        }
        public static Fraction operator /(Fraction a, Fraction b)
        {
            return new Fraction(a.Numerator * b.Denominator, a.Denominator * b.Numerator);
        }
        // бінарні: >, >=, <, <=, ==, !=

        public static bool operator > (Fraction a, Fraction b)
        {
            return (double)a > (double)b;
        }
        public static bool operator < (Fraction a, Fraction b)
        {
            return (double)a < (double)b;
        }
        public static bool operator == (Fraction a, Fraction b)
        {
            return (double)a == (double)b;
        }
        public static bool operator != (Fraction a, Fraction b)
        {
            return (double)a != (double)b;
        }
        public static bool operator >= (Fraction a, Fraction b)
        {
            return (double)a >= (double)b;
        }
        public static bool operator <=(Fraction a, Fraction b)
        {
            return (double)a <= (double)b;
        }
        // операціz приведення типу до double
        public static explicit operator double(Fraction a)
        {
          return (double)a.Numerator / a.Denominator;
        }

        // перевизначений метод ToString(), який записуватиме дріб у рядок виду «12/55» (чисельник/знаменник).
        public override string ToString()
        {
            return ($"{Numerator}/{Denominator}");
        }
    }
}

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
        public Fraction(double Number)
        {
            Denominator = 1;
            while ((Number % (int)Number) != 0)
            {
                Number *= 10;
                Denominator *= 10;
            }
            Numerator = (long)Number;
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
        private static long Nod(long Numerator, long Denominator)
        {
            Numerator = Math.Abs(Numerator);
            Denominator = Math.Abs(Denominator);
            while (Denominator != 0 && Numerator != 0)
            {
                if (Numerator % Denominator > 0)
                {
                    long temp = Numerator;
                    Numerator = Denominator;
                    Denominator = temp % Denominator;
                }
                else break;
            }
            if (Denominator != 0 && Numerator != 0) return Denominator;

            return 0;

        }
        private static Fraction Simplify(Fraction a)
        {
            long nod = Nod(a.Numerator, a.Denominator);
            if (nod != 0)
            {
                a.Numerator /= nod;
                a.Denominator /= nod;
            }
            return a;
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
        public static Fraction operator + (Fraction a, Fraction b)
        {
            return Simplify(new Fraction(a.Numerator * b.Denominator + b.Numerator * a.Denominator, a.Denominator * b.Denominator));
        }
        public static Fraction operator - (Fraction a, Fraction b)
        {
            return Simplify(new Fraction(a.Numerator * b.Denominator - b.Numerator * a.Denominator, a.Denominator * b.Denominator));
        }
        public static Fraction operator * (Fraction a, Fraction b)
        {
            return Simplify(new Fraction(a.Numerator * b.Numerator, a.Denominator * b.Denominator));
        }
        public static Fraction operator / (Fraction a, Fraction b)
        {
            return Simplify(new Fraction(a.Numerator * b.Denominator, a.Denominator * b.Numerator));
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

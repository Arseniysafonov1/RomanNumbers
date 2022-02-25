using System;
using System.Collections.Generic;
using System.Text;

namespace RomanNumbers
{
    public class RomanNumber : ICloneable, IComparable
    {
        private ushort n;
        private string s;
        public RomanNumber(ushort n)
        {
            if (n == 0)
            {
                throw new RomanNumberException();
            }
            this.n = n;
            s = "";//X̅ = X*; L̅ = L*; V̅ = V*
            int mod = n / 10000;
            for (int i = 0; i < mod; i++)
            {
                s += "X*";
            }
            s = s.Replace("X*X*X*X*X*", "L*");
            s = s.Replace("X*X*X*X*", "X*L*");
            mod = n % 10000 / 1000;
            for (int i = 0; i < mod; i++)
            {
                s += "M";
            }
            s = s.Replace("MMMMM", "V*");
            s = s.Replace("V*MMMM", "MX*");
            s = s.Replace("MMMM", "MV*");
            mod = n % 1000 / 100;
            for (int i = 0; i < mod; i++)
            {
                s += "C";
            }
            s = s.Replace("CCCCC", "D");
            s = s.Replace("DCCCC", "CM");
            s = s.Replace("CCCC", "CD");


            mod = n % 100 / 10;
            for (int i = 0; i < mod; i++)
            {
                s += "X";
            }
            s = s.Replace("XXXXX", "L");
            s = s.Replace("LXXXX", "XM");
            s = s.Replace("XXXX", "XL");



            mod = n % 10;
            for (int i = 0; i < mod; i++)
            {
                s += "I";
            }
            s = s.Replace("IIIII", "V");
            s = s.Replace("VIIII", "IX");
            s = s.Replace("IIII", "IV");
        }

        public static RomanNumber Add(RomanNumber? rn1, RomanNumber? rn2)
        {
            if (rn1 == null || rn2 == null)
            {
                throw new RomanNumberException();
            }
            int sum = rn1.n + rn2.n;
            if (sum > ushort.MaxValue)
            {
                throw new RomanNumberException();
            }
            return new RomanNumber((ushort)sum);
        }


        public static RomanNumber Sub(RomanNumber? rn1, RomanNumber? rn2)
        {
            if (rn1 == null || rn2 == null)
            {
                throw new RomanNumberException();
            }
            int sub = rn1.n - rn2.n;
            if (sub <= 0)
            {
                throw new RomanNumberException();
            }
            return new RomanNumber((ushort)sub);
        }

        public static RomanNumber Mul(RomanNumber? rn1, RomanNumber? rn2)
        {
            if (rn1 == null || rn2 == null)
            {
                throw new RomanNumberException();
            }
            int mul = rn1.n * rn2.n;
            if (mul > ushort.MaxValue)
            {
                throw new RomanNumberException();
            }
            return new RomanNumber((ushort)mul);
        }


        public static RomanNumber Div(RomanNumber? rn1, RomanNumber? rn2)
        {
            if (rn1 == null || rn2 == null)
            {
                throw new RomanNumberException();
            }
            double div = rn1.n / rn2.n;
            if (div % 1 != 0)
            {
                throw new RomanNumberException();
            }
            return new RomanNumber((ushort)div);
        }

        public override string ToString()
        {
            return this.s;
        }

        public object Clone()
        {
            return new RomanNumber(this.n);
        }

        public int CompareTo(object? obj)
        {
            RomanNumber rn = obj as RomanNumber;
            if (rn == null)
            {
                throw new RomanNumberException();
            }
            return this.n.CompareTo(rn.n);
        }
    }
}
